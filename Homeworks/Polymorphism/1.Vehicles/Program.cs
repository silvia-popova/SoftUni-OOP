using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace _1.Vehicles
{
    public class Vehicle
    {
        private double fuelQuantity;
        //private double fuelConsumptionLperKm;
        private double fuelConsumptionIncreaser;

        public Vehicle(double fuelQuantity, double fuelConsumptionLperKm, 
            double fuelConsumptionIncreaser, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionLperKm = fuelConsumptionLperKm;
            this.fuelConsumptionIncreaser = fuelConsumptionIncreaser;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity {
            get
            {
                return this.fuelQuantity;
            }

            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Fuel must be a positive number");
                    return;
                }

                this.fuelQuantity = value;
            }
        }

        public double FuelConsumptionLperKm { get; set; }

        public double TankCapacity { get; set; }

        public virtual void Refuel(double littres)
        {
            var availableSpace = this.TankCapacity - this.FuelQuantity;

            if (availableSpace < littres)
            {
                Console.WriteLine("Cannot fit fuel in tank");
                return;
            }

            this.FuelQuantity += littres;
        }

        public virtual string Drive(double distance)
        {
            var neededFuel = distance*this.FuelConsumptionLperKm + distance* this.fuelConsumptionIncreaser;

            if (neededFuel > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= neededFuel;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public string RemainingFuel()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }

    public class Car : Vehicle
    {
        private const double FuelConsumptionIncreaser = 0.9;

        public Car(double fuelQuantity, double fuelConsumptionLperKm, double tankCapacity) 
            : base(fuelQuantity, fuelConsumptionLperKm, FuelConsumptionIncreaser, tankCapacity)
        {
        }
    }

    public class Truck : Vehicle
    {
        private const double FuelConsumptionIncreaser = 1.6;

        public Truck(double fuelQuantity, double fuelConsumptionLperKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionLperKm, FuelConsumptionIncreaser, tankCapacity)
        {
        }

        public override void Refuel(double littres)
        {
            this.FuelQuantity += littres* 0.95;
        }
    }

    public class Bus : Vehicle
    {
        private const double FuelConsumptionIncreaser = 1.4;

        private bool airConditionerTurnedOn;

        public Bus(double fuelQuantity, double fuelConsumptionLperKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionLperKm, FuelConsumptionIncreaser, tankCapacity)
        {
        }

        public override string Drive(double distance)
        {
            if (airConditionerTurnedOn)
            {

                return base.Drive(distance);
            }

            var neededFuel = distance * this.FuelConsumptionLperKm;

            if (neededFuel > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= neededFuel;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public void TurnOffAirConditioner()
        {
            this.airConditionerTurnedOn = false;
        }

        public void TurnOnAirConditioner()
        {
            this.airConditionerTurnedOn = true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] tokensCar = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            double fuelQuantityCar = double.Parse(tokensCar[1]);
            double fuelConsumptionCar = double.Parse(tokensCar[2]);
            double tankCapacityCar = double.Parse(tokensCar[3]);

            var car = new Car(fuelQuantityCar, fuelConsumptionCar, tankCapacityCar);

            string[] tokensTruck = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            double fuelQuantityTruck = double.Parse(tokensTruck[1]);
            double fuelConsumptionTruck = double.Parse(tokensTruck[2]);
            double tankCapacityTrunk = double.Parse(tokensTruck[3]);

            var truck = new Truck(fuelQuantityTruck, fuelConsumptionTruck, tankCapacityTrunk);

            string[] tokensBus = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            double fuelQuantityBus = double.Parse(tokensBus[1]);
            double fuelConsumptionBus = double.Parse(tokensBus[2]);
            double tankCapacityBus = double.Parse(tokensBus[3]);

            var bus = new Bus(fuelQuantityBus, fuelConsumptionBus, tankCapacityBus);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                string vehicleType = tokens[1];
                double commandParameter = double.Parse(tokens[2]);

                switch (command)
                {
                    case "Drive":
                        if (vehicleType == "Car")
                        {
                            Console.WriteLine(car.Drive(commandParameter));
                        }
                        else if (vehicleType == "Truck")
                        {
                            Console.WriteLine(truck.Drive(commandParameter));
                        }
                        else
                        {
                            bus.TurnOnAirConditioner();
                            Console.WriteLine(bus.Drive(commandParameter));
                        }
                        break;
                    case "Refuel":
                        if (vehicleType == "Car")
                        {
                            car.Refuel(commandParameter);
                        }
                        else if (vehicleType == "Truck")
                        {
                            truck.Refuel(commandParameter);
                        }
                        else
                        {
                            bus.Refuel(commandParameter);
                        }
                        break;
                    default:
                        bus.TurnOffAirConditioner();
                        Console.WriteLine(bus.Drive(commandParameter));
                        break;
                }

            }

            Console.WriteLine(car.RemainingFuel());
            Console.WriteLine(truck.RemainingFuel());
            Console.WriteLine(bus.RemainingFuel());
        }
    }
}
