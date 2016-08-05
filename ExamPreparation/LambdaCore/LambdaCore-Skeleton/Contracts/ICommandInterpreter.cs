namespace LambdaCore.Contracts
{
    public interface ICommandInterpreter
    {
        IPowerPlant PowerPlant { get; }

        string InterpretCommand(string input);
    }
}