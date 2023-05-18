namespace Home_9
{
    internal class Program
    {

        /// <summary>
        /// Создайте коллекцию состояющую из объектов Person (поля Name, Age, Salary)
        /// Выведите всех Person, чье имя начинается на A
        /// Выведите всех Person, у кого зп больше 1000 и возраст меньше 30. 
        /// Выведите первого человека старше 50 
        /// Добавьте свои классы исключений - SalaryException, AgeException и добавьте в поля Age и Salary проверку,
        /// если Age меньше 18 - сгенерируйте исключение, если salary меньше 100 - сгенерируйте исключение
        /// Обработайте исключения
        /// </summary>

        static void Main(string[] args)
        {
            Predicate<Person> clause;

            PersonList personsCollection = new PersonList();
            Console.WriteLine("Initial list:");
            Console.WriteLine(personsCollection.ToString());


            clause = x => x.Name.StartsWith('A');
            PersonList personsCollectionStartingWithA = new PersonList(personsCollection.Where(clause));
            Console.WriteLine("\nList of persons whose names are starting with \"A\":");
            Console.WriteLine(personsCollectionStartingWithA.ToString());

            clause = x => (x.Salary > 1000) && (x.Age < 30);
            PersonList personsCollectionSalaryAndAgeFilter = new PersonList(personsCollection.Where(clause));
            Console.WriteLine("\nList of persons whose Salary is more than 1000 and Age is below 30:");
            Console.WriteLine(personsCollectionSalaryAndAgeFilter.ToString());

            clause = x => x.Age > 50;
            Person firstPersonOlderThan = personsCollection.Where(clause).First();
            Console.WriteLine("\nFirst person in list older than 50:");
            Console.WriteLine(firstPersonOlderThan.ToString());

            try
            {
                personsCollection.Persons = new List<Person> { new Person("Person with salary of 33", 20, 33) };
            }
            catch (SalaryException sEx)
            {
                Console.WriteLine($"Exception message: {sEx.Message}\n{sEx.StackTrace}");
            }

            try
            {
                personsCollection.Persons = new List<Person> { new Person("Person with age of 12", 12, 120) };
            }
            catch (AgeException aEx)
            {
                Console.WriteLine($"Exception message: {aEx.Message}\n{aEx.StackTrace}");
            }
        }
    }
}