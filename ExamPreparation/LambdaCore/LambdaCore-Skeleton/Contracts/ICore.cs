namespace LambdaCore.Contracts
{
    public interface ICore
    {
        int Durability { get; }

        char Name { get; }

        int Pressure { get; set; }
    }
}