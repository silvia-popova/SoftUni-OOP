namespace Problem4.WorkForce.IO
{
    using Problem4.WorkForce.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandSuffix = "Command";

        public CommandInterpreter(ICommandFactory commandFactory, IData data)
        {
            this.CommandFactory = commandFactory;
            this.Data = data;
        }

        public ICommandFactory CommandFactory { get; private set; }

        public IData Data { get; private set; }

        public string InterpretCommand(string input)
        {
            string[] data = input.Split(' ');
            string commandName = data[0];

            ICommand command = this.ParseCommand(commandName + CommandSuffix);
            var output = command.Execute(data);

            return output;
        }

        private ICommand ParseCommand(string commandName)
        {
            return this.CommandFactory.CreateCommand(commandName, this.Data);
        }
    }
}
