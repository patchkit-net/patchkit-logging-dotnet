using System.Diagnostics;

namespace PatchKit.Logging
{
    public interface ILogStackFrameLocator
    {
        StackFrame Locate(StackTrace stackTrace);
    }
}