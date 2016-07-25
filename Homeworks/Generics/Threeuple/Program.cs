using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Threeuple
{
    public class Threeuple<T1, T2, T3>
    {
        public Threeuple(T1 item1, T2 item2, T3 item3)
        {
            this.Item1 = item1;
            this.Item2 = item2;
            this.Item3 = item3;
        }

        public T1 Item1 { get; set; }

        public T2 Item2 { get; set; }

        public T3 Item3 { get; set; }

        public override string ToString()
        {
            return $"{this.Item1} -> {this.Item2} -> {this.Item3}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] line1 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var stringTuple = new Threeuple<string, string, string>(
                line1[0] + " " + line1[1], line1[2], line1[3]);

            string[] line2 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            bool drunk = line2[2] == "drunk" ? true : false;

            var beerTuple = new Threeuple<string, int, bool>(line2[0], int.Parse(line2[1].Trim()), drunk);

            string[] line3 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var doubleTuple = new Threeuple<string, double, string>(line3[0].Trim(), double.Parse(line3[1].Trim()), line3[2]);

            Console.WriteLine(stringTuple.ToString());
            Console.WriteLine(beerTuple.ToString());
            Console.WriteLine(doubleTuple.ToString());
        }
    }
}
