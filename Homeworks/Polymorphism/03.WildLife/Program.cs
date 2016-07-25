using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.WildLife
{
    public abstract class Food
    {
        protected Food(int quantity)
        {
            Quantity = quantity;
        }
        public int Quantity { get; set; } 
    }

    public class Vegetable : Food
    {
        public Vegetable(int quantity) : base(quantity)
        {
        }
    }

    public class Meat : Food
    {
        public Meat(int quantity) : base(quantity)
        {
        }
    }

    public abstract class Animal
    {
        protected Animal(string animalType, string animalName, double animalWeight)
        {
            this.AnimalName = animalName;
            this.AnimalType = animalType;
            this.AnimalWeight = animalWeight;
        }

        public string AnimalName { get; set; }

        public string AnimalType { get; set; }

        public double AnimalWeight { get; set; }

        public int FoodEaten { get; set; }

        public abstract void MakeSound();

        public virtual void Eat(Food food)
        {
            this.FoodEaten += food.Quantity;
        }
    }

    public abstract class Mammal : Animal
    {
        protected Mammal(string animalType, string animalName, double animalWeight, string livingRegion) 
            : base(animalType, animalName, animalWeight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; set; }

        public override string ToString()
        {
            //Zebra[Doncho, 500, Africa, 150]
            return string.Format($"{this.AnimalType}[{this.AnimalName}, " +
                                 $"{this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]");
        }
    }

    public abstract class Feline : Mammal 
    {
        protected Feline(string animalType, string animalName, double animalWeight, string livingRegion)
            : base(animalType, animalName, animalWeight, livingRegion)
        {
            
        }
    }

    public class Mouse : Mammal
    {
        public Mouse(string animalType, string animalName, double animalWeight, string livingRegion) 
            : base(animalType, animalName, animalWeight, livingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("SQUEEEAAAK!");
        }

        public override void Eat(Food food)
        {
            if (!(food is Vegetable))
            {
                Console.WriteLine($"{this.GetType().Name}s are not eating that type of food!");
                return;
            }

            base.Eat(food);
        }
    }

    public class Zebra : Mammal
    {
        public Zebra(string animalType, string animalName, double animalWeight, string livingRegion)
            : base(animalType, animalName, animalWeight, livingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Zs");
        }

        public override void Eat(Food food)
        {
            if (!(food is Vegetable))
            {
                Console.WriteLine($"{this.GetType().Name}s are not eating that type of food!");
                return;
            }

            base.Eat(food);
        }
    }

    public class Cat : Feline 
    {
        public Cat(string animalType, string animalName, double animalWeight, string livingRegion, string animalBread)
            : base(animalType, animalName, animalWeight, livingRegion)
        {
            this.AnimalBread = animalBread;
        }

        public string AnimalBread { get; set; }

        public override void MakeSound()
        {
            Console.WriteLine("Meowwww");
        }

        public override string ToString()
        {
            //Cat[Gray, Persian, 1.1, Home, 4]
            return string.Format($"{this.AnimalType}[{this.AnimalName}, " +
                                 $"{this.AnimalBread}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]");

        }
    }

    public class Tiger : Feline
    {
        public Tiger(string animalType, string animalName, double animalWeight, string livingRegion)
            : base(animalType, animalName, animalWeight, livingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("ROAAR!!!");
        }

        public override void Eat(Food food)
        {
            if (!(food is Meat))
            {
                Console.WriteLine($"{this.GetType().Name}s are not eating that type of food!");
                return;
            }

            base.Eat(food);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Animal> animals = new List<Animal>();
            List<Food> foods = new List<Food>();

            while (input != "End")
            {
                string[] tokensAnimal = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string animal = tokensAnimal[0];
                string animalName = tokensAnimal[1];
                double animalWeight = double.Parse(tokensAnimal[2]);
                string livingRegion = tokensAnimal[3];
                

                switch (animal)
                {
                    case "Cat":
                        string animalBread = tokensAnimal[4];
                        var cat = new Cat(animal, animalName, animalWeight, livingRegion, animalBread);
                        animals.Add(cat);
                        break;
                    case "Tiger":
                        var tiger = new Tiger(animal, animalName, animalWeight, livingRegion);
                        animals.Add(tiger);
                        break;
                    case "Zebra":
                        var zebra = new Zebra(animal, animalName, animalWeight, livingRegion);
                        animals.Add(zebra);
                        break;
                    case "Mouse":
                        var mouse = new Mouse(animal, animalName, animalWeight, livingRegion);
                        animals.Add(mouse);
                        break;
                    default:
                        break;
                }

                string[] tokensFood = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string food = tokensFood[0];
                int foodWeight = int.Parse(tokensFood[1]);

                switch (food)
                {
                    case "Vegetable":
                        var veg = new Vegetable(foodWeight);
                        foods.Add(veg);
                        break;
                    case "Meat":
                        var meat = new Meat(foodWeight);
                        foods.Add(meat);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < animals.Count; i++)
            {
                var animal = animals[i];
                var food = foods[i];

                animal.MakeSound();
                animal.Eat(food);
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
