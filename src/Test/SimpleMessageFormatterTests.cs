﻿using System;
using System.Diagnostics;
using NUnit.Framework;
using PatchKit.Logging;

namespace Test
{
    [TestFixture]
    public class SimpleMessageFormatterTests
    {
        [Test]
        public void TypeBracketWidth_ForAllTypes_ShouldBeTheSame()
        {
            var formatter = new SimpleMessageFormatter();
            
            const string description = "Test";
            var dateTime = new DateTime();
            var stackTrace = new StackTrace();
            
            // only message type is different so all formatted texts should have same length

            int width = formatter.Format(new Message(description, MessageType.Trace), new MessageContext(stackTrace ,dateTime)).Length;
            Assert.AreEqual(width,
                formatter.Format(new Message(description, MessageType.Debug), new MessageContext(stackTrace ,dateTime)).Length);
            Assert.AreEqual(width,
                formatter.Format(new Message(description, MessageType.Warning), new MessageContext(stackTrace ,dateTime)).Length);
            Assert.AreEqual(width,
                formatter.Format(new Message(description, MessageType.Error), new MessageContext(stackTrace ,dateTime)).Length);
        }
    }
}