using System;
using System.Diagnostics;
using NSubstitute;
using NUnit.Framework;
using PatchKit.Logging;
// ReSharper disable PossibleNullReferenceException
// ReSharper disable AssignNullToNotNullAttribute

namespace Test
{
    [TestFixture]
    public class DefaultLoggerTests
    {
        private static DefaultLogger CreateInstance()
        {
            var messageSourceStackLocator = Substitute.For<IMessageSourceStackLocator>();
            messageSourceStackLocator.Locate(Arg.Any<StackTrace>()).Returns(default(MessageSource));

            return new DefaultLogger(messageSourceStackLocator);
        }

        [Test]
        public void Log_ForAnyMessage_SubscribersAreReceivingMessage()
        {
            var logger = CreateInstance();
            var observer = Substitute.For<IMessagesStreamObserver>();

            logger.Subscribe(observer);

            var message = new Message("Test", MessageType.Debug, null);

            logger.Log(message);
            
            observer.Received(1).OnNext(Arg.Is(message), Arg.Any<MessageContext>());
        }

        [Test]
        public void Log_ForAnyMessage_DisposedSubscribersAreNotReceivingMessages()
        {
            var logger = CreateInstance();
            var observer = Substitute.For<IMessagesStreamObserver>();

            logger.Subscribe(observer).Dispose();

            logger.Log(new Message("Test", MessageType.Debug, null));
            
            observer.DidNotReceive().OnNext(Arg.Any<Message>(), Arg.Any<MessageContext>());
        }

        [Test]
        public void Log_ForAnyMessage_ExceptionCausedBySubscriberIsNotRethrown()
        {
            var logger = CreateInstance();
            var observer = Substitute.For<IMessagesStreamObserver>();

            observer
                .When(x => x.OnNext(Arg.Any<Message>(), Arg.Any<MessageContext>()))
                .Do(x => throw new Exception());
            
            logger.Subscribe(observer);
            
            Assert.DoesNotThrow(() => logger.Log(new Message("Test", MessageType.Debug, null)));
        }
    }
}