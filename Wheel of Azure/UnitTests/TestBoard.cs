using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using W = Wheel_of_Azure;

namespace UnitTests
{
    //[ClassInterfaceAttribute]
    public class TestBoard
    {
        private readonly W.PhraseBoard board; 
        public TestBoard()
        {
            var inputString = "HELLO Y'ALL";
            board = new W.PhraseBoard(inputString);
        }

        [Fact]
        public void TestDisplayBoard()
        {
            
        }

        [Fact]
        public void TestMakeGuessCharWinPrizeandGameContd()
        {

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
