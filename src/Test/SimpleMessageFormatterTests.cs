using System;
using NUnit.Framework;
using PatchKit.Logging;

// ReSharper disable PossibleNullReferenceException

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
            var context = new MessageContext(default(MessageSource), new DateTime());

            // only message type is different so all formatted texts should have same length

            int width = formatter.Format(new Message(description, MessageType.Trace, null), context).Length;

            Assert.That(formatter.Format(new Message(description, MessageType.Debug, null), context).Length,
                Is.EqualTo(width));

            Assert.That(formatter.Format(new Message(description, MessageType.Warning, null), context).Length,
                Is.EqualTo(width));

            Assert.That(formatter.Format(new Message(description, MessageType.Error, null), context).Length,
                Is.EqualTo(width));
        }

        [Test]
        public void TypeBracketWidth_ForNullSourceTypeAndMethod_ShouldInformAboutUnknownSourceTypeAndMethod()
        {
            var formatter = new SimpleMessageFormatter();

            const string description = "Test";
            var dateTime = new DateTime();

            var text = formatter.Format(new Message(description, MessageType.Trace, null),
                new MessageContext(default(MessageSource), dateTime));
            Assert.That(text.Contains("<unknown_type::unknown_method>"));
        }
    }
}