using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using static PresidentialPolls.Model.DBContexts;

namespace PresidentialPolls.Model
{
    public partial class Model
    {
        public delegate void StateUpdateCompletedEventHandler(string? state);
        public event StateUpdateCompletedEventHandler? StateUpdateCompleted;


        private readonly string baseUrl = @"https://www.270towin.com/2024-presidential-election-polls/";//arizona
        //private readonly string filePath;

        private readonly HttpClient httpClient;
        private readonly float battleGroundValue = 5;

        //private State lastState;

        public IList<string>? NewStatePolling { get; }
        public SortedDictionary<DateTime, CalendarEvent>? CalendarEvents { get; }

        public Model(string filePath)
        {
            //this.filePath = filePath;

            PollContextFactory.Path = filePath;

            NewStatePolling = [];

            JsonSerializerOptions jsonSerializerOptions = new() { Converters = { new ColorJsonConverter() } };
            JsonSerializerOptions options = jsonSerializerOptions;

            string json = File.ReadAllText(filePath + @"CalendarEvents.json");
            CalendarEvents = JsonSerializer.Deserialize<SortedDictionary<DateTime, CalendarEvent>>(json, options);


            httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };


            if( !Directory.Exists(@"./DATA/") )
                Directory.CreateDirectory(@"./DATA/");


            //seed db
            using PollContext db = PollContextFactory.Instance;
            bool anyThisDay = db.Polls.Any(x => x.Date.Equals(DateTime.Now.Date));
            if( anyThisDay )
            {
                Logger.Log("Values are presnnt for this day");
            }
            else
            {
                Logger.Log("No record for this day");
            }


            // // // // // // database massage // // // // // 

            ////careful!!!
#if DEBUG
            bool careful = false;
            if( careful )
            {
                //db.Polls.Clear();
                //db.SaveChanges();
            }
#endif
            Logger.Log(db.Polls.Count());
            Logger.Log(db.States.Count());


            Logger.Log("done");


        }


        public class ColorJsonConverter : JsonConverter<Color>
        {
            //public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => Color.FromName(reader.GetString() );
            public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                string? temp = reader.GetString();
                if( temp != null )
                    return Color.FromName(temp);

