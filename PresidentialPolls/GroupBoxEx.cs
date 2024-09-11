using System.ComponentModel;

namespace ATS_Form.Controls
{
    public partial class GroupBoxEx : UserControl
    {
        public GroupBoxEx()
        {
            InitializeComponent();
        }

        public string Value { set { label.Text = value; } }

        [Category("Special")]
        public string CaptionText { get { return groupBox.Text; } set { groupBox.Text = value; } }

        [Category("Special")]
        public Color ValueForeColor { get { return label.ForeColor; } set { label.ForeColor = value; } }

        [Category("Special")]
        public Color ValueBackColor { get { return label.BackColor; } set { label.BackColor = value; } }
    }
}
