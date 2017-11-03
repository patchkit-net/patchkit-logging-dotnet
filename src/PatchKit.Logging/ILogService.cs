namespace PatchKit.Logging
{
    public interface ILogService
    {
        void AddWriter(ILogWriter writer);

        void RemoveWriter(ILogWriter writer);
        
        void Log(LogMessage message);
    }
}