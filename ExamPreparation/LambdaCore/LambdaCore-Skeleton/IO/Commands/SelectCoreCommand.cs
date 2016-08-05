namespace LambdaCore.IO.Commands
{
    using System;
    using LambdaCore.Contracts;

    public class SelectCoreCommand : Command
    {
        public SelectCoreCommand(IPowerPlant powerPlant) 
            : base(powerPlant)
        {
        }

        public override string Execute(string[] inputData)
        {
            char name = inputData[1][1];

            if (inputData.Length != 2)
            {
                throw new ArgumentException($"Failed to select Core {name}!");
            }

            var core = this.PowerPlant.FindCoreByName(name);

            if (core == null)
            {
                throw new ArgumentException($"Failed to select Core {name}!");
            }

            this.PowerPlant.CurrentCore = core;

            var output = $"Currently selected Core {name}!";

            return output;
        }
    }
}
