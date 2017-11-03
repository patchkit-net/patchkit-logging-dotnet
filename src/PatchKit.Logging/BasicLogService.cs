using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PatchKit.Logging
{
    public class BasicLogService : ILogService
    {
        private readonly HashSet<ILogWriter> _writers = new HashSet<ILogWriter>();
        
        private readonly BasicLogMessageFormatter _formatter = new BasicLogMessageFormatter();
        
        public void AddWriter(ILogWriter writer)
        {
            _writers.Add(writer);
        }

        public void RemoveWriter(ILogWriter writer)
        {
            _writers.Remove(writer);
        }

        public void Log(LogMessage message)
        {
            var dateTime = DateTime.Now;
            var stackTrace = new StackTrace();

            var text = _formatter.Format(message, dateTime, stackTrace);

            Write(text);
        }

        private void Write(string text)
        {
            foreach (var writer in _writers)
            {
                try
                {
                    writer.Write(text);
                }
                catch (Exception e)
                {
                    // ignored because we cannot let Log throw any exceptions
                }
            }
        }
    }
}