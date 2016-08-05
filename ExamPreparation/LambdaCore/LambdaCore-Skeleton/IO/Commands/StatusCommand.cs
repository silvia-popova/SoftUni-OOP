namespace LambdaCore.IO.Commands
{
    using LambdaCore.Contracts;

    public class StatusCommand : Command
    {
        public StatusCommand(IPowerPlant powerPlant) 
            : base(powerPlant)
        {
        }

        public override string Execute(string[] inputData)
        {
            var output = this.PowerPlant.ToString();

            return output;
        }
    }
}
