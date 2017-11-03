using System;
using System.Diagnostics;

namespace PatchKit.Logging
{
    public class BasicLogMessageFormatter
    {
        public string Format(LogMessage message, DateTime dateTime, StackTrace stackTrace)
        {
            var output = $"{GetDateTimeText(dateTime)} {GetMessageTypeText(message.Type)} {GetCallerNameText(stackTrace)} {message.Description}";

            var exceptionInfo = GetExceptionInfo(message);

            if (exceptionInfo != null)
            {
                output = $"{output}\n{exceptionInfo}";
            }

            return output;
        }

        private static string GetExceptionInfo(LogMessage message)
        {
            return message.Exception == null
                ? null
                : $"{message.Exception.GetType()}: {message.Exception.Message}\nStack trace: {message.Exception.StackTrace}";
        }
        
        private static string GetCallerNameText(StackTrace stackTrace)
        {
            var frame = stackTrace.GetFrame(0);

            var method = frame?.GetMethod();
            var declaringType = method?.DeclaringType;

            return declaringType != null
                ? $"<{declaringType.Name}::{method.Name}>"
                : "<unknown caller>";
        }

        private static string GetDateTimeText(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff zzz");
        }

        private static string GetMessageTypeText(LogMessageType messageType)
        {
            switch (messageType)
            {
                case LogMessageType.Trace:
                    return "[ TRACE ]";
                case LogMessageType.Debug:
                    return "[ DEBUG ]";
                case LogMessageType.Warning:
                    return "[WARNING]";
                case LogMessageType.Error:
                    return "[ ERROR ]";
                default:
                    throw new ArgumentOutOfRangeException(nameof(messageType), messageType, null);
            }
        }
    }
}