using System.ComponentModel.DataAnnotations;

namespace PresidentialPolls.Model
{
    public class StatesPollData
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Source { get; set; }
        public string? State { get; set; }
        public float? DemocratPollPercentage { get; set; }
        public float? RepublicanPollPercentage { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4}", State, Date, Source, DemocratPollPercentage, RepublicanPollPercentage);
        }
    }

    public class State
    {
        [Key]
        public string? Name { get; set; }
        public int ElectoralVotes { get; set; }

        public override string? ToString()
        {
            return Name;
        }
    }

    /*
    public class StatesData
    {
        public string? state { get; set; }
        public int electoralVotes { get; set; }
        public int RepublicanElectoralVotes { get; set; }
        public int DemocratElectoralVotes { get; set; }
        public float? DemocratPollPercentage { get; set; }
        public float? RepublicanPollPercentage { get; set; }
    }
    public class USStatesElectoralVotes
    {
        public IList<StatesData>? ListOfStates { get; set; }

    }
#pragma warning restore IDE1006 // Naming Styles

    public class USStatesElectoralVotesData
    {
        public SortedDictionary<DateTime, IList<StatesData>> Data { get; set; }

        public USStatesElectoralVotesData()
        {
            Data = new SortedDictionary<DateTime, IList<StatesData>>();
        }
    }
    */

}
