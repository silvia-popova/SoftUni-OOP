namespace InfernoInfinity.Models.Weapons
{
    using Enums;

    public class Axe : Weapon
    {
        public const int DefaultMinDamage = 5;
        public const int DefaultMaxDamage = 10;
        public const int DefaultNumberOfSockets = 4;

        public Axe(string name, Rarity rarity) 
            : base(DefaultMinDamage, DefaultMaxDamage, DefaultNumberOfSockets, name, rarity)
        {
        }
    }
}
