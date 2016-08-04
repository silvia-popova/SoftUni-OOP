namespace LambdaCore.Models.Fragments
{
    using LambdaCore.Contracts;
    using LambdaCore.Enums;

    public class CoolingFragment : Fragment
    {
        public CoolingFragment(string name, int pressureAffection) 
            : base(FragmentType.Cooling, name, pressureAffection * 3)
        {
        }

        public override void ChangePressure(ICore core)
        {
            core.Pressure -= base.PressureAffection;
        }
    }
}
