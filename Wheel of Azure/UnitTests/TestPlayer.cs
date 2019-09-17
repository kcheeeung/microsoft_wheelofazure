using System;
using Wheel_of_Azure;
using Xunit;

namespace UnitTests_Player
{
    public class Test_Player
    {
        [Fact]
        public void Test_PlayerConstructor()
        {
            Player p = new Player("Joe");
            Assert.Equal("Joe", p.Name);
            Assert.Equal(0, p.TurnScore);
            Assert.Equal(0, p.TotalScore);
        }

        [Fact]
        public void Test_AddCurrentScore()
        {
            Player p = new Player("Joe");
            p.AddCurrentScore(100);
            Assert.Equal(100, p.TurnScore);
            p.AddCurrentScore(100);
            Assert.Equal(200, p.TurnScore);
        }

        [Fact]
        public void Test_ResetScoreAndTotal()
        {
            Player p = new Player("Joe");
            p.AddCurrentScore(100);
            p.ResetCurrentAndTotalScores();
            Assert.Equal(0, p.TurnScore);
            Assert.Equal(100, p.TotalScore);
        }
    }
}
