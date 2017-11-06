using System;
using System.Diagnostics;

namespace PatchKit.Logging
{
    public class SimpleMessageFormatter : IMessageFormatter
    {
        public string Format(Message message, MessageContext messageContext)
        {
            var output =
                $"{GetDateTimeText(messageContext.DateTime)} {GetMessageTypeText(message.Type)} {GetCallerNameText(messageContext.StackFrame)} {message.Description}";

            var exceptionInfo = GetExceptionInfo(message);

            if (exceptionInfo != null)
            {
                output = $"{output}\n{exceptionInfo}";
            }

            return output;
        }

        private static string GetExceptionInfo(Message message)
        {
            return message.Exception == null
                ? null
                : $"{message.Exception.GetType()}: {message.Exception.Message}\nStack trace: {message.Exception.StackTrace}";
        }

        private static string GetCallerNameText(StackFrame stackFrame)
        {
            var method = stackFrame?.GetMethod();
            var declaringType = method?.DeclaringType;

            return declaringType != null
                ? $"<{declaringType.Name}::{method.Name}>"
                : "<unknown caller>";
        }

        private static string GetDateTimeText(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff zzz");
        }

        private static string GetMessageTypeText(MessageType messageType)
        {
            switch (messageType)
            {
                case MessageType.Trace:
                    return "[ TRACE ]";
                case MessageType.Debug:
                    return "[ DEBUG ]";
                case MessageType.Warning:
                    return "[WARNING]";
                case MessageType.Error:
                    return "[ ERROR ]";
                default:
                    throw new ArgumentOutOfRangeException(nameof(messageType), messageType, null);
            }
        }
    }
}