using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ListyIterator
{
    public class ListyColection<T> : IEnumerable<T>
    {
        private List<T> list;
        private int count;

        public ListyColection()
        {
            this.list = new List<T>();
        }

        public int Count => this.count;

        public void Pop()
        {
            if (this.list.Count == 0)
            {
                throw new AggregateException("No elements");
            }

            this.count--;
            this.list.RemoveAt(this.list.Count - 1);
        }

        public void Push(T item)
        {
            this.count ++;
            this.list.Add(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            

            if (list.Count % 2 == 0)
            {
                for (int i = 0; i <= list.Count - 1; i += 2)
                {
                    yield return list[i];
                }

                for (int i = list.Count - 1; i >= 0; i -= 2)
                {
                    yield return list[i];
                }
            }
            else 
            {
                for (int i = 0; i <= list.Count - 1; i += 2)
                {
                    yield return list[i];
                }

                for (int i = list.Count - 2; i >= 0; i -= 2)
                {
                    yield return list[i];
                }
            }

            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class ListyIteratorTest
    {
        static void Main(string[] args)
        {
            var iterator = new ListyColection<string>();

            string input = Console.ReadLine();

            Regex regex = new Regex(@"(-*[0-9]+)");
            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                iterator.Push(match.Value);
            }

            var result = new StringBuilder();

            foreach (var item in iterator)
            {
                result.Append(item);
                result.Append(", ");
            }

            result.Remove(result.Length - 2, 2);

            Console.WriteLine(result.ToString());
        }
    }
}
