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

        public List<Happening> RestaurantsHappenings { get; }

        public Restaurant()
        {
            Cook RestaurantsCook = new Cook(Home_3.Program.GenerateName(4));
            Cleaner RestaurantsCleaner = new Cleaner(Home_3.Program.GenerateName(4));
            Manager RestaurantsManager = new Manager(Home_3.Program.GenerateName(4));
            allEmployees = new Employee[3] { RestaurantsCook, RestaurantsCleaner, RestaurantsManager };
            RestaurantsHappenings = GenerateRandomHappenings();
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
            switch (happening)
            {
                case Happening.CustomersOrder:
                    ICookable employeeAbleToCook = (ICookable)SelectEmployeeAbleForWork(happening);
                    employeeAbleToCook.CookFood();
                    break;
                case Happening.RestaurantIsDirty:
                    ICleanable employeeAbleToClean = (ICleanable)SelectEmployeeAbleForWork(happening);
                    employeeAbleToClean.Clean();
                    break;
                case Happening.Conflict:
                    IConflictSolveable employeeAbleToSolveConflict = (IConflictSolveable)SelectEmployeeAbleForWork(happening);
                    employeeAbleToSolveConflict.SolveConflict();
                    break;
                case Happening.ManagementIsNeeded:
                    IManageable employeeAbleToManage = (IManageable)SelectEmployeeAbleForWork(happening);
                    employeeAbleToManage.Manage();
                    break;
            }
        }

        public Employee SelectEmployeeAbleForWork(Happening happening)
        {
            Random rand = new Random();
            int anyAbleEmployeeIndex = rand.Next(0, allEmployees.Length);

            while (!allEmployees[anyAbleEmployeeIndex].CheckIfAble(happening))
            {
                anyAbleEmployeeIndex = rand.Next(0, allEmployees.Length);
            }

            return allEmployees[anyAbleEmployeeIndex];
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

    }
}
