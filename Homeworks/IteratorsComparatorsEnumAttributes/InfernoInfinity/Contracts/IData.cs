namespace InfernoInfinity.Contracts
{
    public interface IData
    {
        void AddWeapon(IWeapon weapon);

        IWeapon FindWeaponByName(string weaponName);
    }
}
