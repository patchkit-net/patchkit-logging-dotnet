using System.Diagnostics;

namespace PatchKit.Logging
{
    public class DefaultLogStackFrameLocator : ILogStackFrameLocator
    {
        public StackFrame Locate(StackTrace stackTrace)
        {
            for (int i = 0; i < stackTrace.FrameCount; i++)
            {
                var stackFrame = stackTrace.GetFrame(i);
                var method = stackFrame?.GetMethod();
                if (method != null &&
                    method.GetCustomAttributes(typeof(IgnoreLogStackTraceAttribute), true).Length == 0)
                {
                    return stackFrame;
                }
            }

            return null;
        }
    }
}