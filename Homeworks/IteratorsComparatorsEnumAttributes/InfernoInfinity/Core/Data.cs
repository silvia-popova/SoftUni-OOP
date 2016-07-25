namespace InfernoInfinity.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class Data : IData
    {
        private List<IWeapon> weapons;

        public Data()
        {
            weapons= new List<IWeapon>();
        }

        public void AddWeapon(IWeapon weapon)
        {
            if (weapon == null)
            {
                throw new ArgumentNullException(nameof(weapon), "Weapon cannot be null");
            }

            this.weapons.Add(weapon);
        }

        public IWeapon FindWeaponByName(string weaponName)
        {
            if (weaponName == null)
            {
                throw new ArgumentNullException(nameof(weaponName), "WeaponName cannot be null");
            }

            var weapon = weapons.FirstOrDefault(w => w.Name == weaponName);

            return weapon;
        }
    }
}
