using System.Data.Common;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task0();
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();
            Task7();
            Task8();
            Task9();
        }

        static void Task0()
        {
            Console.WriteLine("Enter any int number from 1 to 20");
            var numberToSearch = int.Parse(Console.ReadLine());

            int[] intArray = CreateArrayWithRandomValues(10, 20);

            for (int i = 0; i < intArray.Length; i++)
            {
                if (intArray[i] == numberToSearch)
                {
                    Console.Write($"The number {numberToSearch} is in the array ");
                    break;
                }
                else if (i == intArray.Length - 1)
                {
                    Console.Write($"The number {numberToSearch} is NOT in the array ");
                }
            }
            Console.Write(string.Join(" ", intArray));
        }

        static void Task1()
        {
            int[] initialArray = CreateArrayWithRandomValues(10, 50);

            Console.WriteLine("\nEnter which number should i delete");
            var numberToDelete = int.Parse(Console.ReadLine());

            int occurenciesOfNumberToDelete = initialArray.Where(x => x == numberToDelete).Count();

            if (occurenciesOfNumberToDelete == 0)
            {
                Console.WriteLine("No such number in the array!");
                return;
            }

            int[] finalArray = initialArray.Where(x => x != numberToDelete).ToArray();

            Console.WriteLine($"Final array:");
            Console.Write(string.Join(" ", finalArray));
        }

        static void Task2()
        {
            Console.WriteLine("Enter length of array");
            var lengthOfArray = int.Parse(Console.ReadLine());

            int[] array = CreateArrayWithRandomValues(lengthOfArray, 100);

            int maxValue = array[0];
            int minValue = array[0];
            double sum = 0.0;

            foreach (int i in array)
            {
                if (i > maxValue) maxValue = i;
                if (i < minValue) minValue = i;
                sum += i;
            }

            Console.Write($"\nMax number is {maxValue}");
            Console.Write($"\nMin number is {minValue}");
            Console.Write($"\nAverage is {sum / array.Length}");
        }

        static void Task3()
        {
            int[] array1 = CreateArrayWithRandomValues(5, 50);
            int[] array2 = CreateArrayWithRandomValues(5, 50);

            var averageOfArray1 = (double)array1.Sum() / array1.Length;
            var averageOfArray2 = (double)array2.Sum() / array2.Length;

            if (averageOfArray1 > averageOfArray2)
                Console.WriteLine($"Average of the First array ({averageOfArray1}) is bigger than average of the Second array ({averageOfArray2})!");
            else if (averageOfArray1 < averageOfArray2) 
                Console.WriteLine($"Average of the Second array ({averageOfArray2}) is bigger than average of the First array ({averageOfArray1})!");
            else
                Console.WriteLine($"Averages of the arrays are equal ({averageOfArray1} = {averageOfArray2})!");
        }

        static void Task4()
        {
            int[] randomArray = CreateArrayWithRandomValues(10, 50);
            
            for  (int i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = (i % 2 != 0) ? 0 : randomArray[i];
            }

            Console.WriteLine($"Final array:\n{string.Join(" ", randomArray)}");
        }

        static void Task5()
        {
            string[] arrayOfNames = new string [10];

            for (int i = 0; i < arrayOfNames.Length; i++)
            {
                arrayOfNames[i] = GenerateName(5);
            }

            Console.WriteLine($"Generated array:\n{string.Join(" ", arrayOfNames)}");

            Array.Sort(arrayOfNames);
            Console.WriteLine($"Sorted array:\n{string.Join(" ", arrayOfNames)}");
        }

        static void Task6()
        {
            int[] arrayToBeBubbleSorted = CreateArrayWithRandomValues(10, 50);
            Console.WriteLine("Bubble sorting starts:");

            for (int i = 0; i < arrayToBeBubbleSorted.Length - 1; i++)
            {
                var biggerValue = Math.Max(arrayToBeBubbleSorted[i], arrayToBeBubbleSorted[i + 1]);
                var lesserValue = Math.Min(arrayToBeBubbleSorted[i], arrayToBeBubbleSorted[i + 1]);

                arrayToBeBubbleSorted[i] = lesserValue;
                arrayToBeBubbleSorted[i + 1] = biggerValue;

                Console.WriteLine(string.Join(" ", arrayToBeBubbleSorted));
            }
        }

        static void Task7()
        {
            int[,] twoDimensionalArray = CreateArrayWithRandomValues(3, 4, 50);
            var sumOfAllElements = 0;

            foreach (int number in twoDimensionalArray)
            {
                sumOfAllElements += number;
            }
            Console.WriteLine($"\nSum is {sumOfAllElements}");
        }

        static void Task8()
        {
            int[,] twoDimensionalArray = CreateArrayWithRandomValues(3, 4, 50);

            var diagonalOfArray = new List<int>();
            var reverseDiagonalOfArray = new List<int>();
            var reverseIterator = twoDimensionalArray.GetLength(1);

            for (int i = 0; i < twoDimensionalArray.GetLength(0); i++)
            {
                for (int j = 0; j < twoDimensionalArray.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        diagonalOfArray.Add(twoDimensionalArray[i, j]);
                    }
                }

                reverseIterator--;
                if (reverseIterator >= 0)
                {
                    reverseDiagonalOfArray.Add(twoDimensionalArray[i, reverseIterator]);
                }
            }
            
            Console.WriteLine($"Diagonal: {string.Join(" ", diagonalOfArray)}\nReverse diagonal: {string.Join(" ", reverseDiagonalOfArray)}");
        }

        static void Task9()
        {
            Console.WriteLine("Enter length of array");
            int lengthOfArray = int.Parse(Console.ReadLine());

            while ( !(lengthOfArray > 5 && lengthOfArray <= 10) )
            {
                Console.WriteLine("Array's length should be in the [6 - 10] range. Please re-enter length.");
                lengthOfArray = int.Parse(Console.ReadLine());
            }

            int[] arrayWithVariedLength = CreateArrayWithRandomValues(lengthOfArray, 50);

            int[] evenValuesOfArray = arrayWithVariedLength.Where((x,i) => i % 2 == 0).ToArray();
            Console.WriteLine($"Only even values of the array:\n{string.Join(" ", evenValuesOfArray)}");
        }


        static int[] CreateArrayWithRandomValues(int arrayLength, int maxRandomValue)
        {
            Random random = new Random();
            int[] randomArray = Enumerable.Repeat(1, arrayLength).Select(x => random.Next(1, maxRandomValue)).ToArray();
            Console.WriteLine($"Generated array:\n{string.Join(" ", randomArray)}");
            return randomArray;
        }

        static int[,] CreateArrayWithRandomValues(int arrayLengthFirstDimension, int arrayLengthSecondDimension, int maxRandomValue)
        {
            Random random = new Random();
            int[,] randomArray = new int[arrayLengthFirstDimension, arrayLengthSecondDimension];

            Console.WriteLine("Generated array:");

            for (int i = 0; i < randomArray.GetLength(0); i++)
            {
                for (int j = 0; j < randomArray.GetLength(1); j++)
                {
                    randomArray[i, j] = random.Next(1, 50);
                    Console.Write($"{randomArray[i, j]}\t");
                }
                Console.Write("\n");
            }
            return randomArray;
        }

        public static string GenerateName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }
            return Name;
        }
    }
}