using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_8
{
    internal class Person
    {        
        public string? Name { get; set; }

        public int MaxNumberOfKCalories { get; set; }

        public Ration? Ration { get; set; }

        public Person(string? name, int maxNumberOfKCalories, Ration? ration)
        {
            Name = name;
            MaxNumberOfKCalories = maxNumberOfKCalories;
            Ration = ration;
        }

        public void CheckPersonsRations()
        {
            foreach (KeyValuePair<DayOfWeek, List<Product>> dictPair in Ration.RationDict)
            {
                int allCalories = Ration.CountAllCaloriesInDay(dictPair.Key);

                while (allCalories > MaxNumberOfKCalories)
                {
                    Ration.DeleteRandomProductFromRation(dictPair.Key);
                    allCalories = Ration.CountAllCaloriesInDay(dictPair.Key);
                }
            }
        }
    }
}
