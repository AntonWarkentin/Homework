using Home_10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_9
{
    public static class LINQMethods
    {
        
        /// <summary>
        /// - Метод возвращает первое слово из последовательности слов, содержащее только одну букву.
        /// </summary>

        public static string FirstOneDigitWord(List<string> list)
        {
            return list.Where(x => x.Count() == 1).First();
        }

        /// <summary>
        /// - метод, возвращающий последнее слово, содержащее в себе подстроку «ее». Реализовать, используя только 1 метод LINQ.
        /// </summary>

        public static string LastWordWithEe(List<string> list)
        {
            return list.Last(x => x.Contains("ee"));
        }

        /// <summary>
        /// - Реализовать метод для возврата последнего слова, соответствующего условию: длина слова не меньше min и не больше max.Если нет слов, соответствующих условию, метод возвращает null.
        /// </summary>

        public static string LastWordWithLength(List<string> list, int minLen, int maxLen)
        {
            return list.LastOrDefault(x => x.Count() >= minLen && x.Count() <= maxLen);
        }


        /// <summary>
        /// - Напишите метод, который возвращает количество уникальных значений в массиве.
        /// </summary>

        public static int AmountOfUniqueStrings(List<string> list)
        {
            return list.Distinct().Count();
        }

        /// <summary>
        /// - Напишите метод, который принимает список и извлекает значения с 5  элемента (включительно) те значение которые содержат 3
        /// </summary>

        public static List<int> ElementsWith3 (List<int> list)
        {
            return list.Skip(4).Where(x => x.ToString().Contains("3")).ToList();
        }

        /// <summary>
        /// - Метод возвращает длину самого короткого слова
        /// </summary>

        public static int LengthOfTheShortestWord(List<string> list)
        {
            return list.Min(x => x.Length);
        }

        /// <summary>
        /// - Напишите метод, который преобразует словарь в список и меняет местами каждый ключ и значение
        /// </summary>

        public static List<KeyValuePair<string, int>> TurnDictToListAndReverse(Dictionary<int, string> dict)
        {
            return dict.ToDictionary(x => x.Value, x => x.Key).ToList();
        }


        /// <summary>
        /// - Напишите метод, который возвращает "<FirstName> <MiddleName> <LastName>", если отчество присутствует Или "<FirstName> <LastName>", если отчество отсутствует.
        /// </summary>

        public static List<string> WriteUsersName(List<User> users)
        {
            var fullNames = users.Where(x => x.MiddleName != null).Select(x => $"{x.FirstName} {x.MiddleName} {x.LastName}");
            var noMiddleNames = users.Where(x => x.MiddleName == null).Select(x => $"{x.FirstName} {x.LastName}");

            return fullNames.Concat(noMiddleNames).ToList();
        }


        ///  <summary>
        /// - Напишите метод, который возвращает предоставленный список пользователей, упорядоченный по LastName в порядке убывания.
        /// </summary>

        public static List<User> ReverseSortedByLastName(List<User> users)
        {
            return users.OrderBy(x => x.LastName).Reverse().ToList();
        }
    }
}
