namespace LambdaCore.Contracts
{
    public interface ICommand
    {
        string Execute(string[] inputData);
    }
}