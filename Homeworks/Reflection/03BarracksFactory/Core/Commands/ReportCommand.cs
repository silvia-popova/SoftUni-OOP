namespace _03BarracksFactory.Core.Commands
{
    using System;
    using System.Reflection;
    using _03BarracksFactory.Contracts;

    public class ReportCommand : Command
    {
        public ReportCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override void Execute()
        {
            Console.WriteLine(this.Repository.Statistics);
        }
    }
}
