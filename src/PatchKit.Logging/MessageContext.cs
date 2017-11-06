using System;
using System.Diagnostics;

namespace PatchKit.Logging
{
    public struct MessageContext
    {
        public MessageContext(StackFrame stackFrame, DateTime dateTime)
        {
            StackFrame = stackFrame;
            DateTime = dateTime;
        }

        public StackFrame StackFrame { get; set; }
        
        public DateTime DateTime { get; set; }
    }
}