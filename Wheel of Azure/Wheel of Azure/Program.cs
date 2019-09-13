using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
                string phrase = "MICROSOFT LEAPO";
                Console.WriteLine("Please enter your name");
                string name = Console.ReadLine();
                Console.WriteLine("Welcome to Wheel of Azure {0}!", name.ToUpper());
                Console.WriteLine("Current Score: {0} ", round_score);


                char[] guess = new char[phrase.Length];
                Console.Write("Please enter your guess: ");

                for (int p = 0; p < phrase.Length; p++)
                {
                    guess[p] = '*';

                }


                while (true)
                {
                    Console.WriteLine(guess);
                    count = 0;
                    char playerGuess = char.Parse(Console.ReadLine().ToUpper());
                    for (int i = 0; i < phrase.Length; i++)
                    {
                        if (playerGuess == phrase[i])
                        {
                            guess[i] = playerGuess;
                            round_score = round_score + spin_value;
                            count++;
                        }

                    }
                    if(count > 0)
                    {
                        Console.WriteLine("Congratulations there are {0} matching letters", count);
                        Console.WriteLine("Your score has been incremented by {0}", count * spin_value);
                        Console.WriteLine("Letter Count : {0} ", count);
                    }
                    else
                    {
                        Console.WriteLine("Sorry that letter is not in the word. Please guess again.");
                    }
                    Console.WriteLine("Total Score: {0} ", round_score);
                }
            }

        }
    }
}
