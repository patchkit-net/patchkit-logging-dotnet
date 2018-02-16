using System;

namespace PatchKit.Logging
{
    /// <summary>
    /// Context of logged message.
    /// </summary>
    public struct MessageContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageContext"/> struct.
        /// </summary>
        public MessageContext(MessageSource source, DateTime dateTime)
        {
            Source = source;
            DateTime = dateTime;
        }

        /// <summary>
        /// Source.
        /// </summary>
        public MessageSource Source { get; }

        /// <summary>
        /// Time when message was logged.
        /// </summary>
        public DateTime DateTime { get; }
    }
}