                return Color.White;
            }
            public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options) => writer.WriteStringValue(value.Name);

        }


        private IList<State>? states;

        public IList<State>? States
        {
            get
            {
                if( states == null )
                {
                    using PollContext db = PollContextFactory.Instance;
                    if( !db.States.Any() ) return null;
                    states = [.. db.States.Where(s => s.Name != null)];

                    //lastState = states.Last();

                }
                return states;
            }
        }


        private static void UpdateDBWithCompletedMarker()
        {
            using PollContext db = PollContextFactory.Instance;
            bool anyThisDay = db.Polls.Any(x => x.Date.Equals(DateTime.Now.Date));
            if( !anyThisDay )
            {
                StatesPollData poll = new()
                {
                    Date = DateTime.Now.Date,
                    State = "No polls this day",
                    Source = null
                };
                db.Add(poll);
                db.SaveChanges();
                anyThisDay = db.Polls.Any(x => x.Date.Equals(DateTime.Now.Date));
            }
        }
        private static bool UpdateDatabaseByState(string state, string html)
        {
            using PollContext db = PollContextFactory.Instance;
            int addedCounter = 0;

            try
            {
                object result = FindData.GetData(state, html);
                if( result == null ) return false;

                if( result is IList<StatesPollData> pollList )
                {
                    if( pollList.Count == 0 )
                        return false;

                    foreach( StatesPollData poll in pollList )
                    {
                        // check to see if it is already in the db
                        if( db.Polls.Any(
                            x => x.Date == poll.Date
                            &&
                            x.State != null && x.State.Equals(poll.State)
                            &&
                            x.Source != null && x.Source.Equals(poll.Source))
                            )
                        {
                            continue;
                        }
                        else
                        {
                            db.Add(poll);
                            addedCounter++;
                        }

                    }
                }
                else
                {
                    Logger.Log("skipping " + state);
                }

            }
            catch( Exception ex )
            {
                Logger.Log("Exception " + state + " " + ex.Message);
            }

            Logger.Log("addedCounter=" + addedCounter);
            if( addedCounter > 0 )
                db.SaveChanges();

            Logger.Log(db.Polls.Count());

            //Logger.Log(state);
            //var list = db.Polls.Where(x => x.State == state).ToList();
            //foreach( var item in list )
            //    Logger.Log(item.ToString());

            return ( addedCounter > 0 );
            // 
        }



        internal void UpdateDatabase()
        {
            //if( !Directory.Exists(@"./DATA/") )
            //    Directory.CreateDirectory(@"./DATA/");

            if( false )
            {
                ////GetByStateForDB("arizona"); return;

                //foreach( var item in statesAndTerritories )
                //{
                //    GetByStateForDB(item);
                //    //Thread.Sleep(1000);
                //}

            }
            else
            {
                using var db0 = PollContextFactory.Instance;
                //db0.Polls.Clear();
                //db0.SaveChanges();
                Logger.Log(db0.Polls.Count());
                foreach( var poll in db0.Polls )
                    Logger.Log(poll.ToString());


                //int addedCounter = 0;

                //goto again;
                using PollContext db = PollContextFactory.Instance;
                SortedDictionary<string, SortedDictionary<DateTime, StatesPollData>> master = [];
                var states = States;
                if( states == null ) return;
                foreach( var state in states )
                {
                    if( state.Name == null ) continue;

                    string html = File.ReadAllText(@"./DATA/" + state.Name + ".html");
                    if( html == null ) continue;

                    UpdateDatabaseByState(state.Name, html);
                    /*
                    try
                    {
                        object result = FindData.GetData(state.Name, html);
                        if( result == null ) continue;

                        if( result is IList<StatesPollData> pollList )
                        {
                            if( pollList.Count == 0 )
                                continue;

                            foreach( StatesPollData poll in pollList )
                            {
                                var serials = db.Polls.Select(
                                    g => g.Date == poll.Date
                                    &&
                                    g.State != null && g.Source == poll.State
                                    &&
                                    g.Source != null && g.Source == poll.Source
                                    );
                                if( serials.Any() )
                                    continue;

                                db.Add(poll);
                                addedCounter++;
                            }
                        }
                        else
                        {
                            Logger.Log("skipping " + state);
                        }

                    }
                    catch( Exception ex )
                    {
                        Logger.Log("Exception " + state + " " + ex.Message);
                    }
                    */
                }
                //using
                /*
                Logger.Log("addedCounter=" + addedCounter);
                if( addedCounter > 0 )
                    db.SaveChanges();
                Logger.Log(db.Polls.Count());
                */
                //foreach( var poll in db.Polls )
                //    Logger.Log(poll.ToString());


            }

            return;
        }

        public async void GetByStateForDB(string state)
        {
            try
            {
                // for http call
                string lowercaseState = state;
                if( lowercaseState.Contains(' ') )
                    lowercaseState = lowercaseState.Replace(" ", "-");

                lowercaseState = lowercaseState.ToLower();

                //string html = File.ReadAllText(@"./DATA/" + lowercaseState + ".html");

                string html = await httpClient.GetStringAsync(lowercaseState);
                if( string.IsNullOrEmpty(html) ) return;

                //File.WriteAllText(@"./DATA/" + state + ".html", html);

                if( UpdateDatabaseByState(state, html) )
                    NewStatePolling?.Add(state);

                StateUpdateCompleted?.Invoke(state);

                //if( state.Equals("wyoming", StringComparison.CurrentCultureIgnoreCase) )
                if( states == null ) return;
                if( state.Equals(states.Last().Name, StringComparison.CurrentCultureIgnoreCase) )
                {
                    StateUpdateCompleted?.Invoke(null);

                    UpdateDBWithCompletedMarker();

                }

            }
            catch( Exception ex )
            {
                Logger.Log(ex.Message);
            }

        }

        public class NewPollsInfo(string? state, StatesPollData statesPollData)
        {
            public string? State { get; set; } = state;
            public StatesPollData? StatesPollData { get; set; } = statesPollData;

        }

        public static IList<NewPollsInfo>? TodaysPolls
        {
            get
            {
                // what are the new polls? this will get them
                using PollContext db = PollContextFactory.Instance;
                return [.. ( from x in db.Polls
                         where x.Date == DateTime.Now.Date//.AddDays(-1)
                         select new NewPollsInfo(x.State, x) )];
                /*
                if( query!=null && query.Count() > 0 )
                {
                    foreach( var item in query )
                        Logger.Log(item.State + " " + item.x);
                }

                return query;*/
            }
        }

        internal static bool CheckForUpdate
        {
            get
            {
                using PollContext db = PollContextFactory.Instance;
                if( !db.Polls.Any() ) return true;
                var last = db.Polls.Max(x => x.Date);
                return ( last < DateTime.Now.Date );
            }
        }

        internal PlotData? GetPlotDataByState(string? state)
        {
            if( state == null ) throw new Exception("ElectoralVotes state == null");

            IList<DateTime> dateDem = [];
            IList<double> demData = [];

            IList<DateTime> dateRep = [];
            IList<double> repData = [];


            float? maxDem = 0;
            float? maxRep = 0;
            float? minDem = 100;
            float? minRep = 100;


            using PollContext db = PollContextFactory.Instance;
            //IQueryable<bool> res = db.Polls.Select(g => g.State != null && g.State.Equals(state));
            //if( res.Count() == 0 )
            //    return null;


            IQueryable<StatesPollData> list = db.Polls.Where(g => g.State != null && g.State.Equals(state));
            if( list == null || !list.Any() )
                return null;

            SortedDictionary<DateTime, double> demRawData = [];
            SortedDictionary<DateTime, double> repRawData = [];

            Random random = new();

            foreach( var poll in list )
            {
                //Logger.Log(poll.ToString());

                dateDem.Add(poll.Date);
                dateRep.Add(poll.Date);

                if( poll.DemocratPollPercentage == null ) continue;
                if( poll.RepublicanPollPercentage == null ) continue;

                DateTime extraDT = poll.Date.AddSeconds(random.Next(0, 60)).AddMilliseconds(random.Next(1, 1000));

                double data = poll.DemocratPollPercentage.Value;
                if( data > 0 )
                {
                    demData.Add(data);
                    if( maxDem < data )
                        maxDem = (float)data;

                    if( minDem > data && data != 0 )
                        minDem = (float)data;

                    if( demRawData.ContainsKey(poll.Date) )
                        demRawData.Add(extraDT, data);
                    else
                        demRawData.Add(poll.Date, data);
                }

                data = poll.RepublicanPollPercentage.Value;
                if( data > 0 )
                {
                    repData.Add(data);
                    if( maxRep < data )
                        maxRep = (float)data;

                    if( minRep > data && data != 0 )
                        minRep = (float)data;

                    //repKeyValuePairs.Add(poll.Date, data);
                    if( repRawData.ContainsKey(poll.Date) )
                        repRawData.Add(extraDT, data);
                    else
                        repRawData.Add(poll.Date, data);


                }
            }


            SortedDictionary<DateTime, double> demSmoothedData = [];
            SortedDictionary<DateTime, double> repSmoothedData = [];
            if( demRawData.Count > 3 )
            {
                demSmoothedData = smooth.SmoothData(demRawData);
                repSmoothedData = smooth.SmoothData(repRawData);
            }


            PartyData demPartyData = new(Color.Blue, demRawData, demSmoothedData, maxDem, minDem);
            PartyData repPartyData = new(Color.Red, repRawData, repSmoothedData, maxRep, minRep);

            return new PlotData(demPartyData, repPartyData);
            //
        }

        readonly ISmooth smooth = new Smooth2();//Smooth1

        interface ISmooth
        {
            SortedDictionary<DateTime, double> SmoothData(SortedDictionary<DateTime, double> keyValuePairs);
        }

        public class Smooth1 : ISmooth
        {
            public SortedDictionary<DateTime, double> SmoothData(SortedDictionary<DateTime, double> keyValuePairs)
            {
                SortedDictionary<DateTime, double> smoothedKeyValuePairs = [];

                IList<double> smoothed = [];
                if( keyValuePairs.Count == 0 )
                {
                }
                //else if( keyValuePairs.Count < 7 )
                //{
                //    smoothedKeyValuePairs = [];
                //}

                /*
                else if( keyValuePairs.Count == 3 )
                {
                    smoothed.Add(keyValuePairs.Skip(2).First().Value);
                    smoothed.Add(keyValuePairs.Skip(1).First().Value);
                    smoothed.Add(keyValuePairs.First().Value);
                }
                else if( keyValuePairs.Count == 2 )
                {
                    smoothed.Add(keyValuePairs.Skip(1).First().Value);
                    smoothed.Add(keyValuePairs.First().Value);
                }
                else if( keyValuePairs.Count == 1 )
                {
                    smoothed.Add(keyValuePairs.First().Value);
                }
                */
                else
                {
                    var entry = keyValuePairs.MaxBy(entry => entry.Value).Key;
                    keyValuePairs.Remove(entry);
                    entry = keyValuePairs.MinBy(entry => entry.Value).Key;
                    keyValuePairs.Remove(entry);

                    IEnumerable<KeyValuePair<DateTime, double>> reversed = keyValuePairs.Reverse();
                    //foreach( var item in reversed )
                    //    Logger.Log(item.Key.ToShortDateString() + " " + item.Value);
                    //int i = 0;

                    for( int index = 0; index < keyValuePairs.Count; index++ )
                    {
                        if( index == keyValuePairs.Count - 2 ) break;

                        var n1 = reversed.Skip(index).First().Value;
                        var n2 = reversed.Skip(index + 1).First().Value;
                        var n3 = reversed.Skip(index + 2).First().Value;

                        double[] numbers = [n1, n2, n3];
                        double average = numbers.Average();

                        //Logger.Log("{0} {1} {2} {3}", n1, n2, n3, average);
                        smoothed.Add(average);

                        smoothedKeyValuePairs.Add(reversed.Skip(index).First().Key, average);

                    }

                    //Logger.Log(keyValuePairs.Count);
                    //Logger.Log(smoothed.Count);

                    smoothed.Add(keyValuePairs.Skip(1).First().Value);
                    smoothed.Add(keyValuePairs.First().Value);

                    smoothedKeyValuePairs.Add(keyValuePairs.Skip(1).First().Key, keyValuePairs.Skip(1).First().Value);
                    smoothedKeyValuePairs.Add(keyValuePairs.First().Key, keyValuePairs.First().Value);
                }

                return smoothedKeyValuePairs;
                //return smoothed;
            }
        }

        public class Smooth2 : ISmooth
        {
            public SortedDictionary<DateTime, double> SmoothData(SortedDictionary<DateTime, double> keyValuePairs)
            {
                SortedDictionary<DateTime, double> smoothedKeyValuePairs = [];

                if( keyValuePairs.Count == 0 )
                {
                }

                else
                {
                    IEnumerable<KeyValuePair<DateTime, double>> lastEntriesFirst = keyValuePairs.Reverse();
                    //foreach( var item in lastEntriesFirst )
                    //    Logger.Log(item.Key.ToShortDateString() + " " + item.Value);

                    for( int index = 0; index < lastEntriesFirst.Count(); index++ )
                    {
                        Dictionary<DateTime, double> slice = lastEntriesFirst.Skip(index).Take(5).ToDictionary();
                        var entry = slice.MaxBy(entry => entry.Value).Key;
                        slice.Remove(entry);
                        entry = slice.MinBy(entry => entry.Value).Key;
                        slice.Remove(entry);

                        if( slice.Count < 3 )
                        {
                            var remaining = lastEntriesFirst.Skip(index).TakeLast(lastEntriesFirst.Count() - index);

                            foreach( var remainItem in remaining )
                                smoothedKeyValuePairs.Add(remainItem.Key, remainItem.Value);

                            return smoothedKeyValuePairs;

                        }

                        var n1 = slice.Skip(0).First().Value;
                        var n2 = slice.Skip(1).First().Value;
                        var n3 = slice.Skip(2).First().Value;

                        double[] numbers = [n1, n2, n3];
                        double average = numbers.Average();

                        smoothedKeyValuePairs.Add(lastEntriesFirst.Skip(index).First().Key, average);

                    }

                    return smoothedKeyValuePairs;

                }

                return smoothedKeyValuePairs;
                //
            }


            public static double StdDev(IEnumerable<double> values)
            {
                double ret = 0;
                int count = values.Count();
                if( count > 1 )
                {
                    //Compute the Average
                    double avg = values.Average();

                    //Perform the Sum of (value-avg)^2
                    double sum = values.Sum(d => ( d - avg ) * ( d - avg ));

                    //Put it all together
                    ret = Math.Sqrt(sum / count);
                }
                return ret;
            }


        }

        internal bool UpdateAll()
        {
            if( NewStatePolling == null ) return false;

            NewStatePolling.Clear();

            Thread thread = new(delegate ()
            {
                var states = States;
                if( states == null ) return;

                foreach( var state in states )
                {
                    if( state.Name == null ) continue;
                    //if( state.Name == "National" ) continue;
                    GetByStateForDB(state.Name);
                    Thread.Sleep(1000);
                }

            });

            thread.Start();

            return true;
        }

        internal IList<State> GetBattleGroundStatesList()
        {
            IList<State> battleGroundStates = [];
            IList<State>? allStates = States;
            if( allStates == null ) return battleGroundStates;

            using PollContext db = PollContextFactory.Instance;
            foreach( State state in allStates )
            {
                if( state.Name == null ) continue;
                if( state.Name == "National" ) continue;
                IQueryable<StatesPollData> stateData = db.Polls.Where(x => x.State != null && x.State.Equals(state.Name));
                if( stateData == null || !stateData.Any() ) continue;

                var last = stateData.Max(x => x.Date);

                StatesPollData? statesPollData =
                    db.Polls.Where(x => x.State != null && x.State.Equals(state.Name) && x.Date.Equals(last)).FirstOrDefault();

                if( statesPollData == null ) continue;
                if( statesPollData.DemocratPollPercentage == null ) continue;
                if( statesPollData.RepublicanPollPercentage == null ) continue;

                if( Math.Abs(statesPollData.DemocratPollPercentage.Value - statesPollData.RepublicanPollPercentage.Value) <= battleGroundValue )
                    battleGroundStates.Add(state);

            }

            return battleGroundStates;
            //
        }

        internal static IList<State> GetLargeStatesList(int count)
        {
            using PollContext db = PollContextFactory.Instance;
            List<State> topStatesByVote = [.. db.States.Where(a => a.Name != null && a.Name != "National").OrderByDescending(x => x.ElectoralVotes).Take(count)];
            if( topStatesByVote == null ) return [];
            return topStatesByVote;
            //
        }
    }

}


