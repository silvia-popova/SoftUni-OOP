using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BorderControl
{
    public interface IIDable
    {
        string Id { get; set; }

        bool CheckIfFakeId(string end);
    }

    public interface IBuyer
    {
        string Name { get; set; }

        int Food { get; set; }

        void BuyFood();
    }

    public interface IBirthdatable
    {
        string Birthdate { get; set; }

        bool CheckIfSameYear(string end);
    }

    public class Citizen : IIDable, IBirthdatable, IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public int Age { get; set; }

        public string Name { get; set; }

        public string Id { get; set; }

        public string Birthdate { get; set; }

        public int Food { get; set; }

        public void BuyFood()
        {
            this.Food += 10;
        }

        public bool CheckIfSameYear(string end)
        {
            if (this.Birthdate.EndsWith(end))
            {
                return true;
            }

            return false;
        }

        public bool CheckIfFakeId(string end)
        {
            if (this.Id.EndsWith(end))
            {
                return true;
            }

            return false;
        }
    }

    public class Rebel : IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }

        public int Age { get; set; }

        public string Name { get; set; }

        public string Group { get; set; }

        public int Food { get; set; }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }

    public class Pet : IBirthdatable
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name { get; set; }

        public string Birthdate { get; set; }

        public bool CheckIfSameYear(string end)
        {
            if (this.Birthdate.EndsWith(end))
            {
                return true;
            }

            return false;
        }
    }

    public class Robot : IIDable
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; set; }

        public string Id { get; set; }

        public bool CheckIfFakeId(string end)
        {
            if (this.Id.EndsWith(end))
            {
                return true;
            }

            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<IBuyer> a = new List<IBuyer>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (inputArgs.Length == 3)
                {
                    IBuyer rebel = new Rebel(inputArgs[0], int.Parse(inputArgs[1]), inputArgs[2]);
                    a.Add(rebel);
                }
                else
                {
                    IBuyer citizen = new Citizen(inputArgs[0], int.Parse(inputArgs[1]), inputArgs[2], inputArgs[3]);
                    a.Add(citizen);
                }
            }

            string name = Console.ReadLine();

            while (name != "End")
            {
                var s = a.FirstOrDefault(d => d.Name == name);

                if (s != null)
                {
                    s.BuyFood();
                }

                name = Console.ReadLine();
            }

            Console.WriteLine(a.Sum(f => f.Food));
        }
    }
}
