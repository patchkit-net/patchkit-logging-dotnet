using System;
using System.Runtime.InteropServices;

namespace PatchKit.Logging
{
    public struct Message
    {
        public Message(string description, MessageType type, Exception exception = null)
        {
            Description = description;
            Type = type;
            Exception = exception;
        }
        
        public string Description { get; set; }

        public MessageType Type { get; set; }
        
        public Exception Exception { get; set; }
    }
}