namespace LambdaCore.IO
{
    using LambdaCore.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandSuffix = "Command";

        public CommandInterpreter(ICommandFactory commandFactory, IPowerPlant powerPlant)
        {
            this.CommandFactory = commandFactory;
            this.PowerPlant = powerPlant;
        }

        public ICommandFactory CommandFactory { get; private set; }

        public IPowerPlant PowerPlant { get; private set; }

        public string InterpretCommand(string input)
        {
            string[] data = input.Split(':');
            string commandName = data[0];

            ICommand command = this.ParseCommand(commandName + CommandSuffix);
            var output = command.Execute(data);

            return output;
        }

        private ICommand ParseCommand(string commandName)
        {
            return this.CommandFactory.CreateCommand(commandName, this.PowerPlant);
        }
    }
}
