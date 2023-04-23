using System.Net;

namespace Home_7
{
    internal class Program
    {

        /// <summary>
        /// Реализовать систему работы ресторана Макдональдс. В системе должны быть следующие участники
        /// Cleaner - уборщик, умеет убираться.
        /// Cook - повар, умеет готовить и убираться
        /// Менеджер - Умеет решать конфликты, готовить, управлять персоналом
        /// Создать метод, который будет имитировать работу ресторана c выводом информации на консоль.
        /// Ex(Manager is managing people     
        /// Cook is cooking
        /// Cleaner is cleaning
        /// Manager is solving conflicts
        /// Manager is cooking.
        /// Cook is cleaning.)
        /// Переопределить метод ToString() в каждом классе сотрудников ресторана.
        /// </summary>

        static void Main(string[] args)
        {
            Restaurant mcD = new Restaurant();
            
            foreach (var employee in mcD.allEmployees)
            {
                Console.WriteLine(employee.ToString());
            }

            Console.WriteLine();
            mcD.RestaurantsWork();

            Console.WriteLine();
            mcD.RestaurantsWork();

            Console.WriteLine();
            mcD.RestaurantsHappenings.Add(Happening.ManagementIsNeeded);
            mcD.RestaurantsWork();

            Console.WriteLine();
            mcD.RestaurantsHappenings.AddRange(mcD.GenerateRandomHappenings());
            mcD.RestaurantsWork();
        }
    }
}