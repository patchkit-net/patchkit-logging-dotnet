using System;

namespace PatchKit.Logging
{
    public static class LoggerExtensions
    {
        [IgnoreLogStackTrace]
        public static void Log(this ILogger @this, string description, MessageType type, Exception exception = null)
        {
            @this.Log(new Message(description, type, exception));
        }

        [IgnoreLogStackTrace]
        public static void LogTrace(this ILogger @this, string description, Exception exception = null)
        {
            @this.Log(description, MessageType.Trace, exception);
        }

        [IgnoreLogStackTrace]
        public static void LogDebug(this ILogger @this, string description, Exception exception = null)
        {
            @this.Log(description, MessageType.Debug, exception);
        }

        [IgnoreLogStackTrace]
        public static void LogWarning(this ILogger @this, string description, Exception exception = null)
        {
            @this.Log(description, MessageType.Warning, exception);
        }

        [IgnoreLogStackTrace]
        public static void LogError(this ILogger @this, string description, Exception exception = null)
        {
            @this.Log(description, MessageType.Error, exception);
        }
    }
}