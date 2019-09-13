using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wheel_of_Azure;

namespace UnitTests
{
    [TestClass]
    public class TestWheel
    {
        [TestMethod]
        public void TestAddOne()
        {
            int res = Wheel.Addone(1);
            Assert.AreEqual(2, res);
        }
    }
}
