﻿using System;
using System.IO;
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

        [Fact]
        public void TestMethod2()
        {
            
            using (StringWriter consoleText = new StringWriter())
            {
                Console.SetOut(consoleText);
                Program.SingleLettersOnly("bb");
                Program.SingleLettersOnly("b");

                Assert.Equal("Type in a single character only, please: ", consoleText.ToString());
            }
           
        }
    }
}