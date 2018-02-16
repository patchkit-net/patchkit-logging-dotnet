using System.Diagnostics;
using JetBrains.Annotations;

namespace PatchKit.Logging
{
    /// <summary>
    /// Message source stack locator.
    /// </summary>
    public interface IMessageSourceStackLocator
    {
        /// <summary>
        /// Locates source of message basing on provided stack trace.
        /// Should handle <see cref="IgnoreMessageSourceStackAttribute"/>.
        /// </summary>
        MessageSource Locate([NotNull] StackTrace stackTrace);
    }
}