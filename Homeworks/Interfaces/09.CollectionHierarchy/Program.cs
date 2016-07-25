using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.CollectionHierarchy
{
    public class AddCollection
    {
        public AddCollection()
        {
            this.List= new List<string>();
        }
        public List<string> List { get; set; }

        public int Add(string value)
        {
            int index = this.List.Count;
            this.List.Add(value);
            return index;
        }
    }

    public class AddRemoveCollection
    {
        public AddRemoveCollection()
        {
            this.List = new List<string>();
        }
        public List<string> List { get; set; }

        public int Add(string value)
        {
            this.List.Insert(0, value);
            return 0;
        }

        public string Remove()
        {
            string removed = List[this.List.Count - 1];
            this.List.RemoveAt(this.List.Count - 1);

            return removed;
        }
    }

    public class MyList
    {
        public MyList()
        {
            this.List = new List<string>();
        }
        public List<string> List { get; set; }

        public int Add(string value)
        {
            this.List.Insert(0, value);

            return 0;
        }

        public string Remove()
        {
            string removed = List[0];
            this.List.RemoveAt(0);

            return removed;
        }

        public int Used { get { return this.List.Count; } }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            AddCollection addCollection = new AddCollection();
            AddRemoveCollection removeCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            foreach (var str in tokens)
            {
                Console.Write(addCollection.Add(str));
                Console.Write(" ");
            }

            Console.WriteLine();

            foreach (var str in tokens)
            {
                Console.Write(removeCollection.Add(str));
                Console.Write(" ");
            }

            Console.WriteLine();

            foreach (var str in tokens)
            {
                Console.Write(myList.Add(str));
                Console.Write(" ");
            }
            Console.WriteLine();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.Write(removeCollection.Remove());
                Console.Write(" ");
            }

            Console.WriteLine();

            for (int i = 0; i < count; i++)
            {
                Console.Write(myList.Remove());
                Console.Write(" ");
            }
        }
    }
}
