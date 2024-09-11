namespace PresidentialPolls
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            pollUserControl = new PollUserControl();
            buttonUpdate = new Button();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            toolStripDropDownButtonUpdate = new ToolStripDropDownButton();
            tabControl = new TabControl();
            tabPageBattlegrounds = new TabPage();
            BattleGroundUserControl = new MultiChartControl();
            tabPage10LargestStates = new TabPage();
            TenLargestStatesUserControl = new MultiChartControl();
            tabPageState = new TabPage();
            tabPageWeb = new TabPage();
            tabPageNational = new TabPage();
            chartUserControlNational = new ChartUserControl(model);
            chartUserControlState = new ChartUserControl(model);
            statusStrip.SuspendLayout();
            tabControl.SuspendLayout();
            tabPageBattlegrounds.SuspendLayout();
            tabPage10LargestStates.SuspendLayout();
            tabPageState.SuspendLayout();
            tabPageWeb.SuspendLayout();
            tabPageNational.SuspendLayout();
            SuspendLayout();
            // 
            // pollUserControl
            // 
            pollUserControl.Dock = DockStyle.Fill;
            pollUserControl.Location = new Point(0, 0);
            pollUserControl.Name = "pollUserControl";
            pollUserControl.Size = new Size(1448, 1138);
            pollUserControl.TabIndex = 0;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Anchor =  AnchorStyles.Bottom  |  AnchorStyles.Right ;
            buttonUpdate.Location = new Point(1195, 1184);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(75, 23);
            buttonUpdate.TabIndex = 1;
            buttonUpdate.Text = "Update";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click +=  UpdateButtonClick ;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel, toolStripDropDownButtonUpdate });
            statusStrip.Location = new Point(0, 1178);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1480, 22);
            statusStrip.TabIndex = 6;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.ImageAlign = ContentAlignment.MiddleLeft;
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(1407, 17);
            toolStripStatusLabel.Spring = true;
            toolStripStatusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // toolStripDropDownButtonUpdate
            // 
            toolStripDropDownButtonUpdate.Alignment = ToolStripItemAlignment.Right;
            toolStripDropDownButtonUpdate.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButtonUpdate.ImageScaling = ToolStripItemImageScaling.None;
            toolStripDropDownButtonUpdate.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButtonUpdate.Name = "toolStripDropDownButtonUpdate";
            toolStripDropDownButtonUpdate.Size = new Size(58, 20);
            toolStripDropDownButtonUpdate.Text = "Update";
            toolStripDropDownButtonUpdate.Click +=  UpdateButtonClick ;
            // 
            // tabControl
            // 
            tabControl.Anchor =    AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left   |  AnchorStyles.Right ;
            tabControl.Controls.Add(tabPageBattlegrounds);
            tabControl.Controls.Add(tabPage10LargestStates);
            tabControl.Controls.Add(tabPageState);
            tabControl.Controls.Add(tabPageNational);
            tabControl.Controls.Add(tabPageWeb);
            tabControl.Location = new Point(12, 12);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1456, 1166);
            tabControl.TabIndex = 7;
            // 
            // tabPageBattlegrounds
            // 
            tabPageBattlegrounds.Controls.Add(BattleGroundUserControl);
            tabPageBattlegrounds.Location = new Point(4, 24);
            tabPageBattlegrounds.Name = "tabPageBattlegrounds";
            tabPageBattlegrounds.Padding = new Padding(3);
            tabPageBattlegrounds.Size = new Size(1448, 1138);
            tabPageBattlegrounds.TabIndex = 0;
            tabPageBattlegrounds.Text = "Battleground States";
            tabPageBattlegrounds.UseVisualStyleBackColor = true;
            // 
            // BattleGroundUserControl
            // 
            BattleGroundUserControl.Dock = DockStyle.Fill;
            BattleGroundUserControl.Location = new Point(3, 3);
            BattleGroundUserControl.Name = "BattleGroundUserControl";
            BattleGroundUserControl.Size = new Size(1442, 1132);
            BattleGroundUserControl.TabIndex = 0;
            // 
            // tabPage10LargestStates
            // 
            tabPage10LargestStates.Controls.Add(TenLargestStatesUserControl);
            tabPage10LargestStates.Location = new Point(4, 24);
            tabPage10LargestStates.Name = "tabPage10LargestStates";
            tabPage10LargestStates.Size = new Size(1448, 1138);
            tabPage10LargestStates.TabIndex = 3;
            tabPage10LargestStates.Text = "10 Largest States";
            tabPage10LargestStates.UseVisualStyleBackColor = true;
            // 
            // TenLargestStatesUserControl
            // 
            TenLargestStatesUserControl.Dock = DockStyle.Fill;
            TenLargestStatesUserControl.Location = new Point(0, 0);
            TenLargestStatesUserControl.Name = "TenLargestStatesUserControl";
            TenLargestStatesUserControl.Size = new Size(1448, 1138);
            TenLargestStatesUserControl.TabIndex = 0;
            // 
            // tabPageState
            // 
            tabPageState.Controls.Add(chartUserControlState);
            tabPageState.Location = new Point(4, 24);
            tabPageState.Name = "tabPageState";
            tabPageState.Padding = new Padding(3);
            tabPageState.Size = new Size(1448, 1138);
            tabPageState.TabIndex = 1;
            tabPageState.Text = "State";
            tabPageState.UseVisualStyleBackColor = true;
            // 
            // tabPageWeb
            // 
            tabPageWeb.Controls.Add(pollUserControl);
            tabPageWeb.Location = new Point(4, 24);
            tabPageWeb.Name = "tabPageWeb";
            tabPageWeb.Size = new Size(1448, 1138);
            tabPageWeb.TabIndex = 2;
            tabPageWeb.Text = "Web";
            tabPageWeb.UseVisualStyleBackColor = true;
            // 
            // tabPageNational
            // 
            tabPageNational.Controls.Add(chartUserControlNational);
            tabPageNational.Location = new Point(4, 24);
            tabPageNational.Name = "tabPageNational";
            tabPageNational.Size = new Size(1448, 1138);
            tabPageNational.TabIndex = 4;
            tabPageNational.Text = "National";
            tabPageNational.UseVisualStyleBackColor = true;
            // 
            // chartUserControlNational
            // 
            chartUserControlNational.Dock = DockStyle.Fill;
            chartUserControlNational.Location = new Point(0, 0);
            chartUserControlNational.Name = "chartUserControlNational";
            chartUserControlNational.Size = new Size(1448, 1138);
            chartUserControlNational.TabIndex = 0;
            // 
            // chartUserControlState
            // 
            chartUserControlState.Dock = DockStyle.Fill;
            chartUserControlState.Location = new Point(3, 3);
            chartUserControlState.Name = "chartUserControlState";
            chartUserControlState.Size = new Size(1442, 1132);
            chartUserControlState.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1480, 1200);
            Controls.Add(tabControl);
            Controls.Add(statusStrip);
            Controls.Add(buttonUpdate);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Political Polls";
            Load +=  MainForm_Load ;
            Shown +=  MainForm_Shown ;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            tabControl.ResumeLayout(false);
            tabPageBattlegrounds.ResumeLayout(false);
            tabPage10LargestStates.ResumeLayout(false);
            tabPageState.ResumeLayout(false);
            tabPageWeb.ResumeLayout(false);
            tabPageNational.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PollUserControl pollUserControl;
        private Button buttonUpdate;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ToolStripDropDownButton toolStripDropDownButtonUpdate;
        private TabControl tabControl;
        private TabPage tabPageBattlegrounds;
        private TabPage tabPageState;
        private TabPage tabPageWeb;
        private TabPage tabPage10LargestStates;

        private MultiChartControl TenLargestStatesUserControl;
        private MultiChartControl BattleGroundUserControl;
        private TabPage tabPageNational;
        private ChartUserControl chartUserControlNational;
        private ChartUserControl chartUserControlState;
    }
}
