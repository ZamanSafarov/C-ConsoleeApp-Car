using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Managers
{
    internal class ModelManager
    {
        Model[] data = new Model[0];

        public void Add(Model entity)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = entity;
        }
        public Model[] GetAll()
        {
            return data;
        }

        public void Remove(Model entity)
        {
            int index = Array.IndexOf(data, entity);
            if (index == -1)
            {
                return;
            }
            for (int i = index; i < data.Length-1; i++)
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
            int id = HelpManager.ReadInteger("Which Id do you want to Change: ");
            Console.ResetColor();
            bool exist = data.Any(item => item.Id == id);
            if (!exist)
            {
                HelpManager.PrintError("Include The Id Correctly: ");
                goto l1;
            }
            Model model = null;

            foreach (Model item in data)
            {
                if (item.Id == id)
                {
                    model = item;
                }
                Console.WriteLine(item);
            }

            l2:
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("                            For Changing Name Press -1-     For MarkaId Press  -2-                       ");
            Console.ResetColor();

            int num = HelpManager.ReadInteger("Choisen Number: ");
            switch (num)
            {
                case 1:

                    string newName = HelpManager.ReadString("Include the New Name: ");
                    model.Name = newName;



                    break;
                 case 2:
                    int NewMarkaId = HelpManager.ReadInteger("Include the New MarkaId: ");
                   
                    model.MarkaId = NewMarkaId;
                    break;
                default:
                    HelpManager.PrintError("Wrong chice, Try again!!");
                    goto l2;
                    
            }

        }
    }
}
