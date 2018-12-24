using System.Collections.Generic;
using System.Linq;

namespace PelmeshBot.Logging
{
    class Logger : ILogger
    {
        private ICollection<ILogTarget> _targets;

        public Logger(params ILogTarget[] targets)
        {
            _targets = targets.ToList();
        }

        public void Debug(object data)
        {
#if DEBUG
            Log(LogLevel.Debug, data);
#endif
        }

        public void Error(object data)
        {
            Log(LogLevel.Error, data);
        }

        public void Fatal(object data)
        {
            Log(LogLevel.Fatal, data);
        }

        public void Info(object data)
        {
            Log(LogLevel.Info, data);
        }

        public void Log(LogLevel level, object data)
        {
            foreach (var target in _targets)
            {
                target.Log(level, data);
            }
        }

        public void Log(object data)
        {
            Log(LogLevel.Info, data);
        }

        public void Warnng(object data)
        {
            Log(LogLevel.Warning, data);
        }
    }
}
