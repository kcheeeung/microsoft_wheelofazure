using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Wheel_of_Azure
{
    public class Program
    {
        static void Main(string[] args)

        {   
            {
                int round_score = 0;
                int spin_value = 10;
                int count;


                string phrase = "MICROSOFT LEAP";
                Console.WriteLine("Please enter your name");
                string name = Console.ReadLine();
                Player One = new Player(name);

                //Wheel wheel = new Wheel();
                //Board board = new Board(phrase);



                Console.WriteLine("Welcome to Wheel of Azure {0}!", One.Name.ToUpper());




                while (true)
                {
                    Console.WriteLine("Total Score: {0} ", One.TotalScore);
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
                    //if(userChoice == 1)
                    //{
                    //    Spin();
                    //}
                    //else
                    //{
                    //    Solve();
                    //}
                }
                Console.WriteLine("You win!");
            }

        }
    }
}
