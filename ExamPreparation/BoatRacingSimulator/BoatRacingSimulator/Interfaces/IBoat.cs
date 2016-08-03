namespace BoatRacingSimulator.Interfaces
{
    public interface IBoat : IModelable
    {
        int Weight { get; }

        double CalculateRaceTime(IRace race);
    }
}