namespace PresidentialPolls
{
    public partial class MultiChartControl : UserControl
    {
        private int democratElectoralVotes;
        private int republicanElectoralVotes;

        public MultiChartControl()
        {
            InitializeComponent();

        }

        internal void Add(ChartUserControl chartUserControl)
        {
            chartUserControl.Width =
                ( flowLayoutPanelCharts.Width - flowLayoutPanelCharts.Padding.Horizontal - chartUserControl.Margin.Horizontal - 15 ) / 2;

            flowLayoutPanelCharts.Controls.Add(chartUserControl);

            if( chartUserControl.Party == Model.Party.Democrat )
                democratElectoralVotes += chartUserControl.ElectoralVotes;
            else if( chartUserControl.Party == Model.Party.Republican )
                republicanElectoralVotes += chartUserControl.ElectoralVotes;

            groupBoxExElectoralVotes.Value = ( democratElectoralVotes + republicanElectoralVotes ).ToString();
            groupBoxExElectoralVotesDemocart.Value = democratElectoralVotes.ToString();
            groupBoxExElectoralVotesRepublican.Value = republicanElectoralVotes.ToString();

        }

        internal void ClearAllData()
        {
            this.groupBoxExElectoralVotes.Value = string.Empty;
            this.groupBoxExElectoralVotesDemocart.Value = string.Empty;
            this.groupBoxExElectoralVotesRepublican.Value = string.Empty;

            this.flowLayoutPanelCharts.Controls.Clear();

            democratElectoralVotes = 0;
            republicanElectoralVotes = 0;
        }

        //private void GroupingUserControl_Resize(object sender, EventArgs e)
        //{

        //}
    }
}
