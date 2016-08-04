namespace LambdaCore.IO.Commands
{
    using System;
    using System.Linq;
    using System.Reflection;
    using LambdaCore.Contracts;
    using LambdaCore.Models.Fragments;

    public class AttachFragmentCommand : Command
    {
        public AttachFragmentCommand(IEngine engine) : base(engine)
        {
        }

        public override void Execute(string[] inputData)
        {
            string[] commandParams = inputData[1].Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            string fragmentType = commandParams[0];
            string name = commandParams[1];
            int pressureAffection = int.Parse(commandParams[2]);

            var type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name == fragmentType + "Fragment");

            if (type == null)
            {
                throw new ArgumentException($"Failed to attach Fragment {name}!");
            }

            var fragment = (IFragment)Activator.CreateInstance(type, name, pressureAffection);

            if (!this.Engine.PowerPlant.IsCurrentCoreSelected)
            {
                throw new ArgumentException($"Failed to attach Fragment {name}!");
            }

            this.Engine.PowerPlant.CurrentCore.AddFragment(fragment);

            this.Engine.Writer.WriteLine($"Successfully attached Fragment {name} to Core {this.Engine.PowerPlant.CurrentCore.Name}!");
        }
    }
}
