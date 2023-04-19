using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_7
{
    public abstract class Employee
    {
        public string Name { get; set; }

        public abstract override string ToString();

        public Employee(string name)
        {
            Name = name;
        }
    }
}
