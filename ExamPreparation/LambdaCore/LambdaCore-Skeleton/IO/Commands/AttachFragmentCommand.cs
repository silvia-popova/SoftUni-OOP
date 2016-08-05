namespace LambdaCore.IO.Commands
{
    using System;
    using System.Linq;
    using System.Reflection;
    using LambdaCore.Contracts;
    using LambdaCore.Exceptions;
    using LambdaCore.Models.Fragments;

    public class AttachFragmentCommand : Command
    {
        private const string FragmentSuffix = "Fragment";

        public AttachFragmentCommand(IPowerPlant powerPlant) 
            : base(powerPlant)
        {
        }

        public override string Execute(string[] inputData)
        {
            string[] commandParams = inputData[1].Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            string fragmentType = commandParams[0];
            string name = commandParams[1];
            int pressureAffection = int.Parse(commandParams[2]);

            var type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name == fragmentType + FragmentSuffix);

            if (type == null)
            {
                throw new ArgumentException(string.Format(Messages.AttachFradmentFailed, name));
            }

            var fragment = (IFragment)Activator.CreateInstance(type, name, pressureAffection);

            if (fragment == null)
            {
                throw new ArgumentException(string.Format(Messages.AttachFradmentFailed, name));
            }

            if (!this.PowerPlant.IsCurrentCoreSelected)
            {
                throw new ArgumentException(string.Format(Messages.AttachFradmentFailed, name));
            }

            this.PowerPlant.CurrentCore.AddFragment(fragment);

            var output = string.Format(Messages.AttachFragmentSuccess, name, this.PowerPlant.CurrentCore.Name);

            return output;
        }
    }
}
