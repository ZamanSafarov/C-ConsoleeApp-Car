using Final_Project.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Managers
{
    public static class HelpManager
    {
        public static int ReadInteger(string caption)
        {
        l1:
            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            if (!int.TryParse(Console.ReadLine(), out int value))
            {
                PrintError("Wrong!!,Try again");
                goto l1;
            }
            Console.ResetColor();
            return value;
        }
        public static double ReadDouble(string caption)
        {
        l1:
            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;


            if (!double.TryParse(Console.ReadLine(), out double value))
            {
                PrintError("Wrong!!,Try again");
                goto l1;
            }
            Console.ResetColor();
            return value;
        }
        public static string ReadString(string caption)
        {
        l1:


            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            string value = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(value))
            {
                PrintError("Wrong!!,Try again");
                goto l1;
            }
            Console.ResetColor();
            return value;
        }
        public static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        

        public static Menu ReadMenu(string caption)
        {
        l1:

            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            if (!Enum.TryParse(Console.ReadLine(), out Menu m))
            {

                PrintError("You did not choose from Menu,Try again!!!");
                goto l1;
            }
            Console.ResetColor();
            return m;
        }
        public static Fueltype ReadFuelMenu(string caption)
        {
        l1:

            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            if (!Enum.TryParse(Console.ReadLine(), out Fueltype f))
            {
                PrintError("You did not choose from Menu,Try again!!!");
                goto l1;
            }
            Console.ResetColor();
            return f;
        }
    }
}
