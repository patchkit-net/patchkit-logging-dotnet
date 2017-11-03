using System;

namespace PatchKit.Logging
{
    public static class LogServiceExtensions
    {
        public static void Log(this ILogService @this, string description, LogMessageType type, Exception exception = null)
        {
            @this.Log(new LogMessage(description, type, exception));
        }

        public static void LogTrace(this ILogService @this, string description, Exception exception = null)
        {
            @this.Log(description, LogMessageType.Trace, exception);
        }
        
        public static void LogDebug(this ILogService @this, string description, Exception exception = null)
        {
            @this.Log(description, LogMessageType.Debug, exception);
        }
        
        public static void LogWarning(this ILogService @this, string description, Exception exception = null)
        {
            @this.Log(description, LogMessageType.Warning, exception);
        }
        
        public static void LogError(this ILogService @this, string description, Exception exception = null)
        {
            @this.Log(description, LogMessageType.Error, exception);
        }
    }
}