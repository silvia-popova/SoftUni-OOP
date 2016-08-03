namespace LambdaCore.Models.Fragments
{
    using LambdaCore.Contracts;
    using LambdaCore.Enums;

    public class NuclearFragment : Fragment
    {
        public NuclearFragment(FragmentType type, string name, int pressureAffection) 
            : base(type, name, pressureAffection * 2)
        {
        }

        public override void ChangePressure(ICore core)
        {
            core.Pressure += this.PressureAffection;
        }
    }
}
