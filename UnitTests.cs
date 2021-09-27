using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoggerRateLimiter
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestMethod()
        {
            Logger logger = new Logger();

            // logging string "foo" at timestamp 1
            Assert.IsTrue(logger.ShouldPrintMessage(1, "foo")); 

            // logging string "bar" at timestamp 2
            Assert.IsTrue(logger.ShouldPrintMessage(2,"bar"));

            // logging string "foo" at timestamp 3
            Assert.IsFalse(logger.ShouldPrintMessage(3,"foo"));

            // logging string "bar" at timestamp 8
            Assert.IsFalse(logger.ShouldPrintMessage(8,"bar"));

            // logging string "foo" at timestamp 10
            Assert.IsFalse(logger.ShouldPrintMessage(10,"foo"));

            // logging string "foo" at timestamp 11
            Assert.IsTrue(logger.ShouldPrintMessage(11,"foo"));

            // logging string "foo" at timestamp 12
            Assert.IsFalse(logger.ShouldPrintMessage(12,"foo"));
        }
    }
}
