using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace _05.PizzaCalories
{
    class Program
    {
        public class Dough
        {
            private const decimal defaultCaloriesPerGram = 2m;

            private FlourType flourType;
            private BakingTechnique bakingTechnique;
            private decimal weight;

            public Dough(FlourType flourType, BakingTechnique bakingTechnique, decimal weight)
            {
                this.flourType = flourType;
                this.bakingTechnique = bakingTechnique;
                this.Weight = weight;
            }

            public decimal Weight
            {
                get
                {
                    return this.weight;
                }

                private set
                {
                    if (value <= 0 || value > 200)
                    {
                        throw new ArgumentException("Dough weight should be in the range [1..200].");
                    }

                    this.weight = value;
                }
            }

            public decimal CaloriesPerGram()
            {
                decimal result = defaultCaloriesPerGram * this.weight;

                if (this.flourType == FlourType.white)
                {
                    result *= 1.5m;
                }

                if (this.bakingTechnique == BakingTechnique.chewy)
                {
                    result *= 1.1m;
                }

                if (this.bakingTechnique == BakingTechnique.crispy)
                {
                    result *= 0.9m;
                }

                return result;
            }
        }

        public enum BakingTechnique
        {
            crispy,
            chewy,
            homemade
        }

        public enum FlourType
        {
            white,
            wholegrain
        }

        public class Topping
        {
            private const decimal defaultCaloriesPerGram = 2m;

            private ToppingType toppingType;
            private decimal weight;

            public Topping(ToppingType toppingType, decimal weight)
            {
                this.toppingType = toppingType;
                this.Weight = weight;
            }

            public decimal Weight
            {
                get
                {
                    return this.weight;
                }

                private set
                {
                    if (value <= 0 || value > 50)
                    {
                        throw new ArgumentException(
                            string.Format("{0} weight should be in the range [1..50].", this.toppingType));
                    }

                    this.weight = value;
                }
            }

            public decimal CaloriesPerGram()
            {
                decimal result = defaultCaloriesPerGram * this.weight;

                if (this.toppingType == ToppingType.meat)
                {
                    result *= 1.2m;
                }
                else if (this.toppingType == ToppingType.veggies)
                {
                    result *= 0.8m;
                }
                else if (this.toppingType == ToppingType.cheese)
                {
                    result *= 1.1m;
                }
                else
                {
                    result *= 0.9m;
                }

                return result;
            }
        }

        public enum ToppingType
        {
            meat,
            veggies,
            cheese,
            sauce
        }

        public class Pizza
        {
            private string name;
            private Dough dough;
            private int numberOfTopings;
            private IList<Topping> toppings;

            public Pizza(string name, Dough dough, int numberOfToppings)
            {
                this.Name = name;
                this.dough = dough;
                this.NumberOfTopings = numberOfToppings;
                this.toppings = new List<Topping>();
            }

            public string Name
            {
                get
                {
                    return this.name;
                }

                private set
                {
                    if (string.IsNullOrEmpty(value) || value.Length > 15)
                    {
                        throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                    }

                    this.name = value;
                }
            }

            public int NumberOfTopings
            {
                get
                {
                    return this.numberOfTopings;
                }

                private set
                {
                    if (value > 10 || value < 0)
                    {
                        throw new ArgumentException("Number of toppings should be in range [0..10].");
                    }

                    this.numberOfTopings = value;
                }
            }

            public IList<Topping> Toppings => this.toppings;

            public decimal TotalCalories()
            {
                decimal result = dough.CaloriesPerGram();

                foreach (var topping in toppings)
                {
                    result += topping.CaloriesPerGram();
                }

                return result;
            }

        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[1];
            int numOfToppings = int.Parse(tokens[2]);

            if (numOfToppings < 0 || numOfToppings > 10)
            {
                Console.WriteLine("Number of toppings should be in range [0..10].");
                return;
            }

            input = Console.ReadLine();

            string[] tokensArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string flourT = tokensArgs[1].ToLower();

            if (flourT != "white" && flourT != "wholegrain")
            {
                Console.WriteLine("Invalid type of dough.");
                return;
            }

            string bakingTech = tokensArgs[2].ToLower();

            if (bakingTech != "crispy" && bakingTech != "chewy" && bakingTech != "homemade")
            {
                Console.WriteLine("Invalid type of dough.");
                return;
            }
            decimal weight = decimal.Parse(tokensArgs[3]);

            try
            {
                var bakingType = (BakingTechnique)Enum.Parse(typeof(BakingTechnique), bakingTech);
                var flourType = (FlourType)Enum.Parse(typeof(FlourType), flourT);

                try
                {
                    var dough = new Dough(flourType, bakingType, weight);

                    try
                    {
                        var pizza = new Pizza(name, dough, numOfToppings);

                        for (int i = 0; i < numOfToppings; i++)
                        {
                            string[] inputArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            string toppingT = inputArgs[1];
                            decimal toppingWeight = decimal.Parse(inputArgs[2]);

                            if (toppingT.ToLower() != "meat" && toppingT.ToLower() != "veggies"
                                && toppingT.ToLower() != "cheese" && toppingT.ToLower() != "sauce")
                            {
                                Console.WriteLine($"Cannot place {toppingT} on top of your pizza.");
                                return;
                            }

                            try
                            {
                                var toppingType = (ToppingType)Enum.Parse(typeof(ToppingType), toppingT.ToLower());

                                try
                                {
                                    var topping = new Topping(toppingType, toppingWeight);
                                    pizza.Toppings.Add(topping);
                                }
                                catch (ArgumentException ae)
                                {

                                    Console.WriteLine(ae.Message);
                                    return;
                                }
                            }
                            catch (Exception)
                            {

                                Console.WriteLine("Cannot place {0} on top of your pizza.", toppingT);
                                return;
                            }
                        }

                        Console.WriteLine("{0} - {1:F2} Calories.", pizza.Name, pizza.TotalCalories());

                    }
                    catch (ArgumentException ae)
                    {

                        Console.WriteLine(ae.Message);
                        return;
                    }
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                    return;
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Invalid type of dough.");
                return;
            }




        }
    }
}
