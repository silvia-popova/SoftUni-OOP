namespace LambdaCore.IO.Commands
{
    using LambdaCore.Contracts;

    public class RemoveCoreCommand : Command
    {
        public RemoveCoreCommand(IEngine engine) : base(engine)
        {
        }

        public override void Execute(string[] inputData)
        {
            char name = inputData[1][1];

            var core = this.Engine.PowerPlant.FindCoreByName(name);

            if (core == null)
            {
                this.Engine.Writer.WriteLine($"Failed to remove Core {name}!");
            }

            this.Engine.PowerPlant.RemoveCore(name);
            this.Engine.PowerPlant.Remove(core);

            this.Engine.Writer.WriteLine($"Successfully removed Core {name}!");
        }
    }
}
