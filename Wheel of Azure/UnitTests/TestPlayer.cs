using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wheel_of_Azure;

namespace UnitTests_Player
{
    [TestClass]
    public class TestPlayer
    {
        [TestMethod]
        public void TestPlayerConstructor()
        {
            Player p = new Player("Joe");
            Assert.AreEqual("Joe", p.Name);
            Assert.AreEqual(0, p.TurnScore);
            Assert.AreEqual(0, p.TotalScore);
        }

        [TestMethod]
        public void TestCalculateScore()
        {
            Player p = new Player("Joe");
            p.AddCurrentScore(100);
            Assert.AreEqual(100, p.TurnScore);
        }

        [TestMethod]
        public void ResetScoreAndTotal()
        {
            Player p = new Player("Joe");
            p.AddCurrentScore(100);
            p.ResetCurrentAndTotalScores();
            Assert.AreEqual(0, p.TurnScore);
            Assert.AreEqual(100, p.TotalScore);
        }
    }
}
