using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_9
{
    internal class Person
    {
        private const int minimumWage = 100;

        private const int minimumAge = 18;

        private int salary;

        private int age;

        public string Name { get; set; }
        
        public int Age 
        {
            get => age;
            set
            {
                if (value < minimumAge)
                {
                    throw new AgeException($"You're trying to set person's age less than {minimumAge}!", value);
                }
                else age = value;
            }
        }

        public int Salary 
        {
            get => salary; 
            set
            {
                if (value < minimumWage)
                {
                    throw new SalaryException($"You're trying to set salary less than {minimumWage}! That's less than minimum wage! Have a heart!", value);
                }
                else salary = value;
            }
        }
        
        public Person(string name, int age, int salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"Person with name: {Name}, Age: {Age} and Salary: {Salary}";
        }
    }
}
