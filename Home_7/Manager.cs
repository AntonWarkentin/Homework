using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_7
{
    internal class Manager : Employee, ICookable, IConflictSolveable, IManageable
    {
        public Manager(string name) : base(name)
        {
        }

        public void CookFood()
        {
            Console.WriteLine("Manager is cooking");
        }

        public void Manage()
        {
            Console.WriteLine("Manager is managing people");
        }

        public void SolveConflict()
        {
            Console.WriteLine("Manager is solving conflict");
        }

        public override string ToString()
        {
            return $"This man is a manager. His name is {Name}";
        }
    }
}
