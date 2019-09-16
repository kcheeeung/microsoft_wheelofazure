using System;
using System.Collections.Generic;

namespace Wheel_of_Azure
{
    public class Wheel
    {
        public List<int> WheelOfAzure;

        public Wheel()
        {
            WheelofAzure = new List<int> {
                2500,
                600,
                700,
                600,
                650,
                500,
                700,
                0,
                0,
                0,
                0,
                0,
                600,
                550,
                500,
                600,
                650,
                700,
                800,
                500,
                800,
                500,
                650,
                500
            };
        } // end Wheel constructor

            public int WheelSpin()
            {
                // Randomly generate number from wheel
                Random random = new Random();

                int wheelPrizeDollarIndex = random.Next(WheelOfAzure.Count);
                int wheelPrizeDollarAmount = WheelOfAzure[wheelPrizeDollarIndex];

                return wheelPrizeDollarAmount;
            } // end WheelSpin method


            /* public int[] NewWheel()
             {
                 // TODO: Method when multiple rounds+		this	{Wheel_of_Azure.Wheel}	Wheel_of_Azure.Wheel


             } // end NewWheel method
             */

        } // end Wheel class

        //public class Program
        //{
        //    static void Main(string[] args)
        //    {
        //        Console.WriteLine("testing the link");
        //        Console.ReadKey();
        //        Console.WriteLine();

        //        Wheel wheel = new Wheel();
        //        int prize = wheel.WheelSpin();
        //        Console.WriteLine(prize);

        //        int prize2 = wheel.WheelSpin();
        //        Console.WriteLine(prize2);
        //        Console.ReadKey();

                
        //    }
        //}
    }
