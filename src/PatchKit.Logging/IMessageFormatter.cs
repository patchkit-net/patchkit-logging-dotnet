namespace PatchKit.Logging
{
    /// <summary>
    /// Message formatter.
    /// </summary>
    public interface IMessageFormatter
    {
        /// <summary>
        /// Formats provided message to text.
        /// </summary>
        string Format(Message message, MessageContext messageContext);
    }
}