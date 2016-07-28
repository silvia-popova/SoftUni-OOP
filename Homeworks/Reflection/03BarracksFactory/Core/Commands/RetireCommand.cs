namespace _03BarracksFactory.Core.Commands
{
    using System;
    using _03BarracksFactory.Contracts;

    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override void Execute()
        {
            string unitType = this.Data[1];

            this.Repository.RemoveUnit(unitType);

            Console.WriteLine($"{unitType} retired!");
        }
    }
}
