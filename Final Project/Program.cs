using Final_Project.Infrastructure;
using Final_Project.Managers;
using System;
using System.Linq;
using System.Text;

namespace Final_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Yellow;
            string s = "Welcome to Final Project";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
            Console.ResetColor();

            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.Title = "C# Final Project";


            CarManager carMgr = new CarManager();
            MarkaManager markaMgr = new MarkaManager();
            ModelManager modelMgr = new ModelManager();



            readmenu:
            PrintMenu();

            Menu menu = HelpManager.ReadMenu("Choose from Menu: ");

            switch (menu)
            {
                case Menu.MarkaAdd:
                    Console.Clear();
                    Marka m = new Marka();
                    m.Name = HelpManager.ReadString("Write The Name of Marka: ");

                    markaMgr.Add(m);
                    Console.Clear();

                    goto readmenu;
                case Menu.MarkaEdit:
                    Console.Clear();

                    ShowAllMarka(markaMgr);
                    Console.WriteLine("-------------------------------");
                    markaMgr.Edit();

                    Console.Clear();

                    goto readmenu;
                    
                case Menu.MarkaRemove:
                    Console.Clear();
                    
                    ShowAllMarka(markaMgr);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    int IdForRemoveMarka = HelpManager.ReadInteger("Write The MarkaId that you want to Remove: ");
                    Console.ResetColor();
                    Marka mV1 = markaMgr.GetAll().FirstOrDefault(item => item.Id == IdForRemoveMarka);


                    markaMgr.Remove(mV1);
                    Console.Clear();

                    goto readmenu;

                case Menu.MarkaSingle:
                    Console.Clear();
                    ShowAllMarka(markaMgr);

                    int idForMarkaSingle = HelpManager.ReadInteger("Choose the MarkaId for wider Info: ");

                    Marka mSingle = markaMgr.GetAll().FirstOrDefault(item => item.Id == idForMarkaSingle);

                    Console.WriteLine($"Id: {mSingle.Id}\n " +
                       $"Name: {mSingle.Name}");

                    goto readmenu;
                case Menu.MarkasAll:

                    Console.Clear();
                    ShowAllMarka(markaMgr);
                    goto readmenu;

                case Menu.ModelAdd:
                    Console.Clear();
                    Model mdl = new Model();

                    mdl.Name = HelpManager.ReadString("Write the Name of Model: ");

                    l2:
                    Console.WriteLine("---------------------");

                    ShowAllMarka(markaMgr);

                    Console.WriteLine("-----------------");

                    mdl.MarkaId = HelpManager.ReadInteger("Write the MarkaId of Model: ");
                    var MarkaIdForModel = markaMgr.GetAll().FirstOrDefault(x => x.Id == mdl.MarkaId);
                    if (MarkaIdForModel== null)
                    {
                        HelpManager.PrintError("There is not have Id with this MarkaId, Try again!!!!");
                        goto l2;

                    }

                    modelMgr.Add(mdl);
                    Console.Clear();

                    goto readmenu;
                case Menu.ModelEdit:
                    Console.Clear();

                    ShowAllModels(modelMgr);
                    Console.WriteLine("-------------------------------");
                    modelMgr.Edit();

                    Console.Clear();

                    goto readmenu;

                case Menu.ModelRemove:
                    Console.Clear();
                   
                    ShowAllModels(modelMgr);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    int idForModelRemove = HelpManager.ReadInteger("Write The Id of Model that you want to Remove: ");
                    Console.ResetColor();
                    Model mV2 = modelMgr.GetAll().FirstOrDefault(item => item.Id == idForModelRemove);
                    
                    modelMgr.Remove(mV2);
                    Console.Clear();

                    goto readmenu;
                case Menu.ModelSingle:
                    Console.Clear();
                    ShowAllModels(modelMgr);

                    int idForModelSingle = HelpManager.ReadInteger("Choose the ModelId for wider Info: ");

                    Model mSingleModel = modelMgr.GetAll().FirstOrDefault(item => item.Id == idForModelSingle);

                    Console.WriteLine($"Id: {mSingleModel.Id}\n " +
                       $"Name: {mSingleModel.Name}\n" +
                       $"MarkaId: {mSingleModel.MarkaId}");

                    goto readmenu;
                case Menu.ModelsAll:

                    Console.Clear();
                    ShowAllModels(modelMgr);
                    goto readmenu;

                case Menu.CarAdd:
                    Console.Clear();
                    Car c = new Car();
                    
                    c.Year = HelpManager.ReadInteger("Write the Year of Car: ");
                    c.Price = HelpManager.ReadDouble("Write the Price of Car: ");
                    c.Color = HelpManager.ReadString(" Write the Color of Car: ");
                    c.Engine = HelpManager.ReadDouble("Write the Engine of Car: ");
                    l4:
                    PrintFuelMenu();
                    Fueltype fueltype = HelpManager.ReadFuelMenu("Choose from Menu: ");

                    switch (fueltype)
                    {
                        case Fueltype.Petrol:
                            c.FuelType = Fueltype.Petrol;
                            break;
                        case Fueltype.Diesel:
                            c.FuelType = Fueltype.Diesel;
                            break;
                        case Fueltype.Hybrid:
                            c.FuelType = Fueltype.Hybrid;
                            break;
                        default:
                            HelpManager.PrintError("Wrong choice, Try again!!!");
                            goto l4;
                    }
                l3:
                    Console.WriteLine("--------------------------");

                    ShowAllModels(modelMgr);

                    Console.WriteLine("--------------------------");
                    c.ModelId = HelpManager.ReadInteger("Write the ModelId of Car: ");

                    var ModelIdForCar = modelMgr.GetAll().FirstOrDefault(item => item.Id == c.ModelId);
                    if (ModelIdForCar == null)
                    {
                        HelpManager.PrintError("Wrong ModelId, Try again!!");
                        goto l3;

                    }

                    carMgr.Add(c);
                    Console.Clear();

                    goto readmenu;
                case Menu.CarEdit:
                    Console.Clear();

                    ShowAllCars(carMgr);
                    Console.WriteLine("-------------------------------");
                    carMgr.Edit();

                    Console.Clear();

                    goto readmenu;
                    
                case Menu.CarRemove:
                    Console.Clear();
                    ShowAllCars(carMgr);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    int IdForRemoveCar = HelpManager.ReadInteger("Write The Id of Car that you want to Remove: ");
                    Console.ResetColor();
                    Car cV1 = carMgr.GetAll().FirstOrDefault(item => item.Id == IdForRemoveCar);

                    carMgr.Remove(cV1);
                    goto readmenu;
                case Menu.CarSingle:
                    Console.Clear();
                    ShowAllCars(carMgr);

                    int idForCarSingle = HelpManager.ReadInteger("Choose the CarId for wider Info: ");

                    Car mSingleCar = carMgr.GetAll().FirstOrDefault(item => item.Id == idForCarSingle);

                    Console.WriteLine($"Id: {mSingleCar.Id}\n " +
                       $"Year: {mSingleCar.Year}\n" +
                       $"Price: {mSingleCar.Price}\n" +
                       $"Color: {mSingleCar.Color}\n" +
                       $"Engine: {mSingleCar.Engine}");

                    goto readmenu;
                case Menu.CarAll:

                    Console.Clear();
                    ShowAllCars(carMgr);
                    goto readmenu;

                case Menu.All:

                    Console.Clear();
                    ShowAllMarka(markaMgr);
                    ShowAllModels(modelMgr);
                    ShowAllCars(carMgr);

                    goto readmenu;
                    
                case Menu.Exit:

                    goto lEnd; 
                default:
                    Console.Clear();
                    HelpManager.PrintError("Wrong Choice, Try again!!");
                    Console.Clear();
                    goto readmenu;
                    
            }












        lEnd:
            Console.WriteLine("End......");
            Console.WriteLine("Click the Random BUTTON for Quit.");
            Console.ReadKey();






            static void PrintMenu()
            {
                Console.WriteLine(new string('-', Console.WindowWidth));
                foreach (var item in Enum.GetNames(typeof(Menu)))
                {
                    Menu m = (Menu)Enum.Parse(typeof(Menu), item);
                    Console.WriteLine($"{((byte)m).ToString().PadLeft(2)}. {item}");
                }
                Console.WriteLine(new string('-', Console.WindowWidth));
            }
             static void PrintFuelMenu()
            { 
                Console.WriteLine(new string('-', Console.WindowWidth));
                Console.WriteLine("############ FuelTypes  ############");
                foreach (var item in Enum.GetNames(typeof(Fueltype)))
                {
                    Fueltype f = (Fueltype)Enum.Parse(typeof(Fueltype), item);
                    Console.WriteLine($"{((byte)f).ToString().PadLeft(2)}. {item}");
                }
                Console.WriteLine(new string('-', Console.WindowWidth));
            }

            static void ShowAllModels(ModelManager modelMgr)
            {
                Console.WriteLine("##################Models#################");
                foreach (var item in modelMgr.GetAll())
                {
                    Console.WriteLine(item);
                }
            }
            static void ShowAllCars(CarManager carMgr)
            {
                Console.WriteLine("##################Cars#################");
                foreach (var item in carMgr.GetAll())
                {
                    Console.WriteLine(item);
                }
            }
            static void ShowAllMarka(MarkaManager markaMgr)
            {
                Console.WriteLine("##################Marka#################");
                foreach (var item in markaMgr.GetAll())
                {
                    Console.WriteLine(item);
                }
            }


        }
    }
 }
