using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Tuple
{
    using System.Text.RegularExpressions;

    public class CustomTuple<T1, T2>
    {
        public CustomTuple(T1 key, T2 value)
        {
            this.Item1 = key;
            this.Item2 = value;
        }

        public T1 Item1 { get; set; }

        public T2 Item2 { get; set; }

        public override string ToString()
        {
            return $"{this.Item1} -> {this.Item2}";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string line1 = Console.ReadLine();

            Regex reg = new Regex(@"(.+\s+.+)\s+(.+)");
            Match m = reg.Match(line1);

            var name = m.Groups[1].Value.Trim();
            var address = m.Groups[2].Value.Trim();

            var stringTuple= new CustomTuple<string, string>(name, address);


            string line2 = Console.ReadLine().Trim();

            Regex reg2 = new Regex(@"(.+)\s+(-*[0-9]+\.*[0-9]*)");
            Match m2 = reg2.Match(line2);

            var strVal = m2.Groups[1].Value.Trim();
            var doubleValue = decimal.Parse(m2.Groups[2].Value.Trim());
            var beerTuple = new CustomTuple<string, decimal>(strVal, doubleValue);


            string line3 = Console.ReadLine();

            Regex reg1 = new Regex(@"(-*\d+)\s+(.+)");
            Match m1 = reg1.Match(line3);

            var intVal = int.Parse(m1.Groups[1].Value.Trim());
            var doubleVal = decimal.Parse(m1.Groups[2].Value.Trim());
            var doubleTuple = new CustomTuple<int, decimal>(intVal, doubleVal);



            Console.WriteLine(stringTuple.ToString());
            Console.WriteLine(beerTuple.ToString());
            Console.WriteLine(doubleTuple.ToString());
        }
    }
}
