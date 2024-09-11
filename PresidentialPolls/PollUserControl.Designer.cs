using HtmlAgilityPack;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace PresidentialPolls
{
    partial class PollUserControl
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
            pollWebView = new PollWebView();
            flowLayoutPanelBottom = new FlowLayoutPanel();
            buttonReload = new Button();
            tableLayoutPanelData = new TableLayoutPanel();
            panelPollData = new FlowLayoutPanel();
            groupBoxExNumberOfStates = new ATS_Form.Controls.GroupBoxEx();
            groupBoxOverall = new GroupBox();
            flowLayoutPanelOverall = new FlowLayoutPanel();
            groupBoxExDemocrats = new ATS_Form.Controls.GroupBoxEx();
            groupBoxExRepublican = new ATS_Form.Controls.GroupBoxEx();
            groupBoxBattleGround = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            groupBoxExBattleGroundDem = new ATS_Form.Controls.GroupBoxEx();
            groupBoxExBattleGroundRep = new ATS_Form.Controls.GroupBoxEx();
            ( (System.ComponentModel.ISupportInitialize)pollWebView ).BeginInit();
            flowLayoutPanelBottom.SuspendLayout();
            tableLayoutPanelData.SuspendLayout();
            panelPollData.SuspendLayout();
            groupBoxOverall.SuspendLayout();
            flowLayoutPanelOverall.SuspendLayout();
            groupBoxBattleGround.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pollWebView
            // 
            pollWebView.AllowExternalDrop = true;
            pollWebView.CreationProperties = null;
            pollWebView.DefaultBackgroundColor = Color.White;
            pollWebView.Dock = DockStyle.Fill;
            pollWebView.Location = new Point(3, 3);
            pollWebView.Name = "pollWebView";
            pollWebView.Size = new Size(894, 753);
            pollWebView.Source = new Uri("https://www.270towin.com/2024-presidential-election-polls/", UriKind.Absolute);
            pollWebView.TabIndex = 0;
            pollWebView.ZoomFactor = 1D;
            // 
            // flowLayoutPanelBottom
            // 
            flowLayoutPanelBottom.Controls.Add(buttonReload);
            flowLayoutPanelBottom.Dock = DockStyle.Bottom;
            flowLayoutPanelBottom.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanelBottom.Location = new Point(0, 858);
            flowLayoutPanelBottom.Name = "flowLayoutPanelBottom";
            flowLayoutPanelBottom.Size = new Size(915, 28);
            flowLayoutPanelBottom.TabIndex = 1;
            // 
            // buttonReload
            // 
            buttonReload.Location = new Point(837, 3);
            buttonReload.Name = "buttonReload";
            buttonReload.Size = new Size(75, 23);
            buttonReload.TabIndex = 0;
            buttonReload.Text = "Reload";
            buttonReload.UseVisualStyleBackColor = true;
            buttonReload.Click +=  ButtonReload_Click ;
            // 
            // tableLayoutPanelData
            // 
            tableLayoutPanelData.Anchor =    AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left   |  AnchorStyles.Right ;
            tableLayoutPanelData.ColumnCount = 1;
            tableLayoutPanelData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelData.Controls.Add(pollWebView, 0, 0);
            tableLayoutPanelData.Controls.Add(panelPollData, 0, 1);
            tableLayoutPanelData.Location = new Point(12, 3);
            tableLayoutPanelData.Name = "tableLayoutPanelData";
            tableLayoutPanelData.RowCount = 2;
            tableLayoutPanelData.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelData.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            tableLayoutPanelData.Size = new Size(900, 849);
            tableLayoutPanelData.TabIndex = 2;
            // 
            // panelPollData
            // 
            panelPollData.Controls.Add(groupBoxExNumberOfStates);
            panelPollData.Controls.Add(groupBoxOverall);
            panelPollData.Controls.Add(groupBoxBattleGround);
            panelPollData.Dock = DockStyle.Fill;
            panelPollData.Location = new Point(3, 762);
            panelPollData.Name = "panelPollData";
            panelPollData.Size = new Size(894, 84);
            panelPollData.TabIndex = 1;
            // 
            // groupBoxExNumberOfStates
            // 
            groupBoxExNumberOfStates.CaptionText = "Number Of States";
            groupBoxExNumberOfStates.Location = new Point(3, 26);
            groupBoxExNumberOfStates.Margin = new Padding(3, 26, 3, 3);
            groupBoxExNumberOfStates.Name = "groupBoxExNumberOfStates";
            groupBoxExNumberOfStates.Size = new Size(115, 49);
            groupBoxExNumberOfStates.TabIndex = 2;
            // 
            // groupBoxOverall
            // 
            groupBoxOverall.Controls.Add(flowLayoutPanelOverall);
            groupBoxOverall.Location = new Point(124, 3);
            groupBoxOverall.Name = "groupBoxOverall";
            groupBoxOverall.Size = new Size(190, 79);
            groupBoxOverall.TabIndex = 4;
            groupBoxOverall.TabStop = false;
            groupBoxOverall.Text = "Overall";
            // 
            // flowLayoutPanelOverall
            // 
            flowLayoutPanelOverall.Controls.Add(groupBoxExDemocrats);
            flowLayoutPanelOverall.Controls.Add(groupBoxExRepublican);
            flowLayoutPanelOverall.Dock = DockStyle.Fill;
            flowLayoutPanelOverall.Location = new Point(3, 19);
            flowLayoutPanelOverall.Name = "flowLayoutPanelOverall";
            flowLayoutPanelOverall.Size = new Size(184, 57);
            flowLayoutPanelOverall.TabIndex = 3;
            // 
            // groupBoxExDemocrats
            // 
            groupBoxExDemocrats.CaptionText = "Democrats";
            groupBoxExDemocrats.Location = new Point(3, 3);
            groupBoxExDemocrats.Name = "groupBoxExDemocrats";
            groupBoxExDemocrats.Size = new Size(84, 49);
            groupBoxExDemocrats.TabIndex = 1;
            // 
            // groupBoxExRepublican
            // 
            groupBoxExRepublican.CaptionText = "Republican";
            groupBoxExRepublican.Location = new Point(93, 3);
            groupBoxExRepublican.Name = "groupBoxExRepublican";
            groupBoxExRepublican.Size = new Size(84, 49);
            groupBoxExRepublican.TabIndex = 0;
            // 
            // groupBoxBattleGround
            // 
            groupBoxBattleGround.Controls.Add(flowLayoutPanel1);
            groupBoxBattleGround.Location = new Point(320, 3);
            groupBoxBattleGround.Name = "groupBoxBattleGround";
            groupBoxBattleGround.Size = new Size(190, 79);
            groupBoxBattleGround.TabIndex = 5;
            groupBoxBattleGround.TabStop = false;
            groupBoxBattleGround.Text = "BattleGround";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(groupBoxExBattleGroundDem);
            flowLayoutPanel1.Controls.Add(groupBoxExBattleGroundRep);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 19);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(184, 57);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // groupBoxExBattleGroundDem
            // 
            groupBoxExBattleGroundDem.CaptionText = "Democrat";
            groupBoxExBattleGroundDem.Location = new Point(3, 3);
            groupBoxExBattleGroundDem.Name = "groupBoxExBattleGroundDem";
            groupBoxExBattleGroundDem.Size = new Size(84, 49);
            groupBoxExBattleGroundDem.TabIndex = 1;
            // 
            // groupBoxExBattleGroundRep
            // 
            groupBoxExBattleGroundRep.CaptionText = "Republican";
            groupBoxExBattleGroundRep.Location = new Point(93, 3);
            groupBoxExBattleGroundRep.Name = "groupBoxExBattleGroundRep";
            groupBoxExBattleGroundRep.Size = new Size(84, 49);
            groupBoxExBattleGroundRep.TabIndex = 0;
            // 
            // PollUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanelData);
            Controls.Add(flowLayoutPanelBottom);
            Name = "PollUserControl";
            Size = new Size(915, 886);
            ( (System.ComponentModel.ISupportInitialize)pollWebView ).EndInit();
            flowLayoutPanelBottom.ResumeLayout(false);
            tableLayoutPanelData.ResumeLayout(false);
            panelPollData.ResumeLayout(false);
            groupBoxOverall.ResumeLayout(false);
            flowLayoutPanelOverall.ResumeLayout(false);
            groupBoxBattleGround.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PollWebView pollWebView;
        private FlowLayoutPanel flowLayoutPanelBottom;
        private Button buttonReload;
        private TableLayoutPanel tableLayoutPanelData;
        private FlowLayoutPanel panelPollData;
        private ATS_Form.Controls.GroupBoxEx groupBoxExDemocrats;
        private ATS_Form.Controls.GroupBoxEx groupBoxExRepublican;
        private ATS_Form.Controls.GroupBoxEx groupBoxExNumberOfStates;
        private GroupBox groupBoxOverall;
        private FlowLayoutPanel flowLayoutPanelOverall;
        private GroupBox groupBoxBattleGround;
        private FlowLayoutPanel flowLayoutPanel1;
        private ATS_Form.Controls.GroupBoxEx groupBoxExBattleGroundDem;
        private ATS_Form.Controls.GroupBoxEx groupBoxExBattleGroundRep;
    }

}
