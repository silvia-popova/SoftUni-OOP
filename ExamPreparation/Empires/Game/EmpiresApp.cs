using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Core;
using Game.Core.Factories;
using Game.IO;

namespace Game
{
    class EmpiresApp
    {
        static void Main(string[] args)
        {
            var buildingFactory = new BuildingFactory();
            var unitFactory = new UnitFactory();
            var resourceFactory = new ResourceFactory();
            var reader = new ConsoleInputHandler();
            var writer = new ConsoleWritter();
            var data = new EmpiresData();

            var engine = new Engine(buildingFactory, resourceFactory, unitFactory, data, reader, writer);
            engine.Run();
        }
    }
}
