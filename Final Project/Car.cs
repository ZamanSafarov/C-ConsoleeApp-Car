using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    internal class Car
    {
        public int Id { get; private set; }
        public int ModelId { get;  set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public  double Engine { get; set; }
        public  Fueltype FuelType { get; set; }

        static int counter = 0;

        public Car()
        {
            this.Id = ++counter;
        }
        public override string ToString()
        {
            return $"Id: {Id}  Year: {Year} Price: {Price}₼  Color: {Color} Engine: {Engine}l ModelId: {ModelId} FuelType: {FuelType}";
        }
    }
}
