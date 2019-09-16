using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Wheel_of_Azure
{
    public class Program
    {
        static string phrase = "MICROSOFT LEAP";
        //static Wheel wheel = new Wheel();
        //static Board board = new Board(phrase);
        static Player playerOne;

        static void Main(string[] args)
        {   
            int round_score = 0;
            int spin_value = 10;

            Console.WriteLine("Please enter your name");
            string name = Console.ReadLine();
            playerOne = new Player(name);

            Console.WriteLine("Welcome to Wheel of Azure {0}!", playerOne.Name.ToLower());
            while (true)
            {
                Console.WriteLine("Total Score: {0} ", playerOne.TotalScore);
                //board.DisplayBoard();
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


                Console.WriteLine("valid");
                if(userChoice == 1)
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
            int wheelAmount = wheel.SpinWheel();
            //placeholder for score generated from wheel.
            Console.WriteLine("The wheel landed at ${0}", wheelAmount);

            //prompts the user to type in a letter. 
            Console.Write("Guess a letter: ");
            string spinGuess = Console.ReadLine().ToLower();
            char spinGuessLetter = SingleLettersOnly(spinGuess);

            //If the character has already been guessed, then it will prompt the user to type in one that has not.
            while (board.hasGuessed(spinGuessLetter))
            {
                Console.Write("{0} has already been guessed. Guess again: ", spinGuessLetter);
                spinGuess = Console.ReadLine().ToLower();
                spinGuessLetter = SingleLettersOnly(spinGuess);
            }

            //if the phrase contains the character, the program tells the user of this and tell them how much they won. 
            //It then goes back to the spin or solve function.
            int pointsEarned = board.MakeGuess(wheelAmount, spinGuessLetter);

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

        public static void Solve()
        {
            //Prompts the user to solve the phrase. If they get it right, they win. 
            //If not, then it goes back to the spin or solve function.
            Console.Write("Solve the phrase: ");
            string solveGuess = Console.ReadLine().ToLower();
            if (board.MakeGuess(solveGuess) <= 0)
            {
                Console.WriteLine("The phrase is not {0}. Please try again", solveGuess);
            }
        }

        public static char SingleLettersOnly(string spinGuess)
        {
            //this function makes sure that a player only puts in a single character. If a player does not, it will continuously ask them until they do.
            while (spinGuess.Length != 1 && !Regex.IsMatch(spinGuess, @"^[a-z]+$"))
            {
                Console.Write("Type in a single character only, please: ");
                spinGuess = Console.ReadLine().ToLower();
            }
            return spinGuess[0];
        }

    }
}
