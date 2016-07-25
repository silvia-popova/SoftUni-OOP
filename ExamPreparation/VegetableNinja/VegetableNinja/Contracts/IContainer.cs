namespace VegetableNinja.Contracts
{
    public interface IUnitContainer
    {
        void Add(IGameObject gameObject);

        void Remove(IGameObject gameObject);

        void Move(IGameObject gameObject, int newX, int newY);

        IGameObject CheckForOtherGameObject(int newX, int newY);

        bool IsOutsideTheMatrix(int x, int y);
    }
}
