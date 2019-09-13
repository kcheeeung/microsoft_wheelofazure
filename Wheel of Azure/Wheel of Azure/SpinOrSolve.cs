using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wheel_of_Azure
{
    class SpinOrSolve
    {
        static string spinGuess = "";
        //this is the solution. It is a placeholder.
        static string solution = "Hello World";
        //guessedLetters is an array containing all the letters that have already been guessed.
        static ArrayList guessedLetters = new ArrayList();
        //placeholder for dollar amount generated from wheel.
        static int wheelAmount = 400;


        static void Main(string[] args)
        {
            //placeholder for guessed letters.
            guessedLetters.Add("a");
            guessedLetters.Add("o");
            guessedLetters.Add("l");
            guessedLetters.Add("h");

            //SpinOrSolveFunction initializes the game.
            SpinOrSolveFunction();

            Console.ReadLine();
        }

        public static void SpinOrSolveFunction()
        {
            Console.WriteLine("Would you like to SPIN the wheel or SOLVE the phrase?");

            //this requires the player to type in "spin or solve"
            string firstChoice = "";
            while (firstChoice != "spin" && firstChoice != "solve")
            {
                //if they do not type in spin or solve, then it will prompt the user to do that.
                Console.Write("Type SPIN or SOLVE: ");
                firstChoice = Console.ReadLine().ToLower();
            }

            //if a user types in spin, it loads the spin function. If he or she types in solve, it loads the solve function.
            if (firstChoice == "spin")
                Spin();
            else if (firstChoice == "solve")
                Solve();
        }

        public static void SingleLettersOnly()
        {
            //this function makes sure that a player only puts in a single character. If a player does not, it will continuously ask them until they do.
            while (spinGuess.Length != 1 || !Regex.IsMatch(spinGuess, @"^[a-z]+$"))
            {
                Console.Write("Type in a single character only, please: ");
                spinGuess = Console.ReadLine().ToLower();
            }
        }

        public static void Spin()
        {
            //placeholder for score generated from wheel.
            Console.WriteLine("The wheel landed at ${0}", wheelAmount);

            //prompts the user to type in a letter. 
            Console.Write("Guess a letter: ");
            spinGuess = Console.ReadLine().ToLower();
            SingleLettersOnly();

            //If the character has already been guessed, then it will prompt the user to type in one that has not.
            while (guessedLetters.Contains(spinGuess))
            {
                Console.Write("{0} has already been guessed. Guess again: ", spinGuess);
                spinGuess = Console.ReadLine().ToLower();
                SingleLettersOnly();
            }
            //if the phrase contains the character, the program tells the user of this and tell them how much they won. 
            //It then goes back to the spin or solve function.
            if (solution.Contains(spinGuess))
            {
                Console.WriteLine("The phrase indeed includes {0}. You won ${wheelAmount}!", spinGuess, wheelAmount);
                guessedLetters.Add(spinGuess);
                SpinOrSolveFunction();
            }
            //if it does not contain the character, it tells the user it has not have it and to guess again.
            //It then goes back to the spin or solve function.
            else
            {
                Console.WriteLine("The phrase does not include {0}. Try again next turn!", spinGuess);
                guessedLetters.Add(spinGuess);
                SpinOrSolveFunction();
            }


        }

        public static void Solve()
        {
            //Prompts the user to solve the phrase. If they get it right, they win. 
            //If not, then it goes back to the spin or solve function.
            Console.Write("Solve the phrase: ");
            string solveGuess = Console.ReadLine().ToLower();
            if (solveGuess != solution.ToLower())
            {
                Console.WriteLine("The phrase is not {0}. Please try again", solveGuess);
                SpinOrSolveFunction();
            }
            else
                Console.WriteLine("The phrase is inded {0}. You Win!", solveGuess);
        }

    }
}
