using System;

namespace Wheel_of_Azure
{
    public class Player
    {
        public string Name { get; set; }
        public int TurnScore { get; set; }
        public int TotalScore { get; set; }

        /// <summary>
        /// Creates a player class that keeps track of name, current and total score
        /// </summary>
        /// <param name="n"></param>
        public Player(string n)
        {
            Name = n;
            TurnScore = 0;
            TotalScore = 0;
        }

        /// <summary>
        /// Takes in score i and adds to current score
        /// </summary>
        public void AddCurrentScore(int i)
        {
            TurnScore += i;
        }

        /// <summary>
        /// Resets the current code and adds to total
        /// </summary>
        public void ResetCurrentAndTotalScores()
        {
            int curr = TurnScore;
            TurnScore = 0;
            TotalScore += curr;
        }
    }
}
