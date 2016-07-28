﻿namespace _03BarracksFactory.Core.Commands
{
    using System;
    using _03BarracksFactory.Contracts;

    public class FightCommand : Command
    {
        public FightCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override void Execute()
        {
            Environment.Exit(0);
        }
    }
}
