namespace LambdaCore.Models.Fragments
{
    using LambdaCore.Contracts;
    using LambdaCore.Enums;

    public interface IFragment
    {
        string Name { get; }

        int PressureAffection { get; }

        FragmentType Type { get; }

        void ChangePressure(ICore core);
    }
}