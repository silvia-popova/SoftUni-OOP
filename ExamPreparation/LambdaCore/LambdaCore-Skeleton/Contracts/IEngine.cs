namespace LambdaCore.Contracts
{
    public interface IEngine
    {
        IOutputWriter Writer { get; }

        IPowerPlant PowerPlant { get; }

        void Run();
    }
}