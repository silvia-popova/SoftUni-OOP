namespace LambdaCore.IO.Commands
{
    using LambdaCore.Contracts;

    public class DetachFragmentCommand : Command
    {
        public DetachFragmentCommand(IEngine engine) : base(engine)
        {
        }

        public override void Execute(string[] inputData)
        {
            if (!this.Engine.PowerPlant.IsCurrentCoreSelected)
            {
                this.Engine.Writer.WriteLine("Failed to detach Fragment!");
            }

            var fragment = this.Engine.PowerPlant.CurrentCore.RemoveFragment();

            this.Engine.Writer.WriteLine($"Successfully detached Fragment {fragment.Name} from Core {this.Engine.PowerPlant.CurrentCore.Name}!");
        }
    }
}
