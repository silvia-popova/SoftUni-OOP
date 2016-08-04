namespace LambdaCore.Models.Fragments
{
    using LambdaCore.Contracts;
    using LambdaCore.Enums;

    public class NuclearFragment : Fragment
    {
        public NuclearFragment(string name, int pressureAffection) 
            : base(FragmentType.Nuclear, name, pressureAffection * 2)
        {
        }

        public override void ChangePressure(ICore core)
        {
            core.TempPressure += base.PressureAffection;
        }
    }
}
