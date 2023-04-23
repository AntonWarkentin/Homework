using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_7
{
    internal class Cook : Employee, ICookable, ICleanable
    {
        public override string Name { get; set; }

        public Cook(string name)
        {
            Name = name;
        }

        public void Clean()
        {
            Console.WriteLine("Cook is cleaning");
        }

        public void CookFood()
        {
            Console.WriteLine("Cook is cooking");
        }

        public override string ToString()
        {
            return $"This man is a cook. His name is {Name}";
        }
    }
}
