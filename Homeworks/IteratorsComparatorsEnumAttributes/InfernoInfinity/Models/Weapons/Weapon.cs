namespace InfernoInfinity
{
    using Contracts;
    using Core;
    using Enums;

    [Weapon("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
    public abstract class Weapon : IWeapon
    {
        private const int PointOfStrengthToAddToMinDamage = 2;
        private const int PointOfStrengthToAddToMaxDamage = 3;
        private const int PointOfAgilityToAddToMaxDamage = 4;

        private int minDamage;
        private int maxDamage;
        private int strength;
        private int agility;
        private int vitality;
        private Rarity rariry;

        private readonly IGem[] gems;

        protected Weapon(int minDamage, int maxDamage, int sockets, string name, Rarity rarity)
        {
            this.rariry = rarity;
            this.minDamage = minDamage * (int)rariry;
            this.maxDamage = maxDamage * (int)rariry;
            this.gems = new IGem[sockets];
            this.Name = name;
        }

        public string Name { get; private set; }

        public void AddGem(IGem gem, int index)
        {
            if (index >= 0 && index < gems.Length)
            {
                gems[index] = gem;
            }
        }

        public void RemoveGem(int index)
        {
            if (index >= 0 && index < gems.Length)
            {
                gems[index] = null;
            }
        }

        public void CalculateStates()
        {
            foreach (var gem in this.gems)
            {
                if (gem != null)
                {
                    this.strength += gem.Strength;
                    this.agility += gem.Agility;
                    this.vitality += gem.Vitality;
                }
            }

            this.minDamage += this.strength * PointOfStrengthToAddToMinDamage;
            this.maxDamage += this.strength * PointOfStrengthToAddToMaxDamage;

            this.minDamage += this.agility;
            this.maxDamage += this.agility * PointOfAgilityToAddToMaxDamage;
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.minDamage}-{this.maxDamage} Damage, +{this.strength} Strength, " +
                   $"+{this.agility} Agility, +{this.vitality} Vitality";
        }
    }
}
