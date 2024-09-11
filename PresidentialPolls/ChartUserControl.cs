using PresidentialPolls.Model;
using ScottPlot;

namespace PresidentialPolls
{
    public partial class ChartUserControl : UserControl
    {
        readonly Model.Model? model;
        bool singleDisplay = true;
        readonly SortedDictionary<DateTime, CalendarEvent>? calendarEvents;


        public int ElectoralVotes { get; private set; }

        public Model.Party Party { get; private set; }

        public ChartUserControl()
        {
            InitializeComponent();

        }

        public ChartUserControl(Model.Model model)
        {
            ArgumentNullException.ThrowIfNull(model);
            this.model = model;
            //singleDisplay = false;

            InitializeComponent();
            comboBoxStates.Visible = singleDisplay;

            comboBoxStates.DisplayMember = Name;
            comboBoxStates.DataSource = model.States;

            this.calendarEvents = model.CalendarEvents;
        }

        public string SetState
        {
            set
            {
                comboBoxStates.SelectedIndex = comboBoxStates.FindStringExact(value);
            }
        }
        public bool SingleDisplay
        {
            set
            {
                singleDisplay = value; comboBoxStates.Visible = singleDisplay;
                if( !singleDisplay )
                {
                    if( this.panel == null ) return;
                    if( this.panel.Parent == null ) return;
                    this.panel.Parent.Controls.Remove(this.panel);
                    if( tableLayoutPanel.RowCount == 3 )
                        this.tableLayoutPanel.RowCount = 2;
                }
            }
        }

        private void ChartUserControl_Resize(object sender, EventArgs e)
        {
            if( comboBoxStates.Parent != null )
                this.comboBoxStates.Left = ( comboBoxStates.Parent.Width - comboBoxStates.Width ) / 2;
            //this.comboBoxStates.Left = ( panel.Width - comboBoxStates.Width ) / 2;
            if( panelAllValues.Parent != null )
                this.panelAllValues.Left = ( panelAllValues.Parent.Width - panelAllValues.Width ) / 2;
        }

        private void ChartUserControl_DoubleClick(object sender, EventArgs e)
        {
            ComboBoxStates_SelectedIndexChanged(sender, e);
        }

        private void ComboBoxStates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( model == null ) return;
            if( comboBoxStates.SelectedItem == null ) return;

            object? item = comboBoxStates.SelectedItem;
            if( item == null ) return;
            State state = (State)item;
            if( state.Name == null ) return;

            this.ElectoralVotes = state.ElectoralVotes;
            groupBox.Text = state.Name;


            formsPlot.Plot.Clear();
            pictureBoxLogo.Image = null;

            ScottPlot.PixelPadding pixelPadding = new(30);
            formsPlot.Plot.Layout.Fixed(pixelPadding);