/*
Logger.Log("national");
var list = db.Polls.Where(x => x.State == "National").ToList();
if( db.Polls.Any(x => x.State == "national") )
{
}

if( db.States.Any(x => x.Name == "North Carolina") )
{
}

list = db.Polls.Where(x => x.State == "North Carolina").ToList();
foreach( var item in list )
{
    //db.Polls.Remove(item);
    //db.SaveChanges();
}
//if( list.Count > 0 )
//    db.SaveChanges();

list = db.Polls.Where(x => x.State == "North Carolina").ToList();


//this.GetByStateForDB("North Carolina");

list = db.Polls.Where(x => x.State == "North Carolina").ToList();
foreach( var item in list )
    Logger.Log(item.ToString());
Logger.Log("North Carolina");
*/
/*
foreach( var item in list )
{
    Logger.Log(item.ToString());
    item.State = "National";
    Logger.Log(item.ToString());
}
if( list.Count > 0 )
    db.SaveChanges();

var list = db.Polls.Where(x => x.State == "national").ToList();
list = db.Polls.Where(x => x.State == "National").ToList();
//foreach( var item in list )
//Logger.Log(item.ToString());

//var larestStates = GetLargeStatesList(10);
foreach( State state in db.States )
    if( state != null )
    {
        Logger.Log(String.Format("{0} {1}", state.Name, state.ElectoralVotes));

        if( state.Name == "national" )
        {
            db.States.Remove(state);
            State newState = new State();
            newState.Name = "National";
            newState.ElectoralVotes = state.ElectoralVotes;
            db.States.Add(newState);
            db.SaveChanges();
        }

    }

foreach( State state in db.States )
    if( state != null )
    {
        Logger.Log(String.Format("{0} {1}", state.Name, state.ElectoralVotes));
        //
    }
*/