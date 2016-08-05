namespace Problem4.WorkForce.Contracts
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandName, IData Data);
    }
}