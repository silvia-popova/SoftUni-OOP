namespace BoatRacingSimulator.Models.Botes
{
    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Utility;

    public class Yacht : Boat
    {
        private int cargoWeight;
        private IBoatEngine boatEngine;

        public Yacht(string model, int weight, IBoatEngine boatEngine, int cargoWeight) 
            : base(model, weight)
        {
            this.CargoWeight = cargoWeight;
            this.boatEngine = boatEngine;
        }

        public int CargoWeight
        {
            get
            {
                return this.cargoWeight;
            }

            private set
            {
                Validator.ValidatePropertyValue(value, "Cargo Weight");
                this.cargoWeight = value;
            }
        }

        public override double CalculateRaceTime(IRace race)
        {
            double speed = this.boatEngine.Output - this.Weight - this.CargoWeight + (race.OceanCurrentSpeed / 2d);

            return race.Distance / speed;
        }
    }
}
