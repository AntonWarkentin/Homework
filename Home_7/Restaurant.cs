using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_7
{
    internal class Restaurant
    {
        public Employee[] allEmployees;

        public List<ICookable> ableToCook;
        public List<ICleanable> ableToClean;
        public List<IManageable> ableToManage;
        public List<IConflictSolveable> ableToSolveConflict;

        public List<Happening> RestaurantsHappenings { get; }

        public Restaurant()
        {
            Cook RestaurantsCook = new Cook(Home_3.Program.GenerateName(4));
            Cleaner RestaurantsCleaner = new Cleaner(Home_3.Program.GenerateName(4));
            Manager RestaurantsManager = new Manager(Home_3.Program.GenerateName(4));
            allEmployees = new Employee[3] { RestaurantsCook, RestaurantsCleaner, RestaurantsManager };

            ableToCook = CheckWhosAbleToCook(allEmployees);
            ableToClean = CheckWhosAbleToClean(allEmployees);
            ableToManage = CheckWhosAbleToManage(allEmployees);
            ableToSolveConflict = CheckWhosAbleToSolveConflicts(allEmployees);

            RestaurantsHappenings = GenerateRandomHappenings();
        }

        private List<ICookable> CheckWhosAbleToCook(Employee[] employees)
        {
            List<ICookable> isCookable = new List<ICookable>();
            foreach (Employee employee in employees)
            {
                if (employee is ICookable)
                {
                    isCookable.Add((ICookable)employee);
                }
            }
            return isCookable;
        }

        private List<ICleanable> CheckWhosAbleToClean(Employee[] employees)
        {
            List<ICleanable> isCleanable = new List<ICleanable>();
            foreach (Employee employee in employees)
            {
                if (employee is ICleanable)
                {
                    isCleanable.Add((ICleanable)employee);
                }
            }
            return isCleanable;
        }

        private List<IManageable> CheckWhosAbleToManage(Employee[] employees)
        {
            List<IManageable> isManageable = new List<IManageable>();
            foreach (Employee employee in employees)
            {
                if (employee is IManageable)
                {
                    isManageable.Add((IManageable)employee);
                }
            }
            return isManageable;
        }

        private List<IConflictSolveable> CheckWhosAbleToSolveConflicts(Employee[] employees)
        {
            List<IConflictSolveable> isConflictSolveable = new List<IConflictSolveable>();
            foreach (Employee employee in employees)
            {
                if (employee is IConflictSolveable)
                {
                    isConflictSolveable.Add((IConflictSolveable)employee);
                }
            }
            return isConflictSolveable;
        }

        public List<Happening> GenerateRandomHappenings()
        {
            Random rand = new Random();
            List<Happening> randomHappenings = new List<Happening>(rand.Next(1,10));

            for (int i = 0; i < randomHappenings.Capacity; i++)
            {
                randomHappenings.Add((Happening)rand.Next(0,3));
            }

            return randomHappenings;
        }

        public void RestaurantsWork()
        {
            if (RestaurantsHappenings.Count == 0)
            {
                Console.WriteLine("All Happenings have been worked out!");
                return;
            }

            foreach (Happening happening in RestaurantsHappenings)
            {
                WorkOutHappening(happening);
            }

            RestaurantsHappenings.Clear();
        }

        void WorkOutHappening(Happening happening)
        {
            Random rand = new Random();
            int anyAbleEmployeeIndex;

            switch (happening)
            {
                case Happening.CustomersOrder:
                    anyAbleEmployeeIndex = rand.Next(0, ableToCook.Count);
                    ableToCook[anyAbleEmployeeIndex].CookFood();
                    break;
                case Happening.RestaurantIsDirty:
                    anyAbleEmployeeIndex = rand.Next(0, ableToClean.Count);
                    ableToClean[anyAbleEmployeeIndex].Clean();
                    break;
                case Happening.Conflict:
                    anyAbleEmployeeIndex = rand.Next(0, ableToSolveConflict.Count);
                    ableToSolveConflict[anyAbleEmployeeIndex].SolveConflict();
                    break;
                case Happening.ManagementIsNeeded:
                    anyAbleEmployeeIndex = rand.Next(0, ableToManage.Count);
                    ableToManage[anyAbleEmployeeIndex].Manage();
                    break;
            }
        }
    }
}
