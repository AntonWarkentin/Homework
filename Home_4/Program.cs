using System;
using System.Data.SqlTypes;
using System.Linq.Expressions;
using System.Text;
using System.Xml.Linq;

namespace Home_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();
        }

        /// <summary>
        /// 1. Задать строку содержащую внутри цифры и несколько повторений слова test, Заменить в строке все вхождения 'test' на 'testing'.
        /// </summary>

        static void Task1()
        {
            string initialString = "12test7594test89595test7373267";
            Console.WriteLine(initialString);
            string editedString = initialString.Replace("test", "testing");
            Console.WriteLine(editedString);
        }

        /// <summary>
        /// 2. Создайте переменные, которые будут хранить следующие слова: (Welcome, to, the, TMS, lessons)выполните конкатенацию слов и выведите на экран следующую фразу:
        /// Каждое слово должно быть записано отдельно и взято в кавычки, например "Welcome". Не забывайте о пробелах после каждого слова
        /// </summary>

        static void Task2()
        {
            string stringWelcome = "Welcome";
            string stringTo = "to";
            string stringThe = "the";
            string stringTMS = "TMS";
            string sytringLessons = "lessons";

            string[] stringsAllTogether = { stringWelcome, stringTo, stringThe, stringTMS, sytringLessons };

            for (int i = 0; i < stringsAllTogether.Length; i++)
            {
                stringsAllTogether[i] = string.Format("\"{0}\"", stringsAllTogether[i]);
            }

            Console.WriteLine(string.Join(" ", stringsAllTogether));
        }

        /// <summary>
        /// 3. Дана строка: teamwithsomeofexcersicesabcwanttomakeitbetter.
        /// Необходимо найти в данной строке "abc", записав всё что до этих символов в переменную firstPart, а также всё, что после них во вторую secondPart.
        /// Результат вывести в консоль.
        /// </summary>

        static void Task3()
        {
            string insertedString = "teamwithsomeofexcersicesabcwanttomakeitbetter";
            string splitter = "abc";

            int indexOfabc = insertedString.IndexOf(splitter);
            string firstPart = insertedString.Substring(0, indexOfabc);
            string secondPart = insertedString.Substring(indexOfabc + splitter.Length);

            Console.WriteLine($"First part: {firstPart}\nSecond part: {secondPart}");
        }

        /// <summary>
        /// 4. Дана строка: Good day 
        /// Необходимо с помощью метода substring удалить слово "Good". После чего необходимо используя команду insert создать строку со значением: The best day!!!!!!!!!.
        /// Заменить последний "!" на "?" и вывести результат на консоль.
        /// </summary>

        static void Task4()
        {
            string insertedString = "Good day";
            string insertIntoString = "The best!!!!!!!!!";
            string goodString = "Good";

            int indexOfSubstring = insertedString.IndexOf(goodString) + goodString.Length;
            int indexOfExclamationMark = insertIntoString.IndexOf("!");

            string stringWithoutQuestionmark = insertIntoString.Insert(indexOfExclamationMark, insertedString.Substring(indexOfSubstring));

            string resultString = stringWithoutQuestionmark.Substring(0, stringWithoutQuestionmark.LastIndexOf("!")) + "?";
            Console.WriteLine(resultString);
        }

        /// <summary>
        /// 5. Введите с консоли строку, которая будет содержать буквы и цифры. Удалите из исходной строки все цифры и выведите их на экран.
        /// (Использовать метод Char.IsDigit(), его не разбирали на уроке, посмотрите, пожалуйста, документацию этого метода самостоятельно)
        /// </summary>

        static void Task5()
        {
            Console.WriteLine("Enter a line containing both letters and digits");
            string insertedString = Console.ReadLine();
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char element in insertedString.ToCharArray())
            {
                if ( ! char.IsDigit(element) )
                {
                    stringBuilder.Append(element);
                }
            }

            Console.WriteLine(stringBuilder.ToString());
        }

        /// <summary>
        /// 6. Задайте 2 предложения из консоли. Для каждого слова первого предложения определите количество его вхождений во второе предложение.
        /// </summary>

        static void Task6()
        {
            Console.WriteLine("Enter the first sentence");
            string? firstSentence = Console.ReadLine();

            Console.WriteLine("Enter the second sentence");
            string? secondSentence = Console.ReadLine();

            foreach (string word in firstSentence.Split(" "))
            {
                int numberOfOccurances = 0;
                int index = secondSentence.IndexOf(word);

                while (index >= 0)
                {
                    numberOfOccurances++;
                    index = secondSentence.IndexOf(word, index + word.Length);
                }

                Console.WriteLine($"Word {word} have been in the second sentence for {numberOfOccurances} times");
            }
            Console.WriteLine();
        }
    }
}