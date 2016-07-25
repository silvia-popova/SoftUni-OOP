using System;
using System.Collections.Generic;

namespace _06.Animals
{
    public interface ISound
    {
        void ProduceSound();
    }

    public class Animal : ISound
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                //if (char.IsLower(value[0]))
                //{
                //    throw new ArgumentException("Invalid input!");
                //}

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.age = value;
            }
        }

        public virtual string Gender {
            get
            {
                return this.gender;
            }
            set
            {
                if (value != "female" && value != "male")
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.gender = value;
            }
        }

        public virtual void ProduceSound()
        {
            Console.WriteLine("Not implemented!");
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} {this.Name} {this.Age} {this.Gender}";
        }
    }


    public class Cat : Animal
    {
        public Cat(string name, int age, string gender)
            : base(name, age, gender)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("MiauMiau");
        }
    }

    public class Dog : Animal
    {
        public Dog(string name, int age, string gender)
            : base(name, age, gender)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("BauBau");
        }
    }

    public class Frog : Animal
    {
        public Frog(string name, int age, string gender)
            : base(name, age, gender)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Frogggg");
        }
    }

    public class Kitten : Cat
    {
        public Kitten(string name, int age, string gender)
            : base(name, age, gender)
        {
            CheckGender(gender);
        }

        private void CheckGender(string s)
        {
            if (s.ToLower() != "female")
            {
                throw new ArgumentException("Invalid input!");
            }
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Miau");
        }

        
    }

    public class Tomcat : Cat
    {
        public Tomcat(string name, int age, string gender)
            : base(name, age, gender)
        {
            this.CheckGender(gender);
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Give me one million b***h");
        }

        private void CheckGender(string s)
        {
            if (s.ToLower() != "male")
            {
                throw new ArgumentException("Invalid input!");
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Animal>animals = new List<Animal>();

            string animal = Console.ReadLine().ToLower();

            while (animal != "Beast!")
            {
                string input = Console.ReadLine();

                string[] animalInfo = input.Split();
                var name = animalInfo[0];
                int age = int.Parse(animalInfo[1]);
                string gender = animalInfo[2];

                try
                {
                    switch (animal)
                    {
                        case "cat":
                            Animal currentAnimal = new Cat(name, age, gender);
                            animals.Add(currentAnimal);
                            break;
                        case "dog":
                            currentAnimal = new Dog(name, age, gender);
                            animals.Add(currentAnimal);
                            break;
                        case "frog":
                            currentAnimal = new Frog(name, age, gender);
                            animals.Add(currentAnimal);
                            break;
                        case "kitten":
                            currentAnimal = new Kitten(name, age, gender);
                            animals.Add(currentAnimal);
                            break;
                        case "tomcat":
                            currentAnimal = new Tomcat(name, age, gender);
                            animals.Add(currentAnimal);
                            break;
                        case "animal":
                            currentAnimal = new Animal(name, age, gender);
                            animals.Add(currentAnimal);
                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            return;
                    }
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                    return;
                }

                animal = Console.ReadLine().ToLower();
            }

            foreach (var a in animals)
            {
                Console.WriteLine(a.ToString());
                a.ProduceSound();
            }
       }
    }
}
