using System;
using System.Diagnostics;
using System.Reflection;

namespace PatchKit.Logging
{
    /// <inheritdoc />
    public class DefaultMessageSourceStackLocator : IMessageSourceStackLocator
    {
        /// <inheritdoc />
        public MessageSource Locate(StackTrace stackTrace)
        {
            if (stackTrace == null)
            {
                throw new ArgumentNullException(nameof(stackTrace));
            }

            StackFrame stackFrame = null;
            MethodBase method = null;

            for (int i = 0; i < stackTrace.FrameCount; i++)
            {
                stackFrame = stackTrace.GetFrame(i);
                method = stackFrame?.GetMethod();
                if (method != null &&
                    method.GetCustomAttributes(typeof(IgnoreMessageSourceStackAttribute), true).Length == 0)
                {
                    break;
                }

                stackFrame = null;
                method = null;
            }

            var type = method?.DeclaringType;
            var fileName = stackFrame?.GetFileName();
            var fileLineNumber = stackFrame?.GetFileLineNumber();

            return new MessageSource(type, method, fileName, fileLineNumber);
        }


    }
}