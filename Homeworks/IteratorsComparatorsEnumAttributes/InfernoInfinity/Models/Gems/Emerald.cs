namespace InfernoInfinity.Models.Gems
{
    using Enums;

    public class Emerald : Gem
    {
        private const int Strength = 1;
        private const int Agility = 4;
        private const int Vitality = 9;

        public Emerald(Clarity clarity) 
            : base(Strength, Agility, Vitality, clarity)
        {
        }
    }
}
