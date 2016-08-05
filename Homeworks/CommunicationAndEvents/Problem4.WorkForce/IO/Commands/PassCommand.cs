namespace Problem4.WorkForce.IO.Commands
{
    using Problem4.WorkForce.Contracts;

    public class PassCommand : Command
    {
        public PassCommand(IData data) : base(data)
        {
        }

        public override string Execute(string[] inputData)
        {
            for (int i = this.Data.Jobs.Count - 1; i >= 0; i--)
            {
                this.Data.Jobs[i].Update();
            }

            return null;
        }
    }
}
