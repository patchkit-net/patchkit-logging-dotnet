using System;

namespace PatchKit.Logging
{
    [AttributeUsage(AttributeTargets.Method)]
    public class IgnoreLogStackTraceAttribute : Attribute
    {
    }
}