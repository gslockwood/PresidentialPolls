
namespace PresidentialPolls.Model
{
    [Serializable]
    internal class NoPollingDataException : Exception
    {
        public override string Message => "There are no polls yet for this state";
        private readonly string? state = string.Empty;
        public string? State { get { return state; } }
        public NoPollingDataException()
        {
        }

        public NoPollingDataException(string? message) : base(message)
        {
            state = message;
        }

        //public NoPollingDataException(string? message, Exception? innerException) : base(message, innerException)
        //{
        //}
    }
    internal class DemocratColumnMissingException : Exception
    {
        public override string Message => "Democrat Candidate Column is Missing";

        private readonly string? state = string.Empty;
        public string? State { get { return state; } }

        public DemocratColumnMissingException()
        {
        }

        public DemocratColumnMissingException(string? message)// : base(message)
        {
            state = message;
        }

        //public DemocratColumnMissingException(string? message, Exception? innerException) : base(message, innerException)
        //{
        //}
    }
    internal class RepublicanColumnMissingException : Exception
    {
        public override string Message => "Republican Candidate Column is Missing";
        private readonly string? state = string.Empty;
        public string? State { get { return state; } }

        public RepublicanColumnMissingException()
        {
        }

        public RepublicanColumnMissingException(string? message) : base(message)
        {
            state = message;
        }

        //public RepublicanColumnMissingException(string? message, Exception? innerException) : base(message, innerException)
        //{
        //}

    }

}