namespace InfernoInfinity.Contracts
{
    public interface IWeapon
    {
        string Name { get; }

        void AddGem(IGem gem, int index);

        void RemoveGem(int index);

        void CalculateStates();
    }
}
