using System;
using NSubstitute;
using NUnit.Framework;
using PatchKit.Logging;

namespace Test
{
    [TestFixture]
    public class LogServiceTests
    {
        private static ILogService CreateInstance()
        {
            return new BasicLogService();
        }

        [Test]
        public void Log_ForAnyMessage_AddedWritersAreRequestedToWriteText()
        {
            var logService = CreateInstance();
            var logWriter = Substitute.For<ILogWriter>();

            logService.AddWriter(logWriter);

            logService.Log(new LogMessage("Test", LogMessageType.Debug));
            
            logWriter.Received(1).Write(Arg.Any<string>());
        }

        [Test]
        public void Log_ForAnyMessage_RemovedWritersAreNotRequestedToWriteText()
        {
            var logService = CreateInstance();
            var logWriter = Substitute.For<ILogWriter>();

            logService.AddWriter(logWriter);
            logService.RemoveWriter(logWriter);

            logService.Log(new LogMessage("Test", LogMessageType.Debug));
            
            logWriter.DidNotReceive().Write(Arg.Any<string>());
        }

        [Test]
        public void Log_ForAnyMessage_ExceptionCausedByWriterIsNotRethrown()
        {
            var logService = CreateInstance();
            var logWriter = Substitute.For<ILogWriter>();

            logWriter
                .When(x => x.Write(Arg.Any<string>()))
                .Do(x => { throw new Exception(); });
            
            logService.AddWriter(logWriter);
            
            Assert.DoesNotThrow(() => logService.Log(new LogMessage("Test", LogMessageType.Debug)));
        }
    }
}