            PlotData? plotData = model.GetPlotDataByState(state.Name);
            if( plotData != null )
            {
                double[] dates = plotData.DemPartyData.RawData.Keys.Select(x => x.ToOADate()).ToArray();
                SortedDictionary<DateTime, double> democraticData = plotData.DemPartyData.RawData;
                SortedDictionary<DateTime, double> republicanData = plotData.RepPartyData.RawData;
                SortedDictionary<DateTime, double> otherData;
                if( plotData.DemPartyData.SmoothedData.Count > 0 )
                {
                    democraticData = plotData.DemPartyData.SmoothedData;
                    republicanData = plotData.RepPartyData.SmoothedData;

                    otherData = plotData.OtherPartyData.SmoothedData;

                    dates = plotData.DemPartyData.SmoothedData.Keys.Select(x => x.ToOADate()).ToArray();
                }
                else
                    otherData = plotData.OtherPartyData.RawData;


                if( plotData.DemPartyData.RawData.Count > 0 && plotData.RepPartyData.RawData.Count > 0 )// keep as is
                {
                    ScottPlot.Plot plot = new();

                    ScottPlot.PieSlice demRawSlice = new() { LabelText = ( democraticData.Values.Last() / 100 ).ToString("P"), Value = democraticData.Values.Last(), FillColor = ScottPlot.Color.FromColor(plotData.DemPartyData.Color) };
                    ScottPlot.PieSlice repRawSlice = new() { LabelText = ( republicanData.Values.Last() / 100 ).ToString("P"), Value = republicanData.Values.Last(), FillColor = ScottPlot.Color.FromColor(plotData.RepPartyData.Color) };

                    List<ScottPlot.PieSlice>? slices = [repRawSlice, demRawSlice];


                    // setup the pie to display slice labels
                    var pie = plot.Add.Pie(slices);
                    pie.ExplodeFraction = .1;
                    pie.ShowSliceLabels = true;
                    pie.SliceLabelDistance = 1.3;

                    // styling can be customized for individual slices
                    demRawSlice.LabelStyle.FontSize = 48;
                    repRawSlice.LabelStyle.FontSize = 64;

                    plot.Legend.FontSize = 22;
                    //plot.SavePng("demo.png", 400, 300);
                    using var ms = new MemoryStream(plot.GetImageBytes(Width, Height));
                    pictureBoxLogo.Image = System.Drawing.Image.FromStream(ms);

                }

                bool drawEventLine = true;//true false
                if( drawEventLine )
                {
                    if( calendarEvents != null )
                    {
                        int counter = 0;
                        foreach( var calendarEvent in calendarEvents )
                        {
                            //DateTime dt = new DateTime(2024, 9, 10).Date;
                            var debateDay = calendarEvent.Key.ToOADate();
                            var axLine1 = formsPlot.Plot.Add.VerticalLine(debateDay);
                            axLine1.Text = calendarEvent.Value.Name;
                            axLine1.LabelFontColor = ScottPlot.Colors.White;
                            axLine1.LabelFontSize = 9;
                            axLine1.Color = ScottPlot.Color.FromColor(calendarEvent.Value.Color);
                            if( counter++ % 2 == 0 )
                            {
                                axLine1.LabelOppositeAxis = true;
                                axLine1.LabelOffsetY = 33;
                            }
                            else
                                axLine1.LabelOffsetY = -33;
                        }
                        if( calendarEvents.Count > 0 )
                            formsPlot.Plot.Axes.Right.Range.Max = calendarEvents.Keys.Max().ToOADate();
                    }
                }


                ScottPlot.Plottables.Scatter demPlot = formsPlot.Plot.Add.Scatter(dates, [.. democraticData.Values], ScottPlot.Color.FromColor(plotData.DemPartyData.Color));
                ScottPlot.Plottables.Scatter repPlot = formsPlot.Plot.Add.Scatter(dates, [.. republicanData.Values], ScottPlot.Color.FromColor(plotData.RepPartyData.Color));

                ScottPlot.Plottables.Scatter otherPlot = formsPlot.Plot.Add.Scatter(dates, [.. otherData.Values], ScottPlot.Color.FromColor(plotData.OtherPartyData.Color));

                formsPlot.Plot.Axes.DateTimeTicksBottom();


                var demMax = democraticData.Values.Max();
                var demMin = democraticData.Values.Min();

                var repMax = republicanData.Values.Max();
                var repMin = republicanData.Values.Min();

                float max = 100;
                if( demMax <= repMax )
                    max = (float)( repMax + 10 );
                else if( demMax > repMax )
                    max = (float)demMax + 10;

                if( max == 10 )
                    max = 100;

                float min = 0;
                if( demMin >= repMin )
                    min = (float)( repMin - 10 );
                else if( demMin < repMin )
                    min = (float)( demMin - 10 );

                if( min == -10 )
                    min = 0;

                if( demMin == 0 || repMin == 0 )
                    min = 0;


                formsPlot.Plot.Axes.Left.Range.Max = (double)max;
                //formsPlot.Plot.Axes.Left.Range.Min = (double)min;


                ////formsPlot.Plot.Axes.Left.Range.Max = 100;
                formsPlot.Plot.Axes.Left.Range.Min = 0;



                //demPlot.Axes.YAxis = formsPlot.Plot.Axes.Left;
                //repPlot.Axes.YAxis = formsPlot.Plot.Axes.Right;



                if( democraticData.Count > 0 && republicanData.Count > 0 )
                {
                    if( democraticData.Count > 1 && republicanData.Count > 1 )
                    {
                        bool regressionLine = false;//true 
                        if( regressionLine )
                        {
                            demPlot.LineWidth = 0;
                            demPlot.MarkerSize = 10;

                            ScottPlot.Statistics.LinearRegression reg = new(dates, [.. republicanData.Values]);
                            Coordinates pt1 = new(dates.First(), reg.GetValue(dates.First()));
                            Coordinates pt2 = new(dates.Last(), reg.GetValue(dates.Last()));
                            var line = formsPlot.Plot.Add.Line(pt1, pt2);
                            line.MarkerSize = 0;
                            line.LineWidth = 2;
                            line.LinePattern = LinePattern.Dashed;

                            // note the formula at the top of the plot
                            formsPlot.Plot.Title(reg.FormulaWithRSquared);
                        }
                    }



                    ScottPlot.Color color = ScottPlot.Color.FromColor(plotData.DemPartyData.Color);
                    string margin = ( Math.Abs(democraticData.Values.Last() - republicanData.Values.Last()) ).ToString("n2");

                    this.Party = Party.None;
                    string value = "Tie, no votes awarded";// "Democrat : " + ( data.DemPartyData.Data[data.DemPartyData.Data.Count - 1] / 100 ).ToString("P");
                    color = ScottPlot.Colors.Black;


                    if( democraticData.Last().Value < republicanData.Last().Value )
                    {
                        this.Party = Party.Republican;
                        color = ScottPlot.Color.FromColor(plotData.RepPartyData.Color);
                        value = "Republican: " + ( republicanData.Last().Value / 100 ).ToString("P");
                    }

                    else if( democraticData.Last().Value > republicanData.Last().Value )
                    {
                        this.Party = Party.Democrat;
                        color = ScottPlot.Color.FromColor(plotData.DemPartyData.Color);
                        value = "Democrat: " + ( democraticData.Last().Value / 100 ).ToString("P");
                    }

                    else
                    {
                    }


                    value += "\nMargin: " + margin;
                    value += "\nElectoralVotes: " + this.ElectoralVotes;

                    var anno = formsPlot.Plot.Add.Annotation(value);
                    anno.LabelFontSize = 32;
                    if( !singleDisplay )
                        anno.LabelFontSize = 12;
                    anno.LabelFontName = ScottPlot.Fonts.Sans;
                    anno.LabelBackgroundColor = ScottPlot.Colors.White.WithAlpha(.3);
                    anno.LabelFontColor = color;
                    anno.LabelBorderColor = ScottPlot.Colors.Black;
                    anno.LabelBorderWidth = 1;
                    anno.LabelShadowColor = ScottPlot.Colors.Transparent;
                    anno.OffsetY = 40;
                    anno.OffsetX = 20;

                }

                SetValues(plotData.DemPartyData, plotData.RepPartyData, groupBoxExDemocratScore, groupBoxExDemocratTrend);
                SetValues(plotData.RepPartyData, plotData.DemPartyData, groupBoxExRepublicanScore, groupBoxExRepublicanTrend);


                formsPlot.Refresh();
                //
            }
            /*
            if( plotData != null )
            {
                //SetValues(plotData.DemPartyData, plotData.RepPartyData, groupBoxExDemocratScore, groupBoxExDemocratTrend);
                //SetValues(plotData.RepPartyData, plotData.DemPartyData, groupBoxExRepublicanScore, groupBoxExRepublicanTrend);
            }
            */
        }


