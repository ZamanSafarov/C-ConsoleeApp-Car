using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Managers
{
    internal class MarkaManager
    {
        Marka[] data = new Marka[0];
        public void Add(Marka entity)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = entity;
        }
        public Marka[] GetAll()
        {
            return data;
        }
        public void Remove(Marka entity)
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

        public void Edit()
        {
        l1:
            Console.ForegroundColor = ConsoleColor.Blue;
            int id = HelpManager.ReadInteger("Which Id you want to Change: ");
            Console.ResetColor();
            bool exist = data.Any(item => item.Id == id);
            if (!exist)
            {
                HelpManager.PrintError("Iclude the Id Correctly: ");
                goto l1;
            }
            Marka marka = null;

            foreach (Marka item in data)
            {
                if (item.Id == id)
                {
                    marka = item;
                }
                Console.WriteLine(item);
            }
            l2:
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("                    For Changing Name Press -1-                           ");
            Console.ResetColor();

            int num = HelpManager.ReadInteger("Choisen Number: ");
            switch (num)
            {
                case 1:

                    string newName = HelpManager.ReadString("Include the New Name: ");
                    marka.Name = newName;



                    break;
                default:
                    HelpManager.PrintError("Wrong choice, Try again!!!");
                    goto l2;
            }





        }
    }
}
