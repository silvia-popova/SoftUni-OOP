using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BeerCounter
{
    public static class BeerCounter
    {
        public static int beersDrankCount;
        public static int beerInStock;


        public static void BuyBeer(int bottles)
        {
            beerInStock += bottles;
        }

        public static void DrinkBeer(int bottles)
        {
            beersDrankCount += bottles;
            beerInStock -= bottles;
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
                int bought = int.Parse(tokens[0]);
                int drank = int.Parse(tokens[1]);

                BeerCounter.BuyBeer(bought);
                BeerCounter.DrinkBeer(drank);

                input = Console.ReadLine();
            }

            Console.WriteLine("{0} {1}", BeerCounter.beerInStock, BeerCounter.beersDrankCount);
        }
    }
}
