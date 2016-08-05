namespace LambdaCore.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using LambdaCore.Contracts;
    using LambdaCore.Exceptions;

    public class CommandFactory : ICommandFactory
    {
        public ICommand CreateCommand(string commandName, IPowerPlant powerPlant)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name == commandName);

            if (type == null)
            {
                throw new UnknownCommandException();
            }

            var command = (ICommand)Activator.CreateInstance(type, powerPlant);

            return command;
        }
    }
}
