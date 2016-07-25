using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitInterfaces
{
    public interface IResident
    {
        string Name { get; set; }
        string Country { get; set; }

        string GetName();
    }

    public interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }

        string GetName();
    }

    public class Person : IPerson, IResident
    {
        private string name;

        public Person(string name, string country, int age)
        {
            this.name = name;
            this.Country = country;
            this.Age = age;
        }

        string IPerson.Name { get; set; }

        public string Country { get; set; }

        public int Age { get; set; }

        string IResident.Name { get; set; }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.name}";
        }

        string IPerson.GetName()
        {
            return this.name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split(
                new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var person = new Person(tokens[0], tokens[1], int.Parse(tokens[2]));

                IPerson person1 = person;
                IResident person2 = person;

                Console.WriteLine(person1.GetName());
                Console.WriteLine(person2.GetName());

                input = Console.ReadLine();
            }
        }
    }
}
