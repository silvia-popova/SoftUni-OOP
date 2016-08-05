namespace LambdaCore.Contracts
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandName, IPowerPlant powerPlant);
    }
}