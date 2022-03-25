using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    internal class Marka
    {
        public int Id { get; private set; }

        public string Name { get; set; }
        static int counter = 0;

        public Marka()
        {
            this.Id = ++counter;
        }

        public override string ToString()
        {
            return $"Id: {Id}  Name: {Name}";
        }
    }
}
