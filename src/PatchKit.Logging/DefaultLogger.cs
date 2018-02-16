using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace PatchKit.Logging
{
    /// <inheritdoc cref="ILogger" />
    /// <inheritdoc cref="IMessagesStream" />
    /// <summary>
    /// Default implementation of <see cref="ILogger"/> which also implements <see cref="IMessagesStream"/>.
    /// </summary>
    public class DefaultLogger : ILogger, IMessagesStream
    {
        [NotNull]
        private readonly IMessageSourceStackLocator _messageSourceStackLocator;

        [NotNull]
        private readonly MessagesStreamSubject _subject = new MessagesStreamSubject();

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultLogger"/> class.
        /// </summary>
        /// <param name="messageSourceStackLocator"></param>
        public DefaultLogger([NotNull] IMessageSourceStackLocator messageSourceStackLocator)
        {
            _messageSourceStackLocator = messageSourceStackLocator ??
                                         throw new ArgumentNullException(nameof(messageSourceStackLocator));
        }

        /// <inheritdoc />
        [IgnoreMessageSourceStack]
        public void Log(Message message)
        {
            var dateTime = DateTime.Now;
            var stackTrace = new StackTrace();
            var source = _messageSourceStackLocator.Locate(stackTrace);

            var context = new MessageContext(source, dateTime);

            _subject.OnNext(message, context);
        }

        /// <inheritdoc />
        public IDisposable Subscribe(IMessagesStreamObserver observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException(nameof(observer));
            }

            return _subject.Subscribe(observer);
        }
    }
}