using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace PatchKit.Logging
{
    internal class MessagesStreamSubject : IMessagesStream, IMessagesStreamObserver
    {
        private class Subscription : IDisposable
        {
            [NotNull]
            public IMessagesStreamObserver Observer { get; }

            public bool IsDisposed { get; private set; }

            public Subscription([NotNull] IMessagesStreamObserver observer)
            {
                IsDisposed = false;
                Observer = observer;
            }

            public void Dispose()
            {
                IsDisposed = true;
            }
        }

        [NotNull] private readonly HashSet<Subscription> _subscriptions = new HashSet<Subscription>();

        private void ClearDisposedSubscriptions()
        {
            // ReSharper disable once PossibleNullReferenceException
            _subscriptions.RemoveWhere(s => s.IsDisposed);
        }

        public IDisposable Subscribe(IMessagesStreamObserver observer)
        {
            var subscription = new Subscription(observer ?? throw new ArgumentNullException(nameof(observer)));
            _subscriptions.Add(subscription);

            return subscription;
        }

        public void OnNext(Message message, MessageContext messageContext)
        {
            ClearDisposedSubscriptions();

            foreach (var s in _subscriptions)
            {
                try
                {
                    // ReSharper disable once PossibleNullReferenceException
                    s.Observer.OnNext(message, messageContext);
                }
                catch (Exception)
                {
                    // ignored because we cannot let Log throw any exceptions
                }
            }
        }
    }
}