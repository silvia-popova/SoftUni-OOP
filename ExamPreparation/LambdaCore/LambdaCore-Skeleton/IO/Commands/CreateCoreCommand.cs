namespace LambdaCore.IO.Commands
{
    using System;
    using System.Linq;
    using System.Reflection;
    using LambdaCore.Contracts;

    public class CreateCoreCommand : Command
    {
        private const string CoreSuffix = "Core";

        public CreateCoreCommand(IPowerPlant powerPlant) 
            : base(powerPlant)
        {
        }

        public override string Execute(string[] inputData)
        {
            string[] commandParams = inputData[1].Split(new [] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            string coreType = commandParams[0];
            int durability = int.Parse(commandParams[1]);

            char name = (char)(this.PowerPlant.CoresCount + 'A');

            var type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name == coreType + CoreSuffix);

            if (type == null)
            {
                throw new ArgumentException(Messages.FailedToCreateCoreMessage);
            }

            ICore core = (ICore)Activator.CreateInstance(type, name, durability);

            if (core == null)
            {
                throw new ArgumentException(Messages.FailedToCreateCoreMessage);
            }

            this.PowerPlant.Add(core);
            this.PowerPlant.AddCore(core);
            var output = string.Format(Messages.CreateCoreSuccessMessage, core.Name);

            return output;
        }
    }
}
