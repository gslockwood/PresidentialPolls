using HtmlAgilityPack;
using PresidentialPolls.Model;
using System.Text.RegularExpressions;

namespace PresidentialPolls
{
    public partial class PollWebView : Microsoft.Web.WebView2.WinForms.WebView2
    {
        public delegate void PollDataEventHandler(PollDataPackage pollDataPackage);
        public event PollDataEventHandler? NewPollData;

        readonly List<String> battleGroundStates = [];

        public static string MainUrl { get { return @"https://www.270towin.com/2024-presidential-election-polls/"; } }

        public PollWebView()
        {
            battleGroundStates.Add("Arizona");
            battleGroundStates.Add("Georgia");
            battleGroundStates.Add("Michigan");
            battleGroundStates.Add("Nevada");
            battleGroundStates.Add("North Carolina");
            battleGroundStates.Add("Pennsylvania");
            battleGroundStates.Add("Wisconsin");

            this.CoreWebView2InitializationCompleted += (s, e) =>
            {
                this.CoreWebView2.Navigate(MainUrl);
            };

            this.NavigationCompleted += PollWebView_NavigationCompleted;

        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        private async void PollWebView_NavigationCompleted(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs? e)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            if( e == null || !e.IsSuccess ) return;

            //if( e.HttpStatusCode == 200 )
            //    await Process();
        }

        private async Task Process()
        {
            string? html = await CleanupHtml();

            if( html == null ) return;

            HtmlAgilityPack.HtmlDocument document = new();
            document.LoadHtml(html);
            /*
            HtmlNode polls_pies = document.GetElementbyId("polls-pies");
            if( polls_pies == null ) return;

            //main-content
            HtmlNode main_content = document.GetElementbyId("main-content");
            if( main_content == null ) return;

            HtmlNode row = document.DocumentNode.SelectSingleNode("//div[contains(@class, 'row')]");
            if( row == null ) return;

            row.RemoveAllChildren();
            //row.ChildNodes.Clear();
            row.ChildNodes.Add(polls_pies);
            NavigateToString(document.DocumentNode.InnerHtml);
            */

            //again:

            int numberOfStates = 0;

            int totalDemocrats = 0;
            int totalRepublican = 0;

            int battleGroundDemocrats = 0;
            int battleGroundRepublican = 0;

            bool isBattleGroundState = false;

            //div state_name    <a href="/states/Pennsylvania" target="_blank" class="font-weight-bold">Pennsylvania</a>
            HtmlNodeCollection nodeCollection = document.DocumentNode.SelectNodes("//div[contains(@class, 'state_name')]");
            if( nodeCollection != null && nodeCollection.Count > 0 )
            {
                foreach( HtmlNode node in nodeCollection )
                {
                    //Party party = Party.Other;

                    string stateName = node.InnerText;
                    //string stateTotalDelegates = "0";
                    string statePoll_margin = "0";

                    int stateElectoralVotes = 0;
                    Match match = digits().Match(stateName);
                    if( match.Success )
                    {
                        stateName = stateName.Split('(')[0].Trim();
                        stateElectoralVotes = Convert.ToInt32(match.Groups[0].Value);

                        isBattleGroundState = battleGroundStates.Any(x => x.Equals(stateName));

                    }
                    else
                        continue;

                    //dailyDatas.Add(new DailyData(stateName, stateElectoralVotes));

                    numberOfStates++;

                    if( node.NextSibling != null )
                    {
                        HtmlNode nextSibling = node.ParentNode;
                        if( nextSibling != null )
                        {
                            HtmlNode poll_margin = nextSibling.SelectSingleNode("div/div[contains(@class, 'poll_margin')]");
                            if( poll_margin != null )
                            {
                                statePoll_margin = poll_margin.InnerText.Trim();
                                if( statePoll_margin.Contains(Candidate.Harris.ToString()) )
                                {
                                    //party = Party.Democrats;
                                    totalDemocrats += stateElectoralVotes;

                                    if( isBattleGroundState )
                                        battleGroundDemocrats += stateElectoralVotes;
                                }
                                else if( statePoll_margin.Contains(Candidate.Trump.ToString()) )
                                {
                                    //party = Party.Republican;
                                    totalRepublican += stateElectoralVotes;

                                    if( isBattleGroundState )
                                        battleGroundRepublican += stateElectoralVotes;

                                }
                                //
                            }
                        }
                    }

                    System.Diagnostics.Debug.WriteLine($"State={stateName}\t\t\t\tElectoralVotes={stateElectoralVotes}\t\tPoll margin={statePoll_margin}");

                }
                System.Diagnostics.Debug.WriteLine($"totalDemocrats={totalDemocrats} totalRepublican={totalRepublican}");

                PollDataPackage pollDataPackage = new(numberOfStates, totalDemocrats, totalRepublican, battleGroundDemocrats, battleGroundRepublican);

                NewPollData?.Invoke(pollDataPackage);
                //
            }

            //goto again;

            //
        }

        public class PollDataPackage(int numberOfStates, int totalDemocrats, int totalRepublican, int battleGroundDemocrats, int battleGroundRepublican)
        {
            public int NumberOfStates { get; } = numberOfStates;
            public int TotalDemocrat { get; } = totalDemocrats;
            public int TotalRepublican { get; } = totalRepublican;

            public int BattleGroundDemocrats { get; } = battleGroundDemocrats;
            public int BattleGroundRepublican { get; } = battleGroundRepublican;

        }


        private async Task<string?> CleanupHtml()
        {
            //if( webView2 == null )
            //    return null;

            string html = await ExecuteScriptAsync("document.documentElement.outerHTML;");
            if( html == null )
                return string.Empty;

            // clean up
            html = Regex.Unescape(html);
            //html = System.Web.HttpUtility.HtmlDecode(html);
            html = System.Net.WebUtility.HtmlDecode(html);

            // html = html.Substring( 1, html.Length - 2 );
            html = html[1..^1];

            if( html.IndexOf(@"\\&quot;") > -1 )
                html = html.Replace("\\&quot;", "'");
            if( html.IndexOf(@"&quot;") > -1 )
                html = html.Replace(@"&quot;", "'");

            //logger.Info(html);


            return html;

        }

        [GeneratedRegex(@"(\d+)")]
        private static partial Regex digits();
    }

}
