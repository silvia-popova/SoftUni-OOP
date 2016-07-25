using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces;
using Game.Models;

namespace Game.Core.Factories
{
    public class UnitFactory : IUnitFactory
    {
        public UnitFactory()
        {
        }

        public IUnit ProduceUnit(string name)
        {
            switch (name)
            {
                case "archer":
                    return new Archer();
                case "swordsman":
                    return new Swordsman();
                default:
                    throw new ArgumentException("Unknown type of unit");
                    break;
            }
        }
    }
}
