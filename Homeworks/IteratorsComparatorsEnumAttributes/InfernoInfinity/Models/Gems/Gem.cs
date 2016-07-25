namespace InfernoInfinity.Models.Gems
{
    using Enums;
    using Contracts;

    public abstract class Gem : IGem
    {
        private Clarity clarity;

        protected Gem(int strength, int agility, int vitality, Clarity clarity)
        {
            this.clarity = clarity;
            this.Strength = strength + (int)clarity;
            this.Agility = agility + (int)clarity;
            this.Vitality = vitality + (int)clarity;
        }

        public int Strength { get; private set; }

        public int Agility { get; private set; }

        public int Vitality { get; private set; }
    }
}
