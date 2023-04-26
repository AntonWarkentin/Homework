using System.Collections.Generic;
using System;

namespace Home_8
{
    internal class Program
    {

        /// <summary>
        /// Составьте рацион питания для человека на неделю (Person - Содержит поля Name, MaxNumberOfCalories(Макс Количество-калорий потребляемых за день)).
        /// Cам рацион представляет пару ключ(День недели(Enum) - значение (список продуктов) - List.Продукт содержит поля: название продукта, Количество калорий (1 class Product)
        /// Составьте рацион произвольным образом(пример: создайте класс RationCreator и добавьте в него метод по созданию рациона) на каждый день и назначьте его Person.
        /// Добавьте метод в классе Person, который проверит рацион на каждый день и если в какой-то день общее количество калорий превышает максимальное, 
        /// будет удалять продукты из списка, пока сумма их калорий будет меньше либо равна максимальному количеству калорий, потребляемых человеком за день.
        /// </summary>

        static void Main(string[] args)
        {
            Person person = new Person("Alex", 2200, new Ration());
            Console.WriteLine(person.Ration.ToString());
            person.CheckPersonsRations();
            Console.WriteLine(person.Ration.ToString());
        }
    }
}