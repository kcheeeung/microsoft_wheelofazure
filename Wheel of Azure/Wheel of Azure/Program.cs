using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wheel_of_Azure
{
    public class Program
    {
        static void Main(string[] args)
        {
            string solution = "Hello World";
            Console.WriteLine("Would you like to SPIN the wheel or SOLVE the phrase?");
            
            string firstChoice = "";
            while(firstChoice != "spin" && firstChoice != "solve") {
                Console.Write("Type SPIN or SOLVE: ");
                firstChoice = Console.ReadLine().ToLower();
            }

            
            if (firstChoice == "spin")
            {
                Console.WriteLine("You picked spin");
            }
            else if(firstChoice == "solve")
            {
                Console.Write("Take your guess ");
                string solveGuess = Console.ReadLine().ToLower();
                if (solveGuess != solution.ToLower())
                    Console.WriteLine("Please Try Again");
                else
                    Console.WriteLine("You Win!");
            }
            Console.ReadLine();
        }
    }
}
