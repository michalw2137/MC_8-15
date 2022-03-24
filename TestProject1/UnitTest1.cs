using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddTest()
        { 
            Assert.AreEqual(ConsoleApp1.Program.add(1, 5), 6);
            Assert.AreEqual(ConsoleApp1.Program.add(1, -1), 0);
            Assert.AreEqual(ConsoleApp1.Program.add(1, -5), -4);
        }
        [TestMethod]
        public void SubtractTest()
        {
            Assert.AreEqual(ConsoleApp1.Program.subtract(1, 0), 1);
            Assert.AreEqual(ConsoleApp1.Program.subtract(1, 8), -7);
            Assert.AreEqual(ConsoleApp1.Program.subtract(1, -5), 6);
        }
        [TestMethod]
        public void MultiplyTest()
        {
            Assert.AreEqual(ConsoleApp1.Program.multiply(1, 0), 0);
            Assert.AreEqual(ConsoleApp1.Program.multiply(2, 8), 16);
            Assert.AreEqual(ConsoleApp1.Program.multiply(3, -5), -15);
        }
        [TestMethod]
        public void DivideTest()
        {
            Assert.AreEqual(ConsoleApp1.Program.divide(8, 2), 4);
            Assert.AreEqual(ConsoleApp1.Program.divide(-8, 2), -4);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "CANNOT DIVIDE BY 0")]
        public void DivideExcepionTest()
        {
            ConsoleApp1.Program.divide(10, 0);
        }
    }
}
