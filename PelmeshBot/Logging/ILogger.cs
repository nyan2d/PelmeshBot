namespace PelmeshBot.Logging
{
    interface ILogger
    {
        void Debug(object data);
        void Info(object data);
        void Warnng(object data);
        void Error(object data);
        void Fatal(object data);
        void Log(object data);
    }
}
