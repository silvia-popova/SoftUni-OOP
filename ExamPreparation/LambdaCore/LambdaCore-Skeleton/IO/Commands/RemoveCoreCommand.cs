namespace LambdaCore.IO.Commands
{
    using System;
    using LambdaCore.Contracts;

    public class RemoveCoreCommand : Command
    {
        public RemoveCoreCommand(IPowerPlant powerPlant) 
            : base(powerPlant)
        {
        }

        public override string Execute(string[] inputData)
        {
            char name = inputData[1][1];

            var core = this.PowerPlant.FindCoreByName(name);

            if (core == null)
            {
                throw new ArgumentNullException($"Failed to remove Core {name}!");
            }

            this.PowerPlant.RemoveCore(name);
            this.PowerPlant.Remove(core);

            var output = $"Successfully removed Core {name}!";

            return output;
        }
    }
}
