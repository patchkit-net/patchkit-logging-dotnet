namespace PatchKit.Logging
{
    /// <summary>
    /// <see cref="IMessagesStream"/> observer.
    /// </summary>
    public interface IMessagesStreamObserver
    {
        /// <summary>
        /// Called when new message is distributed through the stream.
        /// </summary>
        void OnNext(Message message, MessageContext context);
    }
}