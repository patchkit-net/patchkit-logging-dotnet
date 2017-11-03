namespace PatchKit.Logging
{
    public interface ILogMessageFormatter
    {
        string Format(LogMessage logMessage);
    }
}