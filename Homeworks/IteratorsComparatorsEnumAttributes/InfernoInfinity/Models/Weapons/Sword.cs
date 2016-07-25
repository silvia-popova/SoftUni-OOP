namespace InfernoInfinity.Models.Weapons
{
    using Enums;

    public class Sword : Weapon
    {
        public const int DefaultMinDamage = 4;
        public const int DefaultMaxDamage = 6;
        public const int DefaultNumberOfSockets = 3;

        public Sword(string name, Rarity rarity) 
            : base(DefaultMinDamage, DefaultMaxDamage, DefaultNumberOfSockets, name, rarity)
        {
        }
    }
}
