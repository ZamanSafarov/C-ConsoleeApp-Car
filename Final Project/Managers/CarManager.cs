using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Managers
{
    internal class CarManager
    {
        Car[] data = new Car[0];
        public void Add(Car entity)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = entity;
        }
        public Car[] GetAll()
        {
            return data;
        }

        public void Remove(Car entity)
        {
            int index = Array.IndexOf(data, entity);
            if (index == -1)
            {
                return;
            }
            for (int i = index; i < data.Length - 1; i++)
            {
                data[i] = data[i + 1];
            }
            if (data.Length > 0)
                Array.Resize(ref data, data.Length - 1);

        }
       

      

        public  static void PrintFuelMenu()
        {
            Console.WriteLine(new string('-', Console.WindowWidth));
            Console.WriteLine("############ FuelTypes ############");
            foreach (var item in Enum.GetNames(typeof(Fueltype)))
            {
                Fueltype f = (Fueltype)Enum.Parse(typeof(Fueltype), item);
                Console.WriteLine($"{((byte)f).ToString().PadLeft(2)}. {item}");
            }
            Console.WriteLine(new string('-', Console.WindowWidth));
        }
        public void Edit()
        {
        l1:
            Console.ForegroundColor = ConsoleColor.Blue;
            int id = HelpManager.ReadInteger("Which Id do you want to Change: ");
            Console.ResetColor();
            bool exist = data.Any(item => item.Id == id);
            if (!exist)
            {
                HelpManager.PrintError("Include The Id Correctly: ");
                goto l1;
            }
            Car car = null;

            foreach (Car item in data)
            {
                if (item.Id == id)
                {
                    car = item;
                }
                Console.WriteLine(item);
            }
            l2:
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("                        For Changing Year Press -1-     For Price Press  -2-   For Color Press -3-   For Engine Press -4-   For FuelType Press -5-   For ModelId Press -6-             ");
            Console.ResetColor();

            int num = HelpManager.ReadInteger("Choisen Number: ");
            switch (num)
            {
                case 1:

                    int newYear = HelpManager.ReadInteger("Include the New Year: ");
                    car.Year = newYear;
                    break;
                case 2:

                    int newPrice = HelpManager.ReadInteger("Include the New Price: ");
                    car.Price = newPrice;
                    break;
                case 3:

                    string newColor = HelpManager.ReadString("Include the New Color: ");
                    car.Color = newColor;
                    break;
                case 4:

                    double newEngine = HelpManager.ReadDouble("Include the New Engine: ");
                    car.Engine = newEngine;
                    break;
                case 5:
                    PrintFuelMenu();
                    Fueltype newFuel = HelpManager.ReadFuelMenu("Include the New FuelType: ");
                    car.FuelType = newFuel;
                    break;
                case 6:

                    int newModelId = HelpManager.ReadInteger("Include the New  ModelId: ");
                    car.ModelId = newModelId;
                    break;
                default:
                    HelpManager.PrintError("Wron choice, Try again!!!");
                    goto l2;
            }
        }
    }
}
