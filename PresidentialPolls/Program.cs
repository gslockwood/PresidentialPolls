using System.Reflection;

namespace PresidentialPolls
{
#if false
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }

#endif
    internal static class Program
    {
#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable IDE0051 // Remove unused private members
#pragma warning disable IDE0052 // Remove unread private members
#pragma warning disable IDE0044 // Add readonly modifier
        static EventWaitHandle? s_event = null;
#pragma warning restore IDE0044 // Add readonly modifier
#pragma warning restore IDE0052 // Remove unread private members
#pragma warning restore IDE0051 // Remove unused private members
#pragma warning restore IDE0079 // Remove unnecessary suppression

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool created = true;
#if DEBUG
            created = true;
#else
            created = false;
            s_event = new(false, EventResetMode.ManualReset, Assembly.GetEntryAssembly()?.GetName().Name, out created);
#endif
            if( created )
                LaunchApp();
            //LaunchApp(args);
            else
            {
                MessageBox.Show(string.Format("Instance of {0} is already running!\n\n", Assembly.GetEntryAssembly()?.GetName().Name), "Error!", MessageBoxButtons.OK);
                Environment.Exit(1);
            }
        }

        //private static void LaunchApp(string[] args)
        private static void LaunchApp()
        {
            /**/
            string? greenFlashSoftware = Environment.GetEnvironmentVariable("GreenFlashSoftware");
            string filePath;
            if( greenFlashSoftware == null )
            {
                MessageBox.Show(string.Format("GreenFlashSoftware env var doesn't exist. Using current directory"));
                filePath = System.IO.Directory.GetCurrentDirectory();
            }
            else
            {
                filePath = string.Format(@"{0}\PresidentialPolls\", greenFlashSoftware);
                if( !Directory.Exists(filePath) ) Directory.CreateDirectory(filePath);
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(filePath));

        }
    }


}