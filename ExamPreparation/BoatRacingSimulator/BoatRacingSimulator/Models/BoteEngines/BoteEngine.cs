namespace BoatRacingSimulator.Models.BoteEngines
{
    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Utility;

    public abstract class BoteEngine : IBoatEngine
    {
        private string model;

        protected BoteEngine(string model)
        {
            this.Model = model;
        }

        public abstract int Output { get; }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                Validator.ValidateModelLength(value, Constants.MinBoatEngineModelLength);
                this.model = value;
            }
        }
    }
}
