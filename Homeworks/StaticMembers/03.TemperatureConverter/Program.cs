using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.TemperatureConverter
{
    public static class TemperatureConverter
    {
        public static double ConvertCelsiusToFahrenheit(double c)
        {
            return ((9.0 / 5.0) * c) + 32;
        }

        public static double ConvertFahrenheitToCelsius(double f)
        {
            return (5.0 / 9.0) * (f - 32);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string unit = tokens[1];
                double degrees = double.Parse(tokens[0]);

                switch (unit)
                {
                    case "Celsius":
                        Console.WriteLine("{0:F2} Fahrenheit", TemperatureConverter.ConvertCelsiusToFahrenheit(degrees));
                        break;
                    case "Fahrenheit":
                        Console.WriteLine("{0:F2} Celsius", TemperatureConverter.ConvertFahrenheitToCelsius(degrees));
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
