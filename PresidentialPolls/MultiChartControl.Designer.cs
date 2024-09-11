namespace PresidentialPolls
{
    partial class MultiChartControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel = new TableLayoutPanel();
            flowLayoutPanelCharts = new FlowLayoutPanelCharts();
            panelTop = new PanelTop();
            flowLayoutPanelStats = new FlowLayoutPanel();
            groupBoxExElectoralVotes = new ATS_Form.Controls.GroupBoxEx();
            groupBoxExElectoralVotesDemocart = new ATS_Form.Controls.GroupBoxEx();
            groupBoxExElectoralVotesRepublican = new ATS_Form.Controls.GroupBoxEx();
            tableLayoutPanel.SuspendLayout();
            panelTop.SuspendLayout();
            flowLayoutPanelStats.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(flowLayoutPanelCharts, 0, 1);
            tableLayoutPanel.Controls.Add(panelTop, 0, 0);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 75F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Size = new Size(706, 523);
            tableLayoutPanel.TabIndex = 0;
            // 
            // flowLayoutPanelCharts
            // 
            flowLayoutPanelCharts.AutoScroll = true;
            flowLayoutPanelCharts.Dock = DockStyle.Fill;
            flowLayoutPanelCharts.Location = new Point(3, 78);
            flowLayoutPanelCharts.Name = "flowLayoutPanelCharts";
            flowLayoutPanelCharts.Size = new Size(700, 442);
            flowLayoutPanelCharts.TabIndex = 4;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(flowLayoutPanelStats);
            panelTop.Dock = DockStyle.Fill;
            panelTop.Location = new Point(3, 3);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(700, 69);
            panelTop.TabIndex = 3;
            // 
            // flowLayoutPanelStats
            // 
            flowLayoutPanelStats.Controls.Add(groupBoxExElectoralVotes);
            flowLayoutPanelStats.Controls.Add(groupBoxExElectoralVotesDemocart);
            flowLayoutPanelStats.Controls.Add(groupBoxExElectoralVotesRepublican);
            flowLayoutPanelStats.Location = new Point(67, 7);
            flowLayoutPanelStats.Name = "flowLayoutPanelStats";
            flowLayoutPanelStats.Size = new Size(385, 55);
            flowLayoutPanelStats.TabIndex = 1;
            // 
            // groupBoxExElectoralVotes
            // 
            groupBoxExElectoralVotes.CaptionText = "Electoral Votes";
            groupBoxExElectoralVotes.Location = new Point(3, 3);
            groupBoxExElectoralVotes.Name = "groupBoxExElectoralVotes";
            groupBoxExElectoralVotes.Size = new Size(122, 47);
            groupBoxExElectoralVotes.TabIndex = 0;
            groupBoxExElectoralVotes.ValueBackColor = SystemColors.Control;
            groupBoxExElectoralVotes.ValueForeColor = SystemColors.ControlText;
            // 
            // groupBoxExElectoralVotesDemocart
            // 
            groupBoxExElectoralVotesDemocart.CaptionText = "Democart Votes";
            groupBoxExElectoralVotesDemocart.Location = new Point(131, 3);
            groupBoxExElectoralVotesDemocart.Name = "groupBoxExElectoralVotesDemocart";
            groupBoxExElectoralVotesDemocart.Size = new Size(122, 47);
            groupBoxExElectoralVotesDemocart.TabIndex = 1;
            groupBoxExElectoralVotesDemocart.ValueBackColor = SystemColors.Control;
            groupBoxExElectoralVotesDemocart.ValueForeColor = SystemColors.ControlText;
            // 
            // groupBoxExElectoralVoteRep
            // 
            groupBoxExElectoralVotesRepublican.CaptionText = "Repulican Votes";
            groupBoxExElectoralVotesRepublican.Location = new Point(259, 3);
            groupBoxExElectoralVotesRepublican.Name = "groupBoxExElectoralVotesRepublican";
            groupBoxExElectoralVotesRepublican.Size = new Size(122, 47);
            groupBoxExElectoralVotesRepublican.TabIndex = 2;
            groupBoxExElectoralVotesRepublican.ValueBackColor = SystemColors.Control;
            groupBoxExElectoralVotesRepublican.ValueForeColor = SystemColors.ControlText;
            // 
            // GroupingUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel);
            Name = "GroupingUserControl";
            Size = new Size(706, 523);
            //Resize += GroupingUserControl_Resize;
            tableLayoutPanel.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            flowLayoutPanelStats.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private PanelTop panelTop;
        private FlowLayoutPanel flowLayoutPanelStats;
        private ATS_Form.Controls.GroupBoxEx groupBoxExElectoralVotes;
        private ATS_Form.Controls.GroupBoxEx groupBoxExElectoralVotesDemocart;
        private ATS_Form.Controls.GroupBoxEx groupBoxExElectoralVotesRepublican;
        private FlowLayoutPanelCharts flowLayoutPanelCharts;
    }

    public class PanelTop : Panel
    {
        public PanelTop()
        {
            this.Resize += (sender, e) =>
            {
                if( this.Controls .Count==1)
                    this.Controls[0].Left= (this.Width - this.Padding.Horizontal - this.Controls[0].Width - this.Controls[0].Margin.Horizontal ) / 2;
            };
        }

    }

    public class FlowLayoutPanelCharts : FlowLayoutPanel
    {
        public FlowLayoutPanelCharts()
        {
            this.Resize += (sender, e) =>
            {
                foreach( Control control in this.Controls )
                    control.Width = ( this.Width - this.Padding.Horizontal - control.Margin.Horizontal - 10 ) / 2 - 7;
            };
        }

    }

}
