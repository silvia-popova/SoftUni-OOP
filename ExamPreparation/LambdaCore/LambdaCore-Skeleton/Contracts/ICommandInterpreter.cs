namespace LambdaCore.Contracts
{
    public interface ICommandInterpreter
    {
        IEngine Engine { get; set; }

        void InterpretCommand(string input);
    }
}