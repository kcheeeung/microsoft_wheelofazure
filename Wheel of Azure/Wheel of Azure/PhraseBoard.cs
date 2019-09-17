using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wheel_of_Azure
{
    class PhraseBoard
    {
        public bool IsGameOver; // TODO: This variable should be private and can have getter/setter methods for outside classes to retrieve the value
        private string CorrectAnswer;
        private List<char> Board;
        private HashSet<char> Guesses;
        private Hashtable LetterCounts;
        

        public PhraseBoard(string inputPhrase)
        {
            /// <summary> 
            /// This constructor method. Takes a string as an argument and stores the string into the 
            /// phrase board. Also updates the hash table with the characters in the string. 
            /// </summary>

            Board = new List<char>();
            LetterCounts = new Hashtable();

            foreach (var letter in inputPhrase)
            {
                //char letter = inputPhrase[i];

                // Add characters to hash table (dictionary), if the character is alphabetical character
                if (!LetterCounts.ContainsKey(letter))
                    LetterCounts.Add(letter, 1);
                else
                    LetterCounts[letter] = (int) LetterCounts[letter] + 1;


                // If non-alphabetical, add character to the Board list (as is), else add '*' to the Board list
                if (Char.IsLetter(letter))
                    Board.Add('*');
                else
                    Board.Add(letter);
            }
        }
        public void DisplayBoard()
        {
            /// <summary>
            /// Displays the phrase board to the console. Returns void.
            /// </summary>

            Console.WriteLine(Board);
        }

        public int MakeGuess(int baseDollarValue, char guessedChar)
        {
            /// <summary>
            /// Determines how much money is received from current spin. basedDollarValue is the value of the current spin. 
            /// </summary>

            // Update guess hash set with guess
            Guesses.Add(guessedChar);

            // Updates board
            UpdateBoard();

            // Check if game over, which updates IsGameOver field
            if (LetterCounts.Count == 0)
                IsGameOver = true;

            // Determine if char is in hash table. If found, calcuate amount won. If not found, return zero.
            if (LetterCounts.ContainsKey(guessedChar))
                return (int)LetterCounts[guessedChar] * baseDollarValue;
            else
                return 0;
        }


        public int MakeGuess(string guessedString)
        {
            /// <summary>
            /// Determines how much is received from attempting to solve the phrase. 
            /// </summary>

            if (guessedString == CorrectAnswer)
                return 5000;
            else
                return 0;

        }

        public bool HasGuessed(char guessedChar)
        {
            /// <summary>
            /// Checks if the guessed character is found in the hashset. If located, returns true. If not found, returns false.
            /// </summary>

            if Guesses.Contains(guessedChar)
                return true;

            else
                return false;
        }

        private static void UpdateBoard()
        {
            /// <summary>
            /// 
            /// </summary>
        }
        
    }
}

