namespace LambdaCore.Contracts
{
    using LambdaCore.Models.Fragments;

    public interface ICore
    {
        int CurrentDurability { get; set; }

        char Name { get; }

        int TempPressure { get; set; }

        string Status { get; set; }

        int CountOfFragments { get; }

        void AddFragment(IFragment fragment);

        IFragment RemoveFragment();
    }
}