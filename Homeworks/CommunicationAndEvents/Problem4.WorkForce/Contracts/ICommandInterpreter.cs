namespace Problem4.WorkForce.Contracts
{
    public interface ICommandInterpreter
    {
        IData Data { get; }

        string InterpretCommand(string input);
    }
}