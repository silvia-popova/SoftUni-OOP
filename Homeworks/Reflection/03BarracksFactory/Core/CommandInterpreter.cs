namespace _03BarracksFactory.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using _03BarracksFactory.Contracts;


    public class CommandInterpreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public void InterpretCommand(string[] data)
        {
            string commandName = data[0] + "command";

            try
            {
                IExecutable command = this.ParseCommand(commandName, data);
                command.Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private IExecutable ParseCommand(string commandName, string[] data)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == commandName);

            if (type == null)
            {
                throw new ArgumentException("Invalid command!");
            }

            var command = (IExecutable)Activator.CreateInstance(type, data, this.repository, this.unitFactory);

            return command;
        }
    }
}
