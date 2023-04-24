using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_8
{
    internal class Ration
    {
        private const int amountOfProducts = 10;
        
        public Dictionary<DayOfWeek, List<Product>> RationDict;

        public Ration()
        {
            RationDict = new Dictionary<DayOfWeek, List<Product>>();

            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                List<Product> rationList = new List<Product>();

                for (int i = 0; i < amountOfProducts; i++)
                {
                    rationList.Add(new Product());
                }

                RationDict.Add(day, rationList);
            }
        }

        public int CountAllCaloriesInDay(DayOfWeek day)
        {
            int kCaloriesCount = 0;

            foreach (Product product in RationDict[day])
            {
                kCaloriesCount += product.NumberOfKCalories;
            }

            return kCaloriesCount;
        }

        public void DeleteRandomProductFromRation(DayOfWeek day)
        {
            Random random = new Random();
            int randomProductIndex = random.Next(0, RationDict.Count - 1);

            Console.WriteLine($"Deleting product {RationDict[day][randomProductIndex].ProductName} with {RationDict[day][randomProductIndex].NumberOfKCalories} kcalories from {day} ration");
            RationDict[day].RemoveAt(randomProductIndex);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            foreach(KeyValuePair<DayOfWeek, List<Product>> pair in RationDict)
            {
                sb.Append($"\nPerson's ration for {pair.Key} ({CountAllCaloriesInDay(pair.Key)} kcal):\n");

                foreach(Product product in pair.Value)
                {
                    sb.Append($"{product.ProductName} - {product.NumberOfKCalories} kcal\n");
                }
            }

            return sb.ToString();
        }
    }
}
