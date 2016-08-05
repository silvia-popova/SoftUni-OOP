namespace LambdaCore.IO.Commands
{
    using System;
    using LambdaCore.Contracts;
    using LambdaCore.Exceptions;

    public class DetachFragmentCommand : Command
    {
        public DetachFragmentCommand(IPowerPlant powerPlant) 
            : base(powerPlant)
        {
        }

        public override string Execute(string[] inputData)
        {
            if (!this.PowerPlant.IsCurrentCoreSelected)
            {
                throw new CurrentCoreNotSetException("Failed to detach Fragment!");
            }

            var fragment = this.PowerPlant.CurrentCore.RemoveFragment();

            var output = $"Successfully detached Fragment {fragment.Name} from Core {this.PowerPlant.CurrentCore.Name}!";

            return output;
        }
    }
}
