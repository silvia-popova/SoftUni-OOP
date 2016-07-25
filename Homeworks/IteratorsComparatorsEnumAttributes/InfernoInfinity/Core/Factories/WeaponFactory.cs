namespace InfernoInfinity.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Enums;

    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon CreateWeapon(string weaponName, string weaponType, string weaponRarity)
        {

            var type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name == weaponType);

            if (type == null)
            {
                throw new ArgumentException("Unknown weapon type.");
            }

            Rarity rarity = (Rarity) Enum.Parse(typeof (Rarity), weaponRarity);

            var weapon = (IWeapon)Activator.CreateInstance(type, weaponName, rarity);

            return weapon;
        }
    }
}
