namespace LambdaCore.Models.Fragments
{
    using LambdaCore.Contracts;
    using LambdaCore.Enums;

    public class CoolingFragment : Fragment
    {
        public CoolingFragment(FragmentType type, string name, int pressureAffection) 
            : base(type, name, pressureAffection * 3)
        {
        }

        public override void ChangePressure(ICore core)
        {
            core.Pressure -= this.PressureAffection;
        }
    }
}
