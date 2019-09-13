using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wheel_of_Azure
{
    public class Program
    {
        static string spinGuess = "";
        static string solution = "Hello World";
        static ArrayList guessedLetters = new ArrayList();
        

        static void Main(string[] args)
        {
            guessedLetters.Add("a");
            guessedLetters.Add("o");
            guessedLetters.Add("l");
            guessedLetters.Add("h");
            SpinOrSolve();

            Console.ReadLine();
        }

        public static void SpinOrSolve()
        {
            Console.WriteLine("Would you like to SPIN the wheel or SOLVE the phrase?");

            string firstChoice = "";
            while (firstChoice != "spin" && firstChoice != "solve")
            {
                Console.Write("Type SPIN or SOLVE: ");
                firstChoice = Console.ReadLine().ToLower();
            }


            if (firstChoice == "spin")
                Spin();
            else if (firstChoice == "solve")
                Solve();
        }

        public static void SingleLettersOnly()
        {
            while (spinGuess.Length != 1 || !Regex.IsMatch(spinGuess, @"^[a-z]+$"))
            {
                Console.Write("Type in a single character only, please: ");
                spinGuess = Console.ReadLine().ToLower();
            }
        }

        public static void Spin()
        {
            Console.WriteLine("The wheel landed at $400");
            Console.Write("Guess a letter: ");
            spinGuess = Console.ReadLine().ToLower();
            SingleLettersOnly();

            while (guessedLetters.Contains(spinGuess))
            {
                Console.Write("{0} has already been guessed. Guess again: ", spinGuess);
                spinGuess = Console.ReadLine().ToLower();
                SingleLettersOnly();
            }
            if (solution.Contains(spinGuess))
            {
                Console.WriteLine("The phrase indeed includes {0}. You won $400!", spinGuess);
                guessedLetters.Add(spinGuess);
                SpinOrSolve();
            }
                
            else
            {
                Console.WriteLine("The phrase does not include {0}. Try again next turn!", spinGuess);
                guessedLetters.Add(spinGuess);
                SpinOrSolve();
            }
            
                
        }

        public static void Solve()
        {
            Console.Write("Solve the phrase: ");
            string solveGuess = Console.ReadLine().ToLower();
            if (solveGuess != solution.ToLower())
            {
                Console.WriteLine("The phrase is not {0}. Please try again", solveGuess);
                SpinOrSolve();
            }
            else
                Console.WriteLine("The phrase is inded {0}. You Win!", solveGuess);
        }
    }
}
