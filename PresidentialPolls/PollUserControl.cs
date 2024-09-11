namespace PresidentialPolls
{
    public partial class PollUserControl : UserControl
    {
        public PollUserControl()
        {
            InitializeComponent();

            pollWebView.NewPollData += (newPollData) =>
            {
                groupBoxExNumberOfStates.Value = newPollData.NumberOfStates.ToString();

                groupBoxExDemocrats.Value = newPollData.TotalDemocrat.ToString();
                groupBoxExRepublican.Value = newPollData.TotalRepublican.ToString();

                groupBoxExBattleGroundDem.Value = newPollData.BattleGroundDemocrats.ToString();
                groupBoxExBattleGroundRep.Value = newPollData.BattleGroundRepublican.ToString();

            };

        }

        private void ButtonReload_Click(object sender, EventArgs e)
        {
            groupBoxExRepublican.Value = string.Empty;
            groupBoxExDemocrats.Value = string.Empty;
            //pollWebView.Reload();

            this.pollWebView.CoreWebView2.Navigate(PollWebView.MainUrl);// @"https://www.270towin.com/2024-presidential-election-polls/"

        }
    }
}
