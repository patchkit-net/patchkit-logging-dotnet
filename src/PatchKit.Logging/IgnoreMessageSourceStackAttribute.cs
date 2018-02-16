using System;

namespace PatchKit.Logging
{
    /// <summary>
    /// Attribute to mark methods that should be ignored during <see cref="MessageSource"/> location.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class IgnoreMessageSourceStackAttribute : Attribute
    {
    }
}