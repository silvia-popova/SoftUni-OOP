using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.AnimalClinic
{
    public class Animal
    {
        public string name;
        public string breed;

        public Animal(string name, string breed)
        {
            this.name = name;
            this.breed = breed;
        }

        public override string ToString()
        {
            return string.Format("[{0} ({1})]", this.name, this.breed);
        }
    }

    public static class AnimalClinic
    {
        public static List<Animal> healedAnimals = new List<Animal>();
        public static List<Animal> rehabilitedAnimals = new List<Animal>();
        public static int count;

        public static string PatienID()
        {
            return string.Format("Patient {0}", ++count);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                string breed = tokens[1];
                string command = tokens[2];

                var animal = new Animal(name, breed);

                switch (command)
                {
                    case "heal":
                        AnimalClinic.healedAnimals.Add(animal);
                        Console.WriteLine("{0}: {1} has been healed!", 
                            AnimalClinic.PatienID(), animal.ToString());
                        break;
                    case "rehabilitate":
                        AnimalClinic.rehabilitedAnimals.Add(animal);
                        Console.WriteLine("{0}: {1} has been rehabilitated!",
                            AnimalClinic.PatienID(), animal.ToString());
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Total healed animals: {0}", AnimalClinic.healedAnimals.Count);
            Console.WriteLine("Total rehabilitated animals: {0}", AnimalClinic.rehabilitedAnimals.Count);

            input = Console.ReadLine();

            switch (input)
            {
                case "heal":
                    foreach (var animal in AnimalClinic.healedAnimals)
                    {
                        Console.WriteLine(animal.name + " " + animal.breed);
                    }
                    break;
                case "rehabilitate":
                    foreach (var animal in AnimalClinic.rehabilitedAnimals)
                    {
                        Console.WriteLine(animal.name + " " + animal.breed);
                    }
                    break;
            }
        }
    }
}
