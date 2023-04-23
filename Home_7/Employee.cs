using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_7
{
    public abstract class Employee
    {
        public abstract string Name { get; set; }

        public bool CheckIfAble(Happening happening)
        {
            switch (happening)
            {
                case Happening.CustomersOrder:
                    return (this is ICookable);
                case Happening.RestaurantIsDirty:
                    return (this is ICleanable);
                case Happening.Conflict:
                    return (this is IConflictSolveable);
                case Happening.ManagementIsNeeded:
                    return (this is IManageable);
            }
            return false;
        }
    }
}
