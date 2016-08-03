namespace BoatRacingSimulator.Models.Botes
{
    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Utility;

    public class RowBoat : Boat
    {
        private int oars;

        public RowBoat(string model, int weight, int oars) 
            : base(model, weight)
        {
            this.Oars = oars;
        }

        public int Oars
        {
            get
            {
                return this.oars;
            }

            private set
            {
                Validator.ValidatePropertyValue(value, "Oars");
                this.oars = value;
            }
        }

        public override double CalculateRaceTime(IRace race)
        {
            double speed = (this.Oars * 100) - this.Weight + race.OceanCurrentSpeed;

            return race.Distance / speed;
        }
    }
}
