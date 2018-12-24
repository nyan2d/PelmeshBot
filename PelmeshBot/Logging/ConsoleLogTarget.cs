using System;

namespace PelmeshBot.Logging
{
    class ConsoleLogTarget : ILogTarget
    {
        public void Log(LogLevel level, object data)
        {
            var lvl = string.Empty;
            switch (level)
            {
                case LogLevel.Debug: lvl = "Debug"; break;
                case LogLevel.Info: lvl = "Info"; break;
                case LogLevel.Warning: lvl = "Warning"; break;
                case LogLevel.Error: lvl = "Error"; break;
                case LogLevel.Fatal: lvl = "Fatal"; break;
            }

            Console.WriteLine($"{DateTime.Now} [{level}] {data}");
        }
    }
}
