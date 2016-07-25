using System;
using System.Collections.Generic;

namespace Problem9.TrafficLights
{
    public enum TraficLight
    {
        Red = 0,
        Green = 1,
        Yellow = 2
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            List<TraficLight> lights = new List<TraficLight>();

            foreach (var str in input)
            {
                var light = (TraficLight)Enum.Parse(typeof(TraficLight), str);
                lights.Add(light);
            }

            var lightsType = Enum.GetValues(typeof(TraficLight));
            int length = lightsType.Length;

            int n = int.Parse(Console.ReadLine());

            List<TraficLight> allLights = new List<TraficLight>();

            foreach (TraficLight light in lightsType)
            {
                allLights.Add(light);
            }

            for (int i = 1; i <= n; i++)
            {
                foreach (var light in lights)
                {
                    Console.Write($"{allLights[((int)light + i) % length]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
