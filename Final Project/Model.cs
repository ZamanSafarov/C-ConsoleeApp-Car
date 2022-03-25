using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    internal class Model
    {
        static int counter = 0;
        public int Id { get; private set; }
        public string Name { get; set; }
        public int MarkaId { get; set; }

        public Model()
        {
            this.Id = ++counter;
        }

        public override string ToString()
        {
            return $"Id: {Id}  Name: {Name}  MarkaId: {MarkaId}";
        }
    }
}
