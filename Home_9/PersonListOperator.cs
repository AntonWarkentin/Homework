using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_9
{
    internal class PersonList : IEnumerable
    {
        private const int PersonCount = 10;

        private List<Person> persons;

        public List<Person> Persons 
        {
            get => persons;
            set
            {
                if (persons == null)
                {
                    persons = value;
                }
                else
                {
                    foreach (Person person in value)
                    {
                        persons.Add(person);
                    }
                }
            }
         }

        public IEnumerator GetEnumerator() => Persons.GetEnumerator();

        public PersonList()
        {
            Persons = CreateRandomListOfPersons();
        }

        public PersonList(IEnumerable<Person> persons)
        {
            Persons = persons.ToList();
        }

        public IEnumerable<Person> Where(Predicate<Person> predicate)
        {
            foreach (Person person in Persons)
            {
                if (predicate(person))
                {
                    yield return person;
                }
            }
        }

        public static List<Person> CreateRandomListOfPersons()
        {
            Random rnd = new Random();
            List<Person> personsList = new List<Person>();
            
            for (int i = 0; i < PersonCount; i++)
            {
                Person newPerson = new Person( Home_3.Program.GenerateName(5), rnd.Next(18, 100), rnd.Next(1000, 10000));
                personsList.Add(newPerson);
            }

            return personsList;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (Person person in this)
            {
                stringBuilder.Append($"{person.ToString()}\n");
            }

            return stringBuilder.ToString();
        }
    }
}
