using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Methods
{
    public class Helpers
    {
        public static string CheckStringInput()
        {
            bool tryAgain = true;
            string? outPut = "";
            while (tryAgain)
            {
                outPut = Console.ReadLine();
                if (outPut == null)
                {
                    Console.WriteLine("Your input must contain atleast one character");
                }
                else if (outPut.Length > 0)
                {
                    tryAgain = false;
                }
                else
                {
                    Console.WriteLine("Your input must contain atleast one character");
                }

            }
            return outPut;
        }
        internal static void PressAnyKey()
        {
            Console.WriteLine("\nPress any key to continue: ");
            Console.ReadKey(true);
        }
        public static int TryNumber(int number, int maxValue, int minValue)             
        {
            bool correctInput = false;
            while (!correctInput)
            {
                if (!int.TryParse(Console.ReadLine(), out number) || number > maxValue || number < minValue)
                {
                    Console.Write("Wrong input, try again: ");
                }
                else
                {
                    correctInput = true;
                }
            }
            return number;
        }
        public static int TryNumber(int number)
        {
            bool correctInput = false;
            while (!correctInput)
            {
                if (!int.TryParse(Console.ReadLine(), out number))
                {
                    Console.Write("Wrong input, try again: ");
                }
                else
                {
                    correctInput = true;
                }
            }
            return number;
        }
    }
}
