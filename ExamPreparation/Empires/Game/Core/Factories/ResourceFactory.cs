using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces;
using Game.Models;

namespace Game.Core.Factories
{
    public class ResourceFactory : IResourseFactory
    {
        public ResourceFactory()
        {
        }

        public IResourse ProduceResorse(string name, int quantity)
        {
            return new Resourse(quantity, (ResourseType)Enum.Parse(typeof(ResourseType), name));
        }
    }
}
