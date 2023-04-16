using System;

namespace Home_2 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
        }

        static void Task1()
        {
            var rand = new Random();
            double operand1 = rand.Next();
            double operand2 = rand.Next();

            Console.WriteLine("Please enter operator sign");
            var sign = Console.ReadLine();

            switch (sign)
            {
                case "+":
                    Console.WriteLine($"{operand1} + {operand2} = {operand1 + operand2}");
                    break;
                case "-":
                    Console.WriteLine($"{operand1} - {operand2} = {operand1 - operand2}");
                    break;
                case "*":
                    Console.WriteLine($"{operand1} * {operand2} = {operand1 * operand2}");
                    break;
                case "/":
                    if (operand2 != 0) Console.WriteLine($"{operand1} / {operand2} = {operand1 / operand2}");
                    else Console.WriteLine("Division by zero!");
                    break;
                default:
                    Console.WriteLine("Incorrect operator sign");
                    break;
            }
        }

        static void Task2()
        {
            Console.WriteLine("Please enter number from 0 to 100");
            double usersNumber = double.Parse(Console.ReadLine());

            if (usersNumber >= 0 && usersNumber <= 14) Console.WriteLine("Number is in range [0 - 14]");
            else if (usersNumber >= 15 && usersNumber <= 35) Console.WriteLine("Number is in range [15 - 35]");
            else if (usersNumber >= 36 && usersNumber <= 50) Console.WriteLine("Number is in range [36 - 50]");
            else if (usersNumber >= 51 && usersNumber <= 100) Console.WriteLine("Number is in range [51 - 100]");
            else Console.WriteLine("Incorrect number");
        }

        static void Task3()
        {
            Console.WriteLine("Please enter word about weather in Russian");
            string russianWord = Console.ReadLine().ToLower();

            switch (russianWord)
            {
                case "ветренно":
                    Console.WriteLine("Windy weather");
                    break;
                case "солнечно":
                    Console.WriteLine("Sunny weather");
                    break;
                case "дождливо":
                    Console.WriteLine("Rainy weather");
                    break;
                case "ясно":
                    Console.WriteLine("Clear weather");
                    break;
                case "пасмурно":
                    Console.WriteLine("Cloudy weather");
                    break;
                case "безветренно":
                    Console.WriteLine("Calm weather");
                    break;
                case "шторм":
                    Console.WriteLine("Stormy weather");
                    break;
                case "влажность":
                    Console.WriteLine("Humidity");
                    break;
                case "температура":
                    Console.WriteLine("Temperature");
                    break;
                case "туманно":
                    Console.WriteLine("Foggy weather");
                    break;
                default:
                    Console.WriteLine("I don't know such word, sorry!");
                    break;
            }
        }

        static void Task4()
        {
            Console.WriteLine("Please enter any integer number");
            int number = int.Parse(Console.ReadLine());

            if (number % 2 == 0) Console.WriteLine("This number is even");
            else Console.WriteLine("This number isn't even");
        }

    }
}