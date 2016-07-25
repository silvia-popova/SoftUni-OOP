using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class Person : IComparable<Person>, IEquatable<Person>
    {
        public string name;
        public int age;
        public string town;

        public int CompareTo(Person other)
        {
            if (this.name != other.name)
            {
                return this.name.CompareTo(other.name);
            }

            return this.age.CompareTo(other.age);
        }

        public override int GetHashCode()
        {
            return this.name.GetHashCode() ^ this.age.GetHashCode();
        }

        public bool Equals(Person other)
        {
            if (this.name == other.name && this.age == other.age)
            {
                return true;
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            var other = (Person) obj;
            return this.name == other.name && this.age == other.age;
        }
    }

    public class PersonComparator1 : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x.name.Length == y.name.Length)
            {
                char a = x.name[0];
                char b = y.name[0];
                return a.ToString().ToLower().CompareTo(b.ToString().ToLower());
            }

            return x.name.Length.CompareTo(y.name.Length);
        }
    }

    public class PersonComparator2 : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.age.CompareTo(y.age);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());            

            var personsName = new SortedSet<Person>();
            var personsAge = new HashSet<Person>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var person = new Person();
                person.name = tokens[0];
                person.age = int.Parse(tokens[1]);

                personsName.Add(person);
                personsAge.Add(person);
            }

            Console.WriteLine(personsName.Count);
            Console.WriteLine(personsAge.Count);

            //foreach (var person in personsName)
            //{
            //    ConsoleColor currentColor = Console.ForegroundColor;
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine($"{person.name} {person.age}");
            //    Console.ForegroundColor = currentColor;
            //}

            //foreach (var person in personsAge)
            //{
            //    ConsoleColor currentColor = Console.ForegroundColor;
            //    Console.ForegroundColor = ConsoleColor.DarkBlue;
            //    Console.WriteLine($"{person.name} {person.age}");
            //    Console.ForegroundColor = currentColor;
            //}
        }
    }
}
