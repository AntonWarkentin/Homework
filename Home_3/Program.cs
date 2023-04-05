using System;
using System.Collections;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task0();
            //Task1();
            Task2();
            //Task3();
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
            Console.Write(string.Join(" ", initialArray));

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
            Console.Write(string.Join(" ", array));

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

        }

        static void Task4()
        {

        }
        static void Task5()
        {

        }

        static void Task6()
        {

        }

        static void Task7()
        {

        }

        static void Task8()
        {

        }

        static void Task9()
        {

        }

        static int[] CreateArrayWithRandomValues(int arrayLength, int maxRandomValue)
        {
            Random random = new Random();
            int[] randomArray = Enumerable.Repeat(0, arrayLength).Select(i => random.Next(1, maxRandomValue)).ToArray();
            return randomArray;
        }
    }
}