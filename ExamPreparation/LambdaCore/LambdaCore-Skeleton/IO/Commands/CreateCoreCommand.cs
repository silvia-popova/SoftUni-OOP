namespace LambdaCore.IO.Commands
{
    using System;
    using LambdaCore.Contracts;
    using LambdaCore.Models.Cores;

    public class CreateCoreCommand : Command
    {
        public CreateCoreCommand(IEngine engine) : base(engine)
        {
        }

        public override void Execute(string[] inputData)
        {
            string[] commandParams = inputData[1].Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            string type = commandParams[0];
            int durability = int.Parse(commandParams[1]);

            ICore core = null;

            switch (type)
            {
                case "System":
                    char name = (char)(this.Engine.PowerPlant.CoresCount + 'A');
                    core = new SystemCore(name, durability);
                    break;
                case "Para":
                    name = (char)(this.Engine.PowerPlant.CoresCount + 'A');
                    core = new ParaCore((char)(this.Engine.PowerPlant.CoresCount + 'A'), durability);
                    break;
                default:
                    throw new ArgumentException("Failed to create Core!");
            }

            this.Engine.PowerPlant.Add(core);
            this.Engine.PowerPlant.AddCore(core);
            this.Engine.Writer.WriteLine($"Successfully created Core {core.Name}!");
        }
    }
}