        public static void SetValues(Model.PartyData partyData, Model.PartyData otherPartyData, ATS_Form.Controls.GroupBoxEx groupBoxScore, ATS_Form.Controls.GroupBoxEx groupBoxTrend)
        {
            if( partyData == null ) return;
            if( partyData.RawData == null ) return;

            SortedDictionary<DateTime, double> dataToUse = partyData.RawData;
            SortedDictionary<DateTime, double> otherdataToUse = otherPartyData.RawData;

            if( partyData.SmoothedData.Count > 0 )
            {
                dataToUse = partyData.SmoothedData;
                otherdataToUse = otherPartyData.SmoothedData;
            }

            groupBoxScore.ValueBackColor = SystemColors.Control;
            groupBoxScore.ValueForeColor = SystemColors.ControlText;
            groupBoxTrend.ValueBackColor = SystemColors.Control;
            groupBoxTrend.ValueForeColor = SystemColors.ControlText;


            if( dataToUse.Count == 0 )
                groupBoxScore.Value = "0%";
            else
                groupBoxScore.Value = ( dataToUse.Values.Last() / 100 ).ToString("P");

            if( dataToUse.Count != 0 && otherdataToUse.Count != 0 )
            {
                if( dataToUse.Values.Last() > otherdataToUse.Values.Last() )
                {
                    groupBoxScore.ValueForeColor = partyData.Color;
                    groupBoxScore.ValueBackColor = System.Drawing.Color.White;
                }
                else
                {
                    groupBoxScore.ValueBackColor = SystemColors.Control;
                    groupBoxScore.ValueForeColor = SystemColors.ControlText;
                }
            }
            else
            {
                groupBoxScore.ValueBackColor = SystemColors.Control;
                groupBoxScore.ValueForeColor = SystemColors.ControlText;
            }

            if( dataToUse.Count > 2 )
            {
                double diff = ScoreDiff([.. dataToUse.Values]);
                groupBoxTrend.Value = diff.ToString("n2");
                if( diff > 0 )
                {
                    groupBoxTrend.ValueForeColor = System.Drawing.Color.Blue;// partyData.Color;
                    groupBoxTrend.ValueBackColor = System.Drawing.Color.White;
                }
                else if( diff < 0 )
                {
                    groupBoxTrend.ValueForeColor = System.Drawing.Color.Red;//.LightGoldenrodYellow;
                    groupBoxTrend.ValueBackColor = System.Drawing.Color.White;
                }

                else
                {
                    groupBoxTrend.ValueBackColor = SystemColors.Control;
                    groupBoxTrend.ValueForeColor = SystemColors.ControlText;
                }

            }

        }

        private static double ScoreDiff(IList<double> partyData)
        {
            var demReversed = partyData.Reverse();
            double firstDem = demReversed.First();
            double secondDem = demReversed.Skip(1).Take(1).First();

            return firstDem - secondDem;

        }

    }

}
