namespace LambdaCore.IO
{
    using System;
    using LambdaCore.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IEngine engine;
        private ICommandFactory commandFactory;

        public CommandInterpreter(ICommandFactory commandFactory)
        {
            this.CommandFactory = commandFactory;
        }

        public ICommandFactory CommandFactory { get; private set; }

        public IEngine Engine { get; set; }

        public void InterpretCommand(string input)
        {
            string[] data = input.Split(':');
            string commandName = data[0].ToLower();

            try
            {
                ICommand command = this.ParseCommand(commandName);
                command.Execute(data);
            }
            catch (Exception ex)
            {
                this.Engine.Writer.WriteLine(ex.Message);
            }
        }

        private ICommand ParseCommand(string commandName)
        {
            return this.CommandFactory.CreateCommand(commandName, this.Engine);
        }
    }
}
