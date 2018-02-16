using System.Diagnostics;
using NUnit.Framework;
using PatchKit.Logging;
// ReSharper disable PossibleNullReferenceException
// ReSharper disable AssignNullToNotNullAttribute

namespace Test
{
    [TestFixture]
    public class DefaultMessageSourceStackLocatorTest
    {
        private static DefaultMessageSourceStackLocator CreateInstance()
        {
            return new DefaultMessageSourceStackLocator();
        }
        
        private static StackTrace Func()
        {
            return new StackTrace();
        }
        
        [IgnoreMessageSourceStack]
        private static StackTrace Func_Ignored()
        {
            return new StackTrace();
        }

        private static StackTrace Func_CallingNormal()
        {
            return Func();
        }
        
        private static StackTrace Func_CallingIgnored()
        {
            return Func_Ignored();
        }

        [Test]
        public void Locate_ForAnyStackTrace_ReturnsFirstMethod()
        {
            var locator = CreateInstance();
            
            var stackTrace = Func();

            var source = locator.Locate(stackTrace);

            Assert.That(source.Method, Is.Not.Null);
            Assert.That(source.Method.Name, Is.EqualTo("Func"));
        }
        
        [Test]
        public void Locate_ForStackTraceWithIgnoredMethod_DoesntReturnIgnoredMethod()
        {
            var locator = CreateInstance();
            
            var stackTrace = Func_Ignored();

            var source = locator.Locate(stackTrace);

            Assert.That(source.Method, Is.Not.Null);
            Assert.That(source.Method.Name, Is.Not.EqualTo("Func_Ignored"));
        }

        [Test]
        public void Locate_ForStackTraceWithIgnoredMethod_ReturnsNextMethod()
        {
            var locator = CreateInstance();
            
            var stackTrace = Func_CallingIgnored();

            var source = locator.Locate(stackTrace);

            Assert.That(source.Method, Is.Not.Null);
            Assert.That(source.Method.Name, Is.EqualTo("Func_CallingIgnored"));
        }
        
        [Test]
        public void Locate_ForStackTraceWithNestedMethod_ReturnsFirstMethod()
        {
            var locator = CreateInstance();
            
            var stackTrace = Func_CallingNormal();

            var source = locator.Locate(stackTrace);

            Assert.That(source.Method, Is.Not.Null);
            Assert.That(source.Method.Name, Is.EqualTo("Func"));
        }
    }
}