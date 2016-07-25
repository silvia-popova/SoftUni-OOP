using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _01.ClassBox
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        //surface area, lateral surface area and its volume
        public double SurfaceArea()
        {
            //2lw + 2lh + 2wh
            double surfaceArea = 2 * this.length * this.width + 2 * this.length * this.height + 2 * this.width * this.height;

            return surfaceArea;
        }

        public double LateralSurfaceArea()
        {
            //2lh + 2wh
            double lateralSurfaceArea = 2 * this.length * this.height + 2 * this.width * this.height;

            return lateralSurfaceArea;
        }

        public double Volume()
        {
            double volume = this.length * this.height * this.width;

            return volume;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());

            try
            {
                var box = new Box(length, width, height);

                Console.WriteLine("Surface Area - {0:F2}", box.SurfaceArea());
                Console.WriteLine("Lateral Surface Area - {0:F2}", box.LateralSurfaceArea());
                Console.WriteLine("Volume - {0:F2}", box.Volume());
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
            }
        }
    }
}
