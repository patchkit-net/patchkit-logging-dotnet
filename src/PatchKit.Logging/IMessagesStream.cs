using System;
using JetBrains.Annotations;

namespace PatchKit.Logging
{
    /// <summary>
    /// Messages stream.
    /// </summary>
    public interface IMessagesStream
    {
        /// <summary>
        /// Subscribes observer to stream of messages.
        /// </summary>
        /// <returns>Subscription handle. Call <see cref="IDisposable.Dispose"/> to end subscription.</returns>
        IDisposable Subscribe([NotNull] IMessagesStreamObserver observer);
    }
}