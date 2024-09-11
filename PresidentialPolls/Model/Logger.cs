namespace PresidentialPolls.Model
{
    public class Logger
    {
        public static void Log(string message, params object[] args)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine(message, args);
#else
            System.Console.WriteLine(message, args);
#endif
        }
        public static void Log(string message)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine(message);
#else
            System.Console.WriteLine(message);
#endif
        }
        public static void Log(object message)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine(message);
#else
            System.Console.WriteLine(message);
#endif
        }
    }

}
