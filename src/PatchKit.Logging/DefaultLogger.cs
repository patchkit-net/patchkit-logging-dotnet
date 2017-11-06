using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PatchKit.Logging
{
    public class DefaultLogger : ILogger
    {
        private readonly HashSet<IMessageWriter> _writers = new HashSet<IMessageWriter>();

        public void AddWriter(IMessageWriter writer)
        {
            _writers.Add(writer);
        }

        public void RemoveWriter(IMessageWriter writer)
        {
            _writers.Remove(writer);
        }

        public void Log(Message message)
        {
            var stackTrace = new StackTrace();
            var dateTime = DateTime.Now;

            var messageContext = new MessageContext(stackTrace, dateTime);

            Write(message, messageContext);
        }

        private void Write(Message message, MessageContext messageContext)
        {
            foreach (var writer in _writers)
            {
                try
                {
                    writer.Write(message, messageContext);
                }
                catch (Exception)
                {
                    // ignored because we cannot let Log throw any exceptions
                }
            }
        }
    }
}