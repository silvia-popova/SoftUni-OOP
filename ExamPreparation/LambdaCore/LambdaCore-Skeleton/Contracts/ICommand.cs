namespace LambdaCore.Contracts
{
    public interface ICommand
    {
        void Execute(string[] inputData);
    }
}