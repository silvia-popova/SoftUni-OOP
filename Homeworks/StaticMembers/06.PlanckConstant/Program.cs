using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.PlanckConstant
{
    public static class Calculation
    {
        public const double PLANCK = 6.62606896e-34;
        public const double PI = 3.14159;

        public static double ReducePlanck()
        {
            //{Planck constant} / (2 * {Pi constant})
            return PLANCK / (2 * PI);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Calculation.ReducePlanck());
        }
    }
}
