namespace Problem4.WorkForce.Contracts
{
    public interface ICommand
    {
        string Execute(string[] inputData);
    }
}