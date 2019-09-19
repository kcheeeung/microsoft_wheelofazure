using System;
using System.Collections;
using System.Collections.Generic;

namespace Wheel_of_Azure
{
    public class PhraseBoard
    {
        private string CorrectAnswer;
        private List<char> Board;
        private HashSet<char> Guesses;
        private Hashtable LetterCounts;

        /// <summary> 
        /// This constructor method. Takes a string as an argument and stores the string into the 
        /// phrase board. Also updates the hash table with the characters in the string. 
        /// </summary>
        public PhraseBoard(string inputPhrase)
        {
            CorrectAnswer = inputPhrase;
            Board = new List<char>();
            Guesses = new HashSet<char>();
            LetterCounts = new Hashtable();

            foreach (char letter in inputPhrase)
            {
                // Add characters to hash table (dictionary), if the character is alphabetical character
                if (!LetterCounts.ContainsKey(letter))
                {
                    LetterCounts.Add(letter, 1);
                }
                else
                {
                    LetterCounts[letter] = (int)LetterCounts[letter] + 1;
                }

                // If non-alphabetical, add character to the Board list (as is), else add '*' to the Board list
                if (char.IsLetter(letter))
                {
                    Board.Add('*');
                }
                else
                {
                    Board.Add(letter);
                }
            }
        }

        public bool IsGameOver()
        {
            return LetterCounts.Keys.Count == 0;
        }

        /// <summary>
        /// Displays the phrase to the console. Returns void.
        /// </summary>
        public void DisplayBoard()
        {
            if (!IsGameOver())
            {
                foreach (char letter in Board)
                {
                    Console.Write(letter);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(CorrectAnswer);
            }
        }

        /// <summary>
        /// Determines how much money is received from current spin. basedDollarValue is the value of the current spin. 
        /// </summary>
        public int MakeGuess(int baseDollarValue, char guessedChar)
        {
            // Update guess hash set with guess 
            Guesses.Add(guessedChar);

            // Updates board
            UpdateBoard(guessedChar);

            // Determine if char is in hash table. If found, calcuate amount won. If not found, return zero.
            if (LetterCounts.ContainsKey(guessedChar))
            {
                int points = (int) LetterCounts[guessedChar] * baseDollarValue;
                LetterCounts.Remove(guessedChar);
                return points;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Determines how much is received from attempting to solve the phrase. 
        /// </summary>
        public int MakeGuess(string guessedString)
        {
            if (guessedString == CorrectAnswer)
            {
                LetterCounts.Clear();
                return 5000;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Checks if the guessed character is found in the hashset. If located, returns true. If not found, returns false.
        /// </summary>
        public bool HasGuessed(char guessedChar)
        {
            return Guesses.Contains(guessedChar);
        }

        /// <summary>
        /// Static method that updates the board based on character guessed character. Returns void.
        /// </summary>
        private void UpdateBoard(char guessedChar)
        {
            // TODO: Determine more efficient way to update board.
            // Loop phrase and determine where character should be placed on the board.
            for (int i = 0; i < CorrectAnswer.Length; i++)
            {
                if (CorrectAnswer[i] == guessedChar)
                {
                    Board[i] = guessedChar;
                }
            }
        }
    }
}

