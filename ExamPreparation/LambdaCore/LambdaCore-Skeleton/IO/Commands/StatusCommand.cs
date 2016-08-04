namespace LambdaCore.IO.Commands
{
    using LambdaCore.Contracts;

    public class StatusCommand : Command
    {
        public StatusCommand(IEngine engine) : base(engine)
        {
        }

        public override void Execute(string[] inputData)
        {
            this.Engine.Writer.WriteLine(this.Engine.PowerPlant.ToString());
        }
    }
}
