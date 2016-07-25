namespace InfernoInfinity.Models.Weapons
{
    using Enums;

    public class Knife : Weapon
    {
        public const int DefaultMinDamage = 3;
        public const int DefaultMaxDamage = 4;
        public const int DefaultNumberOfSockets = 2;

        public Knife(string name, Rarity rarity) 
            : base(DefaultMinDamage, DefaultMaxDamage, DefaultNumberOfSockets, name, rarity)
        {
        }
    }
}
