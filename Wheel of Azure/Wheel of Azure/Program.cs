using System;
using System.Text.RegularExpressions;

namespace Wheel_of_Azure
{

    public class Program
    {
        static string phrase = "microsoft leap";
        static Wheel wheel = new Wheel();
        static PhraseBoard phraseBoard = new PhraseBoard(phrase);
        static Player playerOne;

        static void Main(string[] args)
        {   
            int round_score = 0;
            int spin_value = 10;

            Console.WriteLine("Please enter your name");
            string name = Console.ReadLine();
            playerOne = new Player(name);

            Console.WriteLine("Welcome to Wheel of Azure {0}!", playerOne.Name.ToLower());
            while (!phraseBoard.IsGameOver)
            {
                Console.WriteLine("Total Score: {0} ", playerOne.TotalScore);
                //phraseBoard.DisplayBoard();
                bool isNumeric = false;
                bool isValid = false;
                int userChoice;
                do
                {
                    Console.WriteLine("Enter 1 to Spin, or 2 to Solve");
                    string choice = Console.ReadLine();
                    isNumeric = int.TryParse(choice, out userChoice);
                    if (userChoice == 1 || userChoice == 2)
                    {
                        isValid = true;
                    }
                } while (!isNumeric || !isValid);

                phraseBoard.DisplayBoard();
                Console.WriteLine("valid");
                if (userChoice == 1)
                {
                    Spin();
                }
                else
                {
                    Solve();
                }
            }
            Console.WriteLine("You win!");
        }

        public static void Spin()
        {
            int wheelAmount = wheel.WheelSpin();
            //placeholder for score generated from wheel.
            Console.WriteLine("The wheel landed at ${0}", wheelAmount);

            //prompts the user to type in a letter. 
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


        public static char SingleLettersOnly(string spinGuess)
        {
            //this function makes sure that a player only puts in a single character. If a player does not, it will continuously ask them until they do.
            while (spinGuess.Length != 1 || !Regex.IsMatch(spinGuess, @"^[a-z]+$"))
            {
                Console.Write("Type in a single character only, please: ");
                spinGuess = Console.ReadLine().ToLower();
            }

            return spinGuess[0];
        }
    }
}
