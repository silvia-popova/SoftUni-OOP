using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Telephony
{
    public interface ICallable
    {
        string Call(string number);
    }

    public interface IBrowseable
    {
        string Browse(string url);
    }

    public class Phone : ICallable, IBrowseable
    {
        public string Call(string number)
        {
            foreach (var ch in number)
            {
                if (!char.IsDigit(ch))
                {
                    return "Invalid number!";
                }
            }

            return $"Calling... {number}";
        }

        public string Browse(string url)
        {
            foreach (var ch in url)
            {
                if (char.IsDigit(ch))
                {
                    return "Invalid URL!";
                }
            }

            return $"Browsing: {url}!";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();

            var phone = new Phone();

            foreach (var number in numbers)
            {
                Console.WriteLine(phone.Call(number));
            }

            foreach (var url in urls)
            {
                Console.WriteLine(phone.Browse(url));
            }
        }
    }
}
