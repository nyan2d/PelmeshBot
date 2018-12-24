namespace PelmeshBot.Logging
{
    interface ILogTarget
    {
        void Log(LogLevel level, object data);
    }
}
