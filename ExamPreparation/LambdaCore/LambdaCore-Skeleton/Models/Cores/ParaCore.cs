namespace LambdaCore.Models.Cores
{
    using LambdaCore_Skeleton.Models.Cores;

    public class ParaCore : Core
    {
        public ParaCore(char name, int durability) : base(name, durability / 3)
        {
        }
    }
}
