using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PatchKit.Logging
{
    public class DefaultLogger : ILogger
    {
        private readonly HashSet<IMessageWriter> _writers = new HashSet<IMessageWriter>();
        private readonly ILogStackFrameLocator _logStackFrameLocator;

        public DefaultLogger(ILogStackFrameLocator logStackFrameLocator)
        {
            _logStackFrameLocator = logStackFrameLocator;
        }
        
        public void AddWriter(IMessageWriter writer)
        {
            _writers.Add(writer);
        }

        public void RemoveWriter(IMessageWriter writer)
        {
            _writers.Remove(writer);
        }

        [IgnoreLogStackTrace]
        public void Log(Message message)
        {
            var dateTime = DateTime.Now;
            var stackTrace = new StackTrace();
            var stackFrame = _logStackFrameLocator.Locate(stackTrace);
            
            var messageContext = new MessageContext(stackFrame, dateTime);

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