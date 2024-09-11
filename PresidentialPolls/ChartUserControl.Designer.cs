using System.Windows.Forms;

namespace PresidentialPolls
{
    partial class ChartUserControl
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
            panel = new Panel();
            comboBoxStates = new ComboBox();
            formsPlot = new ScottPlot.WinForms.FormsPlot();
            tableLayoutPanel = new TableLayoutPanel();
            panelValues = new Panel();
            panelAllValues = new FlowLayoutPanel();
            groupBoxDemocrat = new GroupBox();
            flowLayoutPanelComboDem = new FlowLayoutPanel();
            groupBoxExDemocratScore = new ATS_Form.Controls.GroupBoxEx();
            groupBoxExDemocratTrend = new ATS_Form.Controls.GroupBoxEx();
            pictureBoxLogo = new PictureBox();
            groupBoxRepublican = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            groupBoxExRepublicanScore = new ATS_Form.Controls.GroupBoxEx();
            groupBoxExRepublicanTrend = new ATS_Form.Controls.GroupBoxEx();
            groupBox = new GroupBox();
            panel.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            panelValues.SuspendLayout();
            panelAllValues.SuspendLayout();
            groupBoxDemocrat.SuspendLayout();
            flowLayoutPanelComboDem.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)pictureBoxLogo ).BeginInit();
            groupBoxRepublican.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            groupBox.SuspendLayout();
            SuspendLayout();
            // 
            // panel
            // 
            panel.BackColor = Color.White;
            panel.Controls.Add(comboBoxStates);
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(3, 591);
            panel.Name = "panel";
            panel.Size = new Size(894, 30);
            panel.TabIndex = 0;
            // 
            // comboBoxStates
            // 
            comboBoxStates.FormattingEnabled = true;
            comboBoxStates.Location = new Point(72, 3);
            comboBoxStates.Name = "comboBoxStates";
            comboBoxStates.Size = new Size(157, 25);
            comboBoxStates.TabIndex = 0;
            comboBoxStates.SelectedIndexChanged +=  ComboBoxStates_SelectedIndexChanged ;
            // 
            // formsPlot
            // 
            formsPlot.DisplayScale = 1F;
            formsPlot.Dock = DockStyle.Fill;
            formsPlot.Location = new Point(3, 126);
            formsPlot.Name = "formsPlot";
            formsPlot.Size = new Size(894, 459);
            formsPlot.TabIndex = 1;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(formsPlot, 0, 1);
            tableLayoutPanel.Controls.Add(panel, 0, 2);
            tableLayoutPanel.Controls.Add(panelValues, 0, 0);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(3, 21);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 123F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tableLayoutPanel.Size = new Size(900, 624);
            tableLayoutPanel.TabIndex = 2;
            // 
            // panelValues
            // 
            panelValues.BackColor = Color.White;
            panelValues.Controls.Add(panelAllValues);
            panelValues.Dock = DockStyle.Fill;
            panelValues.Location = new Point(3, 3);
            panelValues.Name = "panelValues";
            panelValues.Size = new Size(894, 117);
            panelValues.TabIndex = 2;
            // 
            // panelAllValues
            // 
            panelAllValues.Controls.Add(groupBoxDemocrat);
            panelAllValues.Controls.Add(pictureBoxLogo);
            panelAllValues.Controls.Add(groupBoxRepublican);
            panelAllValues.Location = new Point(52, 6);
            panelAllValues.Margin = new Padding(12, 3, 12, 0);
            panelAllValues.Name = "panelAllValues";
            panelAllValues.Padding = new Padding(6, 6, 6, 0);
            panelAllValues.Size = new Size(694, 104);
            panelAllValues.TabIndex = 2;
            // 
            // groupBoxDemocrat
            // 
            groupBoxDemocrat.Controls.Add(flowLayoutPanelComboDem);
            groupBoxDemocrat.Location = new Point(9, 9);
            groupBoxDemocrat.Name = "groupBoxDemocrat";
            groupBoxDemocrat.Padding = new Padding(12, 3, 12, 3);
            groupBoxDemocrat.Size = new Size(261, 87);
            groupBoxDemocrat.TabIndex = 4;
            groupBoxDemocrat.TabStop = false;
            groupBoxDemocrat.Text = "Democrat";
            // 
            // flowLayoutPanelComboDem
            // 
            flowLayoutPanelComboDem.Controls.Add(groupBoxExDemocratScore);
            flowLayoutPanelComboDem.Controls.Add(groupBoxExDemocratTrend);
            flowLayoutPanelComboDem.Dock = DockStyle.Fill;
            flowLayoutPanelComboDem.Location = new Point(12, 21);
            flowLayoutPanelComboDem.Name = "flowLayoutPanelComboDem";
            flowLayoutPanelComboDem.Padding = new Padding(9, 0, 9, 0);
            flowLayoutPanelComboDem.Size = new Size(237, 63);
            flowLayoutPanelComboDem.TabIndex = 3;
            // 
            // groupBoxExDemocratScore
            // 
            groupBoxExDemocratScore.CaptionText = "Score";
            groupBoxExDemocratScore.Location = new Point(15, 3);
            groupBoxExDemocratScore.Margin = new Padding(6, 3, 6, 3);
            groupBoxExDemocratScore.Name = "groupBoxExDemocratScore";
            groupBoxExDemocratScore.Size = new Size(100, 57);
            groupBoxExDemocratScore.TabIndex = 3;
            groupBoxExDemocratScore.ValueBackColor = Color.Blue;
            groupBoxExDemocratScore.ValueForeColor = Color.White;
            // 
            // groupBoxExDemocratTrend
            // 
            groupBoxExDemocratTrend.CaptionText = "Trend";
            groupBoxExDemocratTrend.Location = new Point(124, 3);
            groupBoxExDemocratTrend.Name = "groupBoxExDemocratTrend";
            groupBoxExDemocratTrend.Size = new Size(100, 57);
            groupBoxExDemocratTrend.TabIndex = 4;
            groupBoxExDemocratTrend.ValueBackColor = Color.Blue;
            groupBoxExDemocratTrend.ValueForeColor = Color.White;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor = Color.Transparent;
            pictureBoxLogo.Image = Properties.Resources.pollresults;
            pictureBoxLogo.Location = new Point(276, 9);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(132, 87);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxLogo.TabIndex = 3;
            pictureBoxLogo.TabStop = false;
            // 
            // groupBoxRepublican
            // 
            groupBoxRepublican.Controls.Add(flowLayoutPanel1);
            groupBoxRepublican.Location = new Point(414, 9);
            groupBoxRepublican.Name = "groupBoxRepublican";
            groupBoxRepublican.Padding = new Padding(12, 3, 12, 3);
            groupBoxRepublican.Size = new Size(262, 87);
            groupBoxRepublican.TabIndex = 6;
            groupBoxRepublican.TabStop = false;
            groupBoxRepublican.Text = "Republican";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(groupBoxExRepublicanScore);
            flowLayoutPanel1.Controls.Add(groupBoxExRepublicanTrend);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(12, 21);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(9, 0, 9, 0);
            flowLayoutPanel1.Size = new Size(238, 63);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // groupBoxExRepublicanScore
            // 
            groupBoxExRepublicanScore.CaptionText = "Score";
            groupBoxExRepublicanScore.Location = new Point(15, 3);
            groupBoxExRepublicanScore.Margin = new Padding(6, 3, 6, 3);
            groupBoxExRepublicanScore.Name = "groupBoxExRepublicanScore";
            groupBoxExRepublicanScore.Size = new Size(100, 57);
            groupBoxExRepublicanScore.TabIndex = 3;
            groupBoxExRepublicanScore.ValueBackColor = Color.Red;
            groupBoxExRepublicanScore.ValueForeColor = Color.White;
            // 
            // groupBoxExRepublicanTrend
            // 
            groupBoxExRepublicanTrend.CaptionText = "Trend";
            groupBoxExRepublicanTrend.Location = new Point(124, 3);
            groupBoxExRepublicanTrend.Name = "groupBoxExRepublicanTrend";
            groupBoxExRepublicanTrend.Size = new Size(100, 57);
            groupBoxExRepublicanTrend.TabIndex = 4;
            groupBoxExRepublicanTrend.ValueBackColor = Color.Red;
            groupBoxExRepublicanTrend.ValueForeColor = Color.White;
            // 
            // groupBox
            // 
            groupBox.Controls.Add(tableLayoutPanel);
            groupBox.Dock = DockStyle.Fill;
            groupBox.Font = new Font("Segoe UI", 10F);
            groupBox.Location = new Point(0, 0);
            groupBox.Name = "groupBox";
            groupBox.Size = new Size(906, 648);
            groupBox.TabIndex = 3;
            groupBox.TabStop = false;
            groupBox.Text = "StateName";
            // 
            // ChartUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox);
            Name = "ChartUserControl";
            Size = new Size(906, 648);
            Resize +=  ChartUserControl_Resize ;
            panel.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            panelValues.ResumeLayout(false);
            panelAllValues.ResumeLayout(false);
            groupBoxDemocrat.ResumeLayout(false);
            flowLayoutPanelComboDem.ResumeLayout(false);
            ( (System.ComponentModel.ISupportInitialize)pictureBoxLogo ).EndInit();
            groupBoxRepublican.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            groupBox.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel;
        private ScottPlot.WinForms.FormsPlot formsPlot;
        private TableLayoutPanel tableLayoutPanel;
        private ComboBox comboBoxStates;
        private Panel panelValues;
        private FlowLayoutPanel panelAllValues;
        private GroupBox groupBox;
        private GroupBox groupBoxDemocrat;
        private FlowLayoutPanel flowLayoutPanelComboDem;
        private ATS_Form.Controls.GroupBoxEx groupBoxExDemocratScore;
        private ATS_Form.Controls.GroupBoxEx groupBoxExDemocratTrend;
        private GroupBox groupBoxRepublican;
        private FlowLayoutPanel flowLayoutPanel1;
        private ATS_Form.Controls.GroupBoxEx groupBoxExRepublicanScore;
        private ATS_Form.Controls.GroupBoxEx groupBoxExRepublicanTrend;
        private PictureBox pictureBoxLogo;
    }
}
