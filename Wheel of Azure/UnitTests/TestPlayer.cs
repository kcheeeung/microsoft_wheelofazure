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
            Random random = new Random();
            int total = 0;
            for (int i = 0; i < 20; i++)
            {
                int score = random.Next();
                if (score % 2 == 0)
                {
                    p.AddCurrentScore(-score);
                    total += (-score);
                }
                else
                {
                    p.AddCurrentScore(score);
                    total += score;
                }
            }
            Assert.Equal(total, p.TurnScore);
        }

        [Fact]
        public void Test_ResetScoreAndTotal()
        {
            Player p = new Player("Joe");
            p.AddCurrentScore(100);
            p.ResetCurrentAndTotalScores();
            Assert.Equal(0, p.TurnScore);
            Assert.Equal(100, p.TotalScore);
            p.AddCurrentScore(100);
            p.ResetCurrentAndTotalScores();
            Assert.Equal(0, p.TurnScore);
            Assert.Equal(200, p.TotalScore);
        }
    }
}
