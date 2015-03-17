using System;
using System.Diagnostics;
using System.Threading;

namespace SetupHelpers
{
    class Program
    {
        static void Main(string[] args)
        {
            const String eventSource = "WakeOnLAN";

            switch (args[0])
            {
                case "/install":
                    if (!EventLog.SourceExists(eventSource))
                        EventLog.CreateEventSource(eventSource, "Application");
                    break;

                case "/uninstall":
                    if (EventLog.SourceExists(eventSource))
                        EventLog.DeleteEventSource(eventSource);
                    break;
            }
            Thread.Sleep(1000);
        }
    }
}
