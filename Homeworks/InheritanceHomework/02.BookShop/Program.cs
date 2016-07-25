using System;
using System.Text;

namespace _02.BookShop
{
    public class Book
    {
        private string title;
        private string author;
        private double price;

        public Book(string author, string title, double price)
        {
            this.Title = title;
            this.Price = price;
            this.Author = author;
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }

                this.title = value;
            }
        }

        public string Author
        {
            get
            {
                return this.author;
            }

            set
            {
                if (CheckName(value))
                {
                    throw new ArgumentException("Author not valid!");
                }

                this.author = value;
            }
        }

        public virtual double Price
        {
            get { return this.price; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }

                this.price = value;
            }
        }

        private bool CheckName(string name)
        {
            var names = name.Split();
            var secondName = names[1];

            if (char.IsDigit(secondName[0]))
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Type: ").Append(this.GetType().Name)
                    .Append(Environment.NewLine)
                    .Append("Title: ").Append(this.Title)
                    .Append(Environment.NewLine)
                    .Append("Author: ").Append(this.Author)
                    .Append(Environment.NewLine)
                    .Append("Price: ").Append(string.Format("{0:F1}",this.Price))
                    .Append(Environment.NewLine);

            return sb.ToString();
        }
    }

    public class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string title, string author, double price) 
            : base(title, author, price)
        {
        }

        public override double Price
        {
            get
            {
                return base.Price * 1.3;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string author = Console.ReadLine();
                string title = Console.ReadLine();
                double price = double.Parse(Console.ReadLine());

                Book book = new Book(author, title, price);
                GoldenEditionBook goldenEditionBook = new GoldenEditionBook(author, title, price);

                Console.WriteLine(book);
                Console.WriteLine(goldenEditionBook);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

        }
    }
}
