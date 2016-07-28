namespace _03BarracksFactory.Core.Commands
{
    using System;
    using System.Linq;
    using System.Reflection;
    using _03BarracksFactory.Contracts;

    public class AddCommand : Command
    {
        public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override void Execute()
        {
            string unitType = this.Data[1];

            this.Repository.AddUnit(unitType);

            Console.WriteLine($"{unitType} added!");
        }
    }
}

