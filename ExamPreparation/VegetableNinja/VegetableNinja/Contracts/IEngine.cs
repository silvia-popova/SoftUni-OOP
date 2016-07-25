namespace VegetableNinja.Contracts
{
    public interface IEngine
    {
        void Start();

        void Stop();

        IUnitContainer UnitContainer { get; }

        IOutputWriter OutputWriter { get; }
    }
}
