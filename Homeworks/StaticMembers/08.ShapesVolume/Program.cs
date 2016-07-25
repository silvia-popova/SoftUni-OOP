using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.ShapesVolume
{
    public static class VolumeCalculator
    {
        public static double CubeVolume(double a)
        {
            return Math.Pow(a, 3);
        }

        public static double CylinderVolume(double Radius, double Height)
        {
            return Math.PI * Radius * Radius * Height;
        }

        public static double TrianglePrismVolume(double a, double b, double c)
        {

            return 0.5 * a * b * c;
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
                
                string shape = tokens[0];

                switch (shape)
                {
                    case "Cube":
                        double a = double.Parse(tokens[1]);

                        Console.WriteLine("{0:F3}",
                           VolumeCalculator.CubeVolume(a));
                        break;
                    case "Cylinder":
                        a = double.Parse(tokens[1]);
                        double b = double.Parse(tokens[2]);

                        Console.WriteLine("{0:F3}",
                           VolumeCalculator.CylinderVolume(a, b));
                        break;
                    case "TrianglePrism":
                        a = double.Parse(tokens[1]);
                        b = double.Parse(tokens[2]);
                        double c = double.Parse(tokens[3]);
                        Console.WriteLine("{0:F3}",
                           VolumeCalculator.TrianglePrismVolume(a, b, c));
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
