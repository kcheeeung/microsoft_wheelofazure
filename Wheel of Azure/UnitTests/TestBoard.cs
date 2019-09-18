using System;
using System.IO;
using System.Text;
using Wheel_of_Azure;
using Xunit;
using Xunit.Abstractions;
using W = Wheel_of_Azure;

namespace UnitTests
{
    //[ClassInterfaceAttribute]
    public class TestBoard
    {
        public W.PhraseBoard board;
        private readonly ITestOutputHelper output;
        public TextWriter outputWriter;
        public string number;
        private string inputString;
        public TestBoard()
        {
            string inputString = "5";
            board = new W.PhraseBoard(inputString);

            //this.outputWriter = outputWriter;
            //this.number = inputString;
        }

        [Fact]
        public void PrintString()
        {
            outputWriter.WriteLine("String: " + number);
        }

        [Fact]
        public void TestDisplayBoard()
        {
            /*using (StreamWriter consoleText = new StreamWriter())
            {
                board.DisplayBoard();
                Console.SetOut(consoleText);
                Assert.Equal("***** *'**", consoleText.ToString());
            }*/

            const string NumberToPrint = "5";
            var content = new StringBuilder();
            TextWriter writer = new StringWriter(content);
            var sut = new TestBoard();

            sut.PrintString();

            var actualOutput = content.ToString();
            Assert.Equal("Number: 5", actualOutput);
        }

        [Fact]
        public void TestMakeGuessCharWinPrizeandGameContd()
        {

            var resultDollarAmount = board.MakeGuess(500, 'Y');
            Assert.Equal(500, resultDollarAmount);
        }

        [Fact]
        public void TestMakeGuessCharWinPrizeandGameEnd()
        {

        }

        [Fact]
        public void TestMakeGuessCharNoPrize()
        {

        }

        [Fact]
        public void TestMakeGuessStringWin()
        {

        }

        [Fact]
        public void TestMakeGuessStringLose()
        {

        }

        [Fact]
        public void TestSetIsGameOver()
        {

        }

        [Fact]
        public void TestHasGuessedTrue()
        {

        }

        [Fact]
        public void TestHasGuessedFalse()
        {

        }

        [Fact]
        public void TestUpdateBoard()
        {

        }
    }
}
