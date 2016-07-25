namespace VegetableNinja.Contracts
{
    public interface IGameObject
    {
        int X { get; set; }

        int Y { get; set; }

        string Name { get; }

        char Symbol { get; }
    }
}
