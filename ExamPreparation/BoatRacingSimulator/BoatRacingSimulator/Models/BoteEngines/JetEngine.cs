namespace BoatRacingSimulator.Models.BoteEngines
{
    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Utility;

    public class JetEngine : BoteEngine, IModelable
    {
        private const int Multiplier = 5;

        private int horsepower;

        private int displacement;

        public JetEngine(string model, int horsepower, int displacement)
            : base(model)
        {
            this.Horsepower = horsepower;
            this.Displacement = displacement;
        }

        public override int Output
        {
            get
            {
                if (this.CachedOutput != 0)
                {
                    return this.CachedOutput;
                }

                this.CachedOutput = (this.Horsepower * Multiplier) + this.Displacement;

                return this.CachedOutput;
            }
        }

        protected int CachedOutput { get; set; }

        protected int Horsepower
        {
            get
            {
                return this.horsepower;
            }

            set
            {
                Validator.ValidatePropertyValue(value, "Horsepower");
                this.horsepower = value;
            }
        }

        protected int Displacement
        {
            get
            {
                return this.displacement;
            }

            set
            {
                Validator.ValidatePropertyValue(value, "Displacement");
                this.displacement = value;
            }
        }
    }
}