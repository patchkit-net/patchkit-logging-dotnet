using System.Diagnostics;
using NUnit.Framework;
using PatchKit.Logging;

namespace Test
{
    [TestFixture]
    public class DefaultLogStackFrameLocatorTest
    {
        private static DefaultLogStackFrameLocator CreateInstance()
        {
            return new DefaultLogStackFrameLocator();
        }
        
        private static StackTrace Func()
        {
            return new StackTrace();
        }
        
        [IgnoreLogStackTrace]
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

            var stackFrame = locator.Locate(stackTrace);
            
            Assert.AreEqual("Func", stackFrame.GetMethod().Name);
        }
        
        [Test]
        public void Locate_ForStackTraceWithIgnoredMethod_DoesntReturnIgnoredMethod()
        {
            var locator = CreateInstance();
            
            var stackTrace = Func_Ignored();

            var stackFrame = locator.Locate(stackTrace);
            
            Assert.AreNotEqual("Func_Ignored", stackFrame.GetMethod().Name);
        }

        [Test]
        public void Locate_ForStackTraceWithIgnoredMethod_ReturnsNextMethod()
        {
            var locator = CreateInstance();
            
            var stackTrace = Func_CallingIgnored();

            var stackFrame = locator.Locate(stackTrace);
            
            Assert.AreEqual("Func_CallingIgnored", stackFrame.GetMethod().Name);
        }
        
        [Test]
        public void Locate_ForStackTraceWithNestedMethod_ReturnsFirstMethod()
        {
            var locator = CreateInstance();
            
            var stackTrace = Func_CallingNormal();

            var stackFrame = locator.Locate(stackTrace);
            
            Assert.AreEqual("Func", stackFrame.GetMethod().Name);
        }
    }
}