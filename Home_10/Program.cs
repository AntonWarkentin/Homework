using Home_9;
using System.Threading;

namespace Home_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DelegateAndEventTask1();
            DelegateAndEventTask2_Event();
            DelegateAndEventTask2_Observer();
            LINQTask1();
            LINQTask2();
        }

        /// <summary>
        /// Delegate and Event
        /// 1. Cоздать класс мониторинга средней цен на жилье, цена будет генерироваться с помощью класса рандом и выдавать случайное значение в определенном диапазоне.
        /// Для того, чтобы вывод цены был удобен пользователю, в классе мониторинга создать поле делегат, обьект которого будет создаваться в классе мониторинга.
        /// Пользователь указывает метод для отображения цены в удобном ему формате путем передачи метода в конструктор класса мониторинга.
        /// пример создания объекта монитора.
        /// 
        /// PriceMonitor monitor = new PriceMonitor(ShowPrice);
        /// public static void ShowPrice(int price)
        /// {
        ///    //your code
        /// }
        /// </summary>

        private static void DelegateAndEventTask1()
        {
            var monitor = new AvgHousingPriceMonitor(ShowPriceTemplate.ShowPriceFirstVar);
            monitor.ShowPrice(monitor.AvgHousingPrice);

            monitor.ShowPrice = ShowPriceTemplate.ShowPriceSecondVar;
            monitor.ShowPrice(monitor.AvgHousingPrice);

            monitor.GenerateRandomAvgPrice();
            monitor.ShowPrice(monitor.AvgHousingPrice);
        }

        /// <summary>
        /// 2. Реализовать паттерн наблюдатель в случае если цена на жилье опустилась ниже определенного значения, и сообщить всем кто на это событие подписался.
        /// * реализовать как через событие, так и через паттерн наблюдатель без события
        /// https://refactoring.guru/ru/design-patterns/observer
        /// </summary>

        private static void DelegateAndEventTask2_Event()
        {
            var monitor = new AvgHousingPriceMonitor(ShowPriceTemplate.ShowPriceFirstVar);
            var user = new User("Michal", "Terentjev", "Palych");
            monitor.AffordablePriceEvent += user.UserNotifiedWhenPriceOK;
            monitor.AvgHousingPrice = 999;
        }

        private static void DelegateAndEventTask2_Observer()
        {
            var monitor = new AvgHousingPriceMonitor(ShowPriceTemplate.ShowPriceFirstVar);
            var user1 = new User("Michal", "Terentjev", "Palych", monitor);
            var user2 = new User("Aleksej", "Bagirov", "Sergeevich", monitor);

            monitor.AvgHousingPrice = 999;

            Console.WriteLine();
            user1.CloseSubscription();
            monitor.AvgHousingPrice = 800;
        }

        /// <summary>
        /// Linq
        /// Реализовать следующие методы:
        /// - Метод возвращает первое слово из последовательности слов, содержащее только одну букву.
        /// - метод, возвращающий последнее слово, содержащее в себе подстроку «ее». Реализовать, используя только 1 метод LINQ.
        /// - Реализовать метод для возврата последнего слова, соответствующего условию: длина слова не меньше min и не больше max.Если нет слов, соответствующих условию, метод возвращает null.
        /// - Напишите метод, который возвращает количество уникальных значений в массиве.
        /// - Напишите метод, который принимает список и извлекает значения с 5  элемента (включительно) те значение которые содержат 3
        /// - Метод возвращает длину самого короткого слова
        /// - Напишите метод, который преобразует словарь в список и меняет местами каждый ключ и значение
        /// </summary>

        private static void LINQTask1()
        {
            var listOfStrings = new List<string>() { "Alex", "Aeee", "oi", "oi", "AA", "Reel", "kek", "Aight", "B", "Expectancy", "B" };
            var listOfInts = new List<int>() { 1, 5, 55, 3, 3333, 8765, 545, 33, 54, 63, 31 };
            var dict = new Dictionary<int, string>() { { 1, "Tolik" } , { 2, "Stepan"  } , { 55, "Alex" } };

            Console.WriteLine(LINQMethods.FirstOneDigitWord(listOfStrings));

            Console.WriteLine(LINQMethods.LastWordWithEe(listOfStrings));

            Console.WriteLine(LINQMethods.LastWordWithLength(listOfStrings, 2, 4));
            Console.WriteLine(LINQMethods.LastWordWithLength(listOfStrings, 20, 40));

            Console.WriteLine(LINQMethods.AmountOfUniqueStrings(listOfStrings));

            Console.WriteLine(string.Join(" ", LINQMethods.ElementsWith3(listOfInts)));

            Console.WriteLine(LINQMethods.LengthOfTheShortestWord(listOfStrings));

            Console.WriteLine(string.Join(" ", LINQMethods.TurnDictToListAndReverse(dict)));
        }

        /// <summary>
        /// дан класс
        /// public class User
        /// {
        ///     public string FirstName { get; set; }
        ///     public string MiddleName { get; set; }
        ///     ublic string LastName { get; set; }
        ///     public User(string firstName, string middleName, string lastName)
        ///     {
        ///         FirstName = firstName;
        ///         MiddleName = middleName;
        ///         LastName = lastName;
        ///     }
        /// }
        /// 
        /// - Напишите метод, который возвращает "<FirstName> <MiddleName> <LastName>", если отчество присутствует Или "<FirstName> <LastName>", если отчество отсутствует.
        /// - Напишите метод, который возвращает предоставленный список пользователей, упорядоченный по LastName в порядке убывания.
        /// </summary>

        private static void LINQTask2()
        {
            User user1 = new User(firstName: "Alex", lastName: "Nest");
            User user2 = new User("Michal", "Terentjev", "Palych");
            User user3 = new User("Aleksej", "Bagirov", "Sergeevich");
            List<User> users = new List<User>() { user1, user2, user3 };

            Console.WriteLine(string.Join("\n", LINQMethods.WriteUsersName(users)));

            Console.WriteLine();
            var reverseSorted = LINQMethods.ReverseSortedByLastName(users);
            foreach (var user in reverseSorted)
            {
                Console.WriteLine($"{user.LastName} {user.FirstName}");
            }
        }
    }
}