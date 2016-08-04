namespace LambdaCore.IO.Commands
{
    using LambdaCore.Contracts;

    public class SelectCoreCommand : Command
    {
        public SelectCoreCommand(IEngine engine) : base(engine)
        {
        }

        public override void Execute(string[] inputData)
        {
            char name = inputData[1][1];

            var core = this.Engine.PowerPlant.FindCoreByName(name);

            this.Engine.PowerPlant.CurrentCore = core;

            this.Engine.Writer.WriteLine($"Currently selected Core {name}!");
        }
    }
}
