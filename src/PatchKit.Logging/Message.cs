using System;

namespace PatchKit.Logging
{
    /// <summary>
    /// Message.
    /// </summary>
    public struct Message
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> struct.
        /// </summary>
        public Message(string description, MessageType type, Exception exception)
        {
            Description = description;
            Type = type;
            Exception = exception;
        }

        /// <summary>
        /// Message description.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Message type.
        /// </summary>
        public MessageType Type { get; }

        /// <summary>
        /// Associated exception.
        /// </summary>
        public Exception Exception { get; }
    }
}