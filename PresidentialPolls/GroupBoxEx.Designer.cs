namespace ATS_Form.Controls
{
    partial class GroupBoxEx
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
            flowLayoutPanel = new FlowLayoutPanel();
            label = new Label();
            groupBox = new GroupBox();
            flowLayoutPanel.SuspendLayout();
            groupBox.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Controls.Add(label);
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel.Location = new Point(3, 19);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(116, 34);
            flowLayoutPanel.TabIndex = 4;
            // 
            // label
            // 
            label.AutoSize = true;
            label.BackColor = SystemColors.Control;
            label.ForeColor = SystemColors.ControlText;
            label.Location = new Point(110, 9);
            label.Margin = new Padding(3, 9, 6, 0);
            label.Name = "label";
            label.Size = new Size(0, 15);
            label.TabIndex = 8;
            label.TextAlign = ContentAlignment.MiddleRight;
            // 
            // groupBox
            // 
            groupBox.Controls.Add(flowLayoutPanel);
            groupBox.Dock = DockStyle.Fill;
            groupBox.Location = new Point(0, 0);
            groupBox.Name = "groupBox";
            groupBox.Size = new Size(122, 56);
            groupBox.TabIndex = 2;
            groupBox.TabStop = false;
            groupBox.Text = "Text";
            // 
            // GroupBoxEx
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox);
            Name = "GroupBoxEx";
            Size = new Size(122, 56);
            flowLayoutPanel.ResumeLayout(false);
            flowLayoutPanel.PerformLayout();
            groupBox.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel;
        private Label label;
        private GroupBox groupBox;
    }
}
