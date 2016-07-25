using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.GenericBox
{
    public class Box<T> 
        where T : IComparable<T>
    {
        public Box() : this(default(T))
        {
        }

        public Box(T value) 
        {
            Value = value;
        }

        public T Value { get; set; }


        public int CompareTo(T otherBox) 
        {
            T a = this.Value;
            return a.CompareTo(otherBox);
        }

        
        public override string ToString()
        {
            return $"{Value.GetType().FullName}: {Value}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Box<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double num = double.Parse(Console.ReadLine());

                var box = new Box<double>(num);

                list.Add(box);
            }

            double strToCompare = double.Parse(Console.ReadLine());

            int count = FindGreaterElements(list, strToCompare);

            Console.WriteLine(count);
        }

        private static int FindGreaterElements<T>(List<Box<T>> list, T strToCompare)
            where T : IComparable<T>
        {
            int count = 0;

            foreach (var element in list)
            {
                if (element.CompareTo(strToCompare) == 1)
                {
                    count++;
                }
            }

            return count;
        }

        public static void Swap<T>(List<T> list, int firstIndex, int secondIndex)
        {
            var firstElement = list[firstIndex];

            list[firstIndex] = list[secondIndex];

            list[secondIndex] = firstElement;
        }
    }
}
