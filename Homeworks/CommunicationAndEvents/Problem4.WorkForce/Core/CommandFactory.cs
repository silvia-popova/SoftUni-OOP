namespace Problem4.WorkForce.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Problem4.WorkForce.Contracts;

    public class CommandFactory : ICommandFactory
    {
        public ICommand CreateCommand(string commandName, IData data)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name == commandName);

            if (type == null)
            {
                throw new ArgumentNullException();
            }

            var command = (ICommand)Activator.CreateInstance(type, data);

            return command;
        }
    }
}
