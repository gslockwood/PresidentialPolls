using PresidentialPolls.Model;

namespace PresidentialPolls
{
    public partial class MainForm : Form
    {
        readonly Model.Model? model;// = new();

        readonly bool testing = false;// true false

        public MainForm(string filePath)
        {
            model = new(filePath);
            model.StateUpdateCompleted += Model_StateUpdateCompleted;

            if( testing )
            {
                //model.UpdateDatabase();
                //model.GetByState("alaska");// no average
                //model.GetByStateForDB("arizona");
                return;
            }
            else
            {
                bool update = Model.Model.CheckForUpdate;
                if( update )
                {
                    model.UpdateAll();
                }
            }

            InitializeComponent();

            if( model != null && model.States != null && model?.States?.Count != 0 )
            {
                var name = model?.States.First().Name;

                //name = "arizona";

                if( name != null )
                    chartUserControlState.SetState = name;

                name = "National";
                if( model != null && model.States.Any(x => x.Name == name) )
                {
                    chartUserControlNational.SetState = name;
                    chartUserControlNational.SingleDisplay = true;
                }
            }
            //
        }

        private void SetupUserControl(IList<State> states, MultiChartControl userControl)
        {
            if( this.InvokeRequired )
            {
                this.Invoke(new System.Windows.Forms.MethodInvoker(() => { SetupUserControl(states, userControl); return; }));
                return;
            }

            if( model == null ) return;
            if( model.NewStatePolling == null ) return;
            if( model != null && model?.NewStatePolling?.Count == 0 ) toolStripStatusLabel.Text = "No new polls";
            else
            {
                if( model == null ) return;
                string csv = String.Join(",", model.NewStatePolling.Select(x => x.ToString()).ToArray());
                toolStripStatusLabel.Text = "New Polls in: " + csv;
            }

            userControl.ClearAllData();

            foreach( State state in states )
            {
                if( state.Name == null ) continue;

                ChartUserControl chartUserControl = new(model)
                {
                    SingleDisplay = false,
                    Height = 500,
                    SetState = state.Name,
                };

                userControl.Add(chartUserControl);

            }

            this.Width += 1;
            this.Width -= 1;
            //
        }

        private void Build10LargestUI()
        {
            IList<State> states = Model.Model.GetLargeStatesList(10);
            if( states == null || states.Count == 0 ) return;

            SetupUserControl(states, TenLargestStatesUserControl);
        }

        private void BuildBattleGroundUI()
        {
            if( model == null ) return;
            IList<State> states = model.GetBattleGroundStatesList();
            if( states == null || states.Count == 0 ) return;

            SetupUserControl(states, BattleGroundUserControl);
        }

        private void Model_StateUpdateCompleted(string? state)
        {
            if( this.InvokeRequired )
            {
                this.Invoke(new System.Windows.Forms.MethodInvoker(() => { Model_StateUpdateCompleted(state); }));
                return;
            }

            if( string.IsNullOrEmpty(state) )
            {
                BuildBattleGroundUI();
                Build10LargestUI();

                return;
            }
            if( toolStripStatusLabel == null ) return;
            if( toolStripStatusLabel.Text == null ) return;
            toolStripStatusLabel.Text = $"{state[0].ToString().ToUpper()}{state[1..].Replace("-", " ")}"; ;
            //
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            BuildBattleGroundUI();
            Build10LargestUI();

            this.Width = 2400;

            /*
            Thread thread = new(delegate ()
            {
                BuildBattleGroundUI();
            Build10LargestUI();
            });

            thread.Start();
            */
            //
        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            //this.Width += 1; this.Width -= 1;
        }

        private void UpdateButtonClick(object sender, EventArgs e)
        {
            bool update = Model.Model.CheckForUpdate;
            if( update )
            {
                model?.UpdateAll();
            }
            else
            {
                MessageBox.Show("Polling info for today is already stored", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel.Text = "Updating BattleGround states UI";
                BuildBattleGroundUI();
                Build10LargestUI();

                toolStripStatusLabel.Text = null;
            }
            //
        }

    }
}

