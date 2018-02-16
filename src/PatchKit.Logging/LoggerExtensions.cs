using System;
using JetBrains.Annotations;

namespace PatchKit.Logging
{
    /// <summary>
    /// Extensions for <see cref="ILogger"/> interface.
    /// </summary>
    public static class LoggerExtensions
    {
        /// <inheritdoc cref="ILogger.Log"/>
        [IgnoreMessageSourceStack]
        public static void Log([NotNull] this ILogger @this, string description, MessageType type, Exception exception = null)
        {
            if (@this == null)
            {
                throw new ArgumentNullException(nameof(@this));
            }

            @this.Log(new Message(description, type, exception));
        }

        /// <summary>
        /// Logs message of <see cref="MessageType.Trace"/> type.
        /// </summary>
        [IgnoreMessageSourceStack]
        public static void LogTrace([NotNull] this ILogger @this, string description, Exception exception = null)
        {
            if (@this == null)
            {
                throw new ArgumentNullException(nameof(@this));
            }

            @this.Log(description, MessageType.Trace, exception);
        }

        /// <summary>
        /// Logs message of <see cref="MessageType.Debug"/> type.
        /// </summary>
        [IgnoreMessageSourceStack]
        public static void LogDebug([NotNull] this ILogger @this, string description, Exception exception = null)
        {
            if (@this == null)
            {
                throw new ArgumentNullException(nameof(@this));
            }

            @this.Log(description, MessageType.Debug, exception);
        }

        /// <summary>
        /// Logs message of <see cref="MessageType.Warning"/> type.
        /// </summary>
        [IgnoreMessageSourceStack]
        public static void LogWarning([NotNull] this ILogger @this, string description, Exception exception = null)
        {
            if (@this == null)
            {
                throw new ArgumentNullException(nameof(@this));
            }

            @this.Log(description, MessageType.Warning, exception);
        }

        /// <summary>
        /// Logs message of <see cref="MessageType.Error"/> type.
        /// </summary>
        [IgnoreMessageSourceStack]
        public static void LogError([NotNull] this ILogger @this, string description, Exception exception = null)
        {
            if (@this == null)
            {
                throw new ArgumentNullException(nameof(@this));
            }

            @this.Log(description, MessageType.Error, exception);
        }
    }
}