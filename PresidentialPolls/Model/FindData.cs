using HtmlAgilityPack;

namespace PresidentialPolls.Model
{
    public class FindData
    {
        public static object GetData(string state, string html)
        {
            HtmlAgilityPack.HtmlDocument document = new();

            document.LoadHtml(html);

            HtmlNode alert_danger = document.DocumentNode.SelectSingleNode("//div/div[contains(@class, 'alert-danger')]");
            if( alert_danger != null )
                throw new NoPollingDataException(state);                //return new PollData(0, 0);


            //HtmlNode? table = GetTable(document, "Including Third Parties and Independents");
            HtmlNode? table = GetTable(document);

            //if( table == null )
            //{
            //    HtmlNodeCollection nodeCollection = document.DocumentNode.SelectNodes("//table[contains(@id, 'polls')]");
            //    table = nodeCollection[0];
            //}


            IList<StatesPollData> statesPollDataList = [];

            if( table == null )
                return statesPollDataList;


            HtmlNodeCollection allPolldatetds = table.SelectNodes("tr/td[contains(@class, 'poll_date')]");
            if( allPolldatetds != null )
            {
                foreach( HtmlNode singlePolldateTD in allPolldatetds )
                {
                    float democratPollValue = 0;
                    float republicanPollValue = 0;
                    string datestr = singlePolldateTD.InnerText.Trim();
                    if( DateTime.TryParse(datestr, out DateTime dt) )
                    {
                        HtmlNode rowDates = singlePolldateTD.ParentNode;
                        HtmlNode poll_src = rowDates.SelectSingleNode("td[contains(@class, 'poll_src')]");
                        if( poll_src == null ) continue;

                        HtmlNode rowDate = rowDates.SelectSingleNode("td[contains(@candidate_id, '" + AttributeUtilities.GetId(Candidate.Harris) + "')]");
                        if( rowDate != null )
                            democratPollValue = float.Parse(rowDate.InnerText.Trim().Replace("%", ""));

                        rowDate = rowDates.SelectSingleNode("td[contains(@candidate_id, '" + AttributeUtilities.GetId(Candidate.Biden) + "')]");
                        if( rowDate != null )
                            democratPollValue = float.Parse(rowDate.InnerText.Trim().Replace("%", ""));

                        rowDate = rowDates.SelectSingleNode("td[contains(@candidate_id, '" + AttributeUtilities.GetId(Candidate.Trump) + "')]");
                        if( rowDate != null )
                            republicanPollValue = float.Parse(rowDate.InnerText.Trim().Replace("%", ""));

                        StatesPollData statesPollData = new()
                        {
                            Date = dt,
                            State = state,
                            Source = poll_src.InnerText.Trim(),
                            DemocratPollPercentage = democratPollValue,
                            RepublicanPollPercentage = republicanPollValue
                        };
                        statesPollDataList.Add(statesPollData);
                    }
                }

            }

            return statesPollDataList;

        }


        /*
        public class PollData(string state, DateTime lastPollingDate, float democratPoll, float republicanPoll, bool bidenPoll = false, bool oldPoll = false)
        {
            //public PollData(string state, float democratePoll, float republicanPoll)
            //{
            //    State = state;
            //    DemocratePoll = democratePoll;
            //    RepublicanPoll = republicanPoll;
            //}

            public string State { get; } = state;
            public DateTime LastPollingDate { get; } = lastPollingDate;
            public float DemocratPollPercentage { get; } = democratPoll;
            public float RepublicanPollPercentage { get; } = republicanPoll;
            public bool BidenPoll { get; } = bidenPoll;
            public bool OldPoll { get; } = oldPoll;
        }
        */

        private static HtmlNode? GetTable(HtmlAgilityPack.HtmlDocument document)
        {
            HtmlNode ge = document.GetElementbyId("GE");
            if( ge == null ) return null;
            //fuck:
            HtmlNode table = ge.SelectSingleNode("div/div/table[contains(@id, 'polls')]");
            //return table;

            //goto fuck;

            return table;

        }
#if depp
        private static HtmlNode? GetTable(HtmlAgilityPack.HtmlDocument document, string h6Text)
        {
            HtmlNodeCollection h6s = document.DocumentNode.SelectNodes("//h6[contains(., '" + h6Text + "')]");
            if( h6s == null || h6s.Count == 0 ) return null;
            HtmlNode h6 = h6s[0];

            //if( table != null ) break;
            //HtmlNode? sibling = h6.NextSibling;
            HtmlNode? sibling = h6.ParentNode;
            do
            {
                if( sibling == null ) break;
                if( sibling.Name.ToLower().Equals("p") && sibling.InnerText.Equals("No Polls Available") ) return null;

                if( sibling.Name.ToLower().Equals("div") )
                {
                    //table = sibling.SelectSingleNode("div/table");
                    HtmlNode? table = sibling.SelectSingleNode("div/table[contains(@id, 'polls')]");

                    if( table != null )
                        return table;

                }
                sibling = sibling.NextSibling;
                //
            }
            while( sibling != null );

            //goto again;

            return null;

        }
#endif
    }

}
