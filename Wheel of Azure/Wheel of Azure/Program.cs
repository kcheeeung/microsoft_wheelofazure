using System;
using System.Text.RegularExpressions;

namespace Wheel_of_Azure
{
    public class Program
    {
        static string phrase = "abc";
        static Wheel wheel = new Wheel();
        static PhraseBoard phraseBoard = new PhraseBoard(phrase);
        static Player playerOne;

        static void Main(string[] args)
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            playerOne = new Player(name);

            Console.WriteLine("Welcome to Wheel of Azure {0}!", playerOne.Name);
            while (!phraseBoard.IsGameOver())
            {
                Console.WriteLine("Total Score: ${0} ", playerOne.TurnScore);
                phraseBoard.DisplayBoard();
                bool isNumeric = false;
                int userChoice;
                do
                {
                    Console.WriteLine("Enter 1 to Spin, or 2 to Solve");
                    string choice = Console.ReadLine();
                    isNumeric = int.TryParse(choice, out userChoice);
                } while (!isNumeric || (userChoice != 1 && userChoice != 2));

                phraseBoard.DisplayBoard();
                if (userChoice == 1)
                {
                    Spin();
                }
                else
                {
                    Solve();
                }
            }
            Console.WriteLine("Total Score: ${0} ", playerOne.TurnScore);
            phraseBoard.DisplayBoard();
            Console.WriteLine("You win! Press enter to exit.");
            Console.ReadLine();
        }

        /// <summary>
        /// Spins the wheel and asks the user to make a guess.
        /// </summary>
        public static void Spin()
        {
            int wheelAmount = wheel.WheelSpin();
            Console.WriteLine("The wheel landed at ${0}", wheelAmount);

            if (wheelAmount > 0)
            {
                Console.Write("Guess a letter: ");
                string spinGuess = Console.ReadLine().ToLower();
                char spinGuessLetter = SingleLettersOnly(spinGuess);

                //If the character has already been guessed, then it will prompt the user to type in one that has not.
                while (phraseBoard.HasGuessed(spinGuessLetter))
                {
                    Console.Write("{0} has already been guessed. Guess again: ", spinGuessLetter);
                    spinGuess = Console.ReadLine().ToLower();
                    spinGuessLetter = SingleLettersOnly(spinGuess);
                }

                //if the phrase contains the character, the program tells the user of this and tell them how much they won. 
                //It then goes back to the spin or solve function.
                int pointsEarned = phraseBoard.MakeGuess(wheelAmount, spinGuessLetter);
                if (pointsEarned > 0)
                {
                    Console.WriteLine("The phrase indeed includes {0}. You won ${1}!", spinGuessLetter, pointsEarned);
                    playerOne.AddCurrentScore(pointsEarned);
                }
                //if it does not contain the character, it tells the user it has not have it and to guess again.
                //It then goes back to the spin or solve function.
                else
                {
                    Console.WriteLine("The phrase does not include {0}. Try again next turn!", spinGuessLetter);
                }
            }
            else
            {
                Console.WriteLine("Sorry, you lose a turn");
            }
        }

        /// <summary>
        /// Asks the user to solve the phrase.
        /// </summary>
        public static void Solve()
        {
            //Prompts the user to solve the phrase. If they get it right, they win. 
            //If not, then it goes back to the spin or solve function.
            Console.Write("Solve the phrase: ");
            string solveGuess = Console.ReadLine().ToLower();
            int pointsEarned = phraseBoard.MakeGuess(solveGuess);
            if (pointsEarned <= 0)
            {
                Console.WriteLine("The phrase is not {0}. Please try again", solveGuess);
            }
            else
            {
                playerOne.AddCurrentScore(pointsEarned);
            }
        }

        /// <summary>
        /// Checks if user's input is a single char.
        /// Repeated asks until there is a valid input.
        /// </summary>
        /// <param name="spinGuess">The user's entered input</param>
        /// <returns>The spin guess as a char</returns>
        public static char SingleLettersOnly(string spinGuess)
        {
            while (spinGuess.Length != 1 || !Regex.IsMatch(spinGuess, @"^[a-z]+$"))
            {
                Console.Write("Type in a single character only, please: ");
                spinGuess = Console.ReadLine().ToLower();
            }
            return spinGuess[0];
        }

    }
}
