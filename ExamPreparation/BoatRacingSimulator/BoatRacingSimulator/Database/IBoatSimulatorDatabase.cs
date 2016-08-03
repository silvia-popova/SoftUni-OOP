using BoatRacingSimulator.Interfaces;

namespace BoatRacingSimulator.Database
{
    public interface IBoatSimulatorDatabase
    {
        IRepository<IBoat> Boats { get; }

        IRepository<IBoatEngine> BoteEngines { get; }
    }
}