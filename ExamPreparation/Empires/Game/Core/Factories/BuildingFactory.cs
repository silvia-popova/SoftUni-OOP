using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces;
using Game.Models;

namespace Game.Core.Factories
{
    public class BuildingFactory : IBuildingFactory
    {
        public BuildingFactory()
        {
        }

        public IBuilding ProduceBilding(string name)
        {
            switch (name)
            {
                case "barracks":
                    return new Barracks();
                case "archery":
                    return new Archery();
                default:
                    throw new ArgumentException("Unknown type of builting");
                    break;
            }
        }
    }
}
