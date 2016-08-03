namespace LambdaCore.Contracts
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string comandName, IEngine engine);
    }
}