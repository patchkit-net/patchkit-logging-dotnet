using System;
using System.Diagnostics;
using NUnit.Framework;
using PatchKit.Logging;

namespace Test
{
    [TestFixture]
    public class BasicLogMessageFormatterTests
    {
        [Test]
        public void TypeBracketWidth_ForAllTypes_ShouldBeTheSame()
        {
            var formatter = new BasicLogMessageFormatter();
            
            const string description = "Test";
            var dateTime = new DateTime();
            var stackTrace = new StackTrace();
            
            // only message type is different so all formatted texts should have same length

            int width = formatter.Format(new LogMessage(description, LogMessageType.Trace), dateTime, stackTrace).Length;
            Assert.AreEqual(width,
                formatter.Format(new LogMessage(description, LogMessageType.Debug), dateTime, stackTrace).Length);
            Assert.AreEqual(width,
                formatter.Format(new LogMessage(description, LogMessageType.Warning), dateTime, stackTrace).Length);
            Assert.AreEqual(width,
                formatter.Format(new LogMessage(description, LogMessageType.Error), dateTime, stackTrace).Length);
        }
    }
}