using System;
using System.IO;
using System.Threading;
using Wheel_of_Azure;
using Xunit;

namespace UnitTests
{
    public class TestSingleLetter
    {
        [Fact]
        public void TestMethod1()
        {
            char result = Program.SingleLettersOnly("b");
            Assert.Equal('b', result);
        }

        //[Fact]
        //public void TestMethod2()
        //{
            
        //    using (StringWriter consoleText = new StringWriter())
        //    {
        //        int elapsed = 0;
        //        while (elapsed < 1000)
        //        {
        //            Console.SetOut(consoleText);
        //            elapsed += 1000;
        //            Program.SingleLettersOnly("bb");
        //        }
        //        Assert.Equal("Type in a single character only, please: ", consoleText.ToString());
        //    }

        //}


    }
}
