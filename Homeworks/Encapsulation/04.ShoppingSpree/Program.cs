using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private IList<Product> bag;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }

        public string Name
        {
            get { return this.name; }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get { return this.money; }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public IList<Product> Bag => this.bag;

        public string AddProductToBag(Product product)
        {
            if (this.Money - product.Price >= 0)
            {
                this.Bag.Add(product);
                this.Money -= product.Price;

                return string.Format("{0} bought {1}", this.Name, product.Name);
            }

            return string.Format("{0} can't afford {1}", this.Name, product.Name);
        }

        public override string ToString()
        {
            if (this.bag.Count == 0)
            {
                return string.Format("{0} - Nothing bought", this.Name);
            }

            return string.Format("{0} - {1}", this.Name, string.Join(", ", this.Bag.Select(x => x.Name)));
        }
    }

    public class Product
    {
        private string name;
        private decimal price;

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.price = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var rgx = new Regex(@"([a-zA-Z]+)=(-*[0-9]+\.*[0-9]*)");
            MatchCollection matchesPerson = rgx.Matches(input);

            List<Person> persons = new List<Person>();

            foreach (Match match in matchesPerson)
            {
                string name = match.Groups[1].Value;
                decimal money = decimal.Parse(match.Groups[2].Value);

                try
                {
                    Person person = new Person(name, money);
                    persons.Add(person);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
            }

            input = Console.ReadLine();

            MatchCollection matchesProducts = rgx.Matches(input);

            List<Product> products = new List<Product>();

            foreach (Match match in matchesProducts)
            {
                string name = match.Groups[1].Value;
                decimal money = decimal.Parse(match.Groups[2].Value);

                try
                {
                    Product product = new Product(name, money);
                    products.Add(product);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }

                
            }

            input = Console.ReadLine();

            while (input != "END")
            {
                string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string personName = tokens[0];
                string productName = tokens[1];

                Person person = persons.FirstOrDefault(x => x.Name == personName);
                Product product = products.FirstOrDefault(x => x.Name == productName);

                if (person != null && product != null)
                {
                    Console.WriteLine(person.AddProductToBag(product));
                }

                

                input = Console.ReadLine();
            }

            foreach (var person in persons)
            {
                Console.WriteLine(person.ToString());
            }

        }
    }
}
