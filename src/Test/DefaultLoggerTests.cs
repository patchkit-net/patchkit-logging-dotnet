using System;
using NSubstitute;
using NUnit.Framework;
using PatchKit.Logging;

namespace Test
{
    [TestFixture]
    public class DefaultLoggerTests
    {
        private static DefaultLogger CreateInstance()
        {
            return new DefaultLogger();
        }

        [Test]
        public void Log_ForAnyMessage_AddedWritersAreRequestedToWriteText()
        {
            var logService = CreateInstance();
            var logWriter = Substitute.For<IMessageWriter>();

            logService.AddWriter(logWriter);

            var message = new Message("Test", MessageType.Debug);
            
            logService.Log(message);
            
            logWriter.Received(1).Write(Arg.Is(message), Arg.Any<MessageContext>());
        }

        [Test]
        public void Log_ForAnyMessage_RemovedWritersAreNotRequestedToWriteText()
        {
            var logService = CreateInstance();
            var logWriter = Substitute.For<IMessageWriter>();

            logService.AddWriter(logWriter);
            logService.RemoveWriter(logWriter);

            logService.Log(new Message("Test", MessageType.Debug));
            
            logWriter.DidNotReceive().Write(Arg.Any<Message>(), Arg.Any<MessageContext>());
        }

        [Test]
        public void Log_ForAnyMessage_ExceptionCausedByWriterIsNotRethrown()
        {
            var logService = CreateInstance();
            var logWriter = Substitute.For<IMessageWriter>();

            logWriter
                .When(x => x.Write(Arg.Any<Message>(), Arg.Any<MessageContext>()))
                .Do(x => { throw new Exception(); });
            
            logService.AddWriter(logWriter);
            
            Assert.DoesNotThrow(() => logService.Log(new Message("Test", MessageType.Debug)));
        }
    }
}