namespace InfernoInfinity.Contracts
{
    public interface IWeaponFactory
    {
        IWeapon CreateWeapon(string weaponName, string weaponType, string weaponRarity);
    }
}
