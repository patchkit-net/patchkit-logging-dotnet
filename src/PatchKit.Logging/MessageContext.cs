using System;
using System.Diagnostics;

namespace PatchKit.Logging
{
    public struct MessageContext
    {
        public MessageContext(StackTrace stackTrace, DateTime dateTime)
        {
            StackTrace = stackTrace;
            DateTime = dateTime;
        }

        public StackTrace StackTrace { get; set; }

        public DateTime DateTime { get; set; }
    }
}