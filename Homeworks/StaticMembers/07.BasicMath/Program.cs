using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.BasicMath
{
    public static class MathUtil
    {
        public static double Sum(double firstNum, double secondNum)
        {
            
            return firstNum + secondNum;
        }

        public static double Subtract(double firstNum, double secondNum)
        {

            return firstNum - secondNum;
        }

        public static double Multiply(double firstNum, double secondNum)
        {

            return firstNum * secondNum;
        }

        public static double Devide(double firstNum, double secondNum)
        {

            return firstNum / secondNum;
        }

        public static double Percentage(double firstNum, double secondNum)
        {

            return firstNum * (secondNum / 100);
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
                double firstNum = double.Parse(tokens[1]);
                double secondNum = double.Parse(tokens[2]);
                string command = tokens[0];
                
                switch (command)
                {
                    case "Sum":
                        Console.WriteLine("{0:F2}",
                           MathUtil.Sum(firstNum, secondNum));
                        break;
                    case "Multiply":
                        Console.WriteLine("{0:F2}",
                           MathUtil.Multiply(firstNum, secondNum));
                        break;
                    case "Divide":
                        Console.WriteLine("{0:F2}",
                           MathUtil.Devide(firstNum, secondNum));
                        break;
                    case "Subtract":
                        Console.WriteLine("{0:F2}",
                           MathUtil.Subtract(firstNum, secondNum));
                        break;
                    case "Percentage":
                        Console.WriteLine("{0:F2}",
                           MathUtil.Percentage(firstNum, secondNum));
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
