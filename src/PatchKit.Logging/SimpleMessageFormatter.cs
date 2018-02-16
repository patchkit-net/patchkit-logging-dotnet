using System;

namespace PatchKit.Logging
{
    /// <inheritdoc />
    /// <summary>
    /// Simple message formatter.
    /// </summary>
    public class SimpleMessageFormatter : IMessageFormatter
    {
        /// <inheritdoc />
        public string Format(Message message, MessageContext messageContext)
        {
            var output =
                $"{GetDateTimeText(messageContext.DateTime)} {GetMessageTypeText(message.Type)} {GetCallerNameText(messageContext.Source)} {message.Description}";

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
                : $"{message.Exception.GetType()}: {message.Exception.Message}\n{message.Exception.StackTrace}";
        }

        private static string GetCallerNameText(MessageSource source)
        {
            return $"<{source.Type?.Name ?? "unknown_type"}::{source.Method?.Name ?? "unknown_method"}>";
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