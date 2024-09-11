namespace PresidentialPolls.Model
{
    public class DailyData
    {
        public DailyData(string stateName, int stateElectoralVotes)
        {
            StateName = stateName;
            StateElectoralVotes = stateElectoralVotes;
        }

        public string StateName { get; }
        public int StateElectoralVotes { get; }
    }
}
