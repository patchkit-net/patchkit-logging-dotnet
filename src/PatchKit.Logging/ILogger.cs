namespace PatchKit.Logging
{
    /// <summary>
    /// Message logger.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs message.
        /// </summary>
        /// <param name="message">Message that should be logged.</param>
        void Log(Message message);
    }
}