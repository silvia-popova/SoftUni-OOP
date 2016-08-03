namespace BoatRacingSimulator.Models.Botes
{
    using System;
    using BoatRacingSimulator.Interfaces;

    public class PowerBoat : Boat
    {
        private IBoatEngine firstBoatEngine;
        private IBoatEngine secondBoatEngine;

        public PowerBoat(string model, int weight, IBoatEngine firstBoatEngine, IBoatEngine secondBoatEngine) 
            : base(model, weight)
        {
            this.FirstBoatEngine = firstBoatEngine;
            this.secondBoatEngine = secondBoatEngine;
        }

        public IBoatEngine FirstBoatEngine
        {
            get
            {
                return this.firstBoatEngine;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                this.firstBoatEngine = value;
            }
        }

        public IBoatEngine SecondBoatEngine
        {
            get
            {
                return this.secondBoatEngine;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                this.secondBoatEngine = value;
            }
        }

        public override double CalculateRaceTime(IRace race)
        {
            double speed = (this.FirstBoatEngine.Output + this.SecondBoatEngine.Output)
                    - this.Weight + (race.OceanCurrentSpeed / 5d);

            return race.Distance / speed;
        }
    }
}
