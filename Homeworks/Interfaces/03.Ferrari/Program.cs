using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Ferrari
{
    public interface ICar
    {
        string Model { get; set; }

        string DriversName { get; set; }

        string PushBrakes();

        string PushGasPedal();
    }

    public class Ferrari : ICar
    {
        private const string FerraeiModel = "488-Spider";

        public Ferrari(string driversName)
        {
            this.Model = FerraeiModel;
            this.DriversName = driversName;
        }

        public string Model { get; set; }

        public string DriversName { get; set; }

        public string PushBrakes()
        {
            return "Brakes!";
        }

        public string PushGasPedal()
        {
            return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.PushBrakes()}/{this.PushGasPedal()}/{this.DriversName}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            while (name != string.Empty)
            {
                var ferrari = new Ferrari(name);

                Console.WriteLine(ferrari.ToString());

                name = Console.ReadLine();
            }

            string ferrariName = typeof(Ferrari).Name;
            string iCarInterfaceName = typeof(ICar).Name;

            bool isCreated = typeof(ICar).IsInterface;
            if (!isCreated)
            {
                throw new Exception("No interface ICar was created");
            }
        }
    }
}
