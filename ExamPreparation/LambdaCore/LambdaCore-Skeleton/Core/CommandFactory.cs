namespace LambdaCore.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using LambdaCore.Contracts;

    public class CommandFactory : ICommandFactory
    {
        public ICommand CreateCommand(string commandName, IEngine engine)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name == commandName + "Command");

            if (type == null)
            {
                throw new ArgumentException("Unknown command.");
            }

            var command = (ICommand)Activator.CreateInstance(type, engine);

            return command;
        }
    }
}
