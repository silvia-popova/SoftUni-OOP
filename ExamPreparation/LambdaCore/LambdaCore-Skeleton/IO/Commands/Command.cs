namespace LambdaCore.IO.Commands
{
    using LambdaCore.Contracts;

    public abstract class Command : ICommand
    {
        protected Command(IPowerPlant powerPlant)
        {
            this.PowerPlant = powerPlant;
        }

        protected IPowerPlant PowerPlant { get; }

        public abstract string Execute(string[] inputData);
    }
}
