namespace _03BarracksFactory.Contracts
{
    public interface IRepository
    {
        string Statistics { get; }

        void AddUnit(string unitType);

        void RemoveUnit(string unitType);
    }
}
