using System;
using System.Runtime.InteropServices;

namespace PatchKit.Logging
{
    public struct LogMessage
    {
        public LogMessage(string description, LogMessageType type, Exception exception = null)
        {
            Description = description;
            Type = type;
            Exception = exception;
        }
        
        public string Description { get; set; }

        public LogMessageType Type { get; set; }
        
        public Exception Exception { get; set; }
    }
}