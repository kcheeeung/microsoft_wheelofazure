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
            Console.WriteLine("Would you like to SPIN the wheel or SOLVE the phrase?");
            
            string firstChoice = "";
            while(firstChoice != "spin" && firstChoice != "solve") {
                Console.Write("Type SPIN or SOLVE: ");
                firstChoice = Console.ReadLine();
            }

            
            if (firstChoice == "spin")
            {
                Console.WriteLine("You picked spin");
            }
            else if(firstChoice == "solve")
            {
                Console.WriteLine("You picked solve");
            }
            Console.ReadLine();
        }
    }
}
