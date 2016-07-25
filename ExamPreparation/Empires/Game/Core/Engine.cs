using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces;
using Game.IO;
using Game.Models;

namespace Game.Core
{
    public class Engine : IEngine
    {
        private readonly IBuildingFactory buildingFactory;
        private readonly IResourseFactory resourceFactory;
        private readonly IUnitFactory unitFactory;
        private readonly EmpiresData data;
        private readonly IInputReader reader;
        private readonly IOutputWritter writer;

        public Engine(
            IBuildingFactory buildingFactory,
            IResourseFactory resourceFactory,
            IUnitFactory unitFactory,
            EmpiresData data,
            IInputReader reader,
            IOutputWritter writer)
        {
            this.buildingFactory = buildingFactory;
            this.resourceFactory = resourceFactory;
            this.unitFactory = unitFactory;
            this.data = data;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                var input = this.reader.ReadLine().Split();

                this.ExecuteCommand(input);

                foreach (var building in this.data.Buildings)
                {
                   building.Update();

                    if (building.CanProduceUnit)
                    {
                        var buildingType = building.GetType().Name;
                        switch (buildingType)
                        {
                            case "Barracks":
                                var unit = this.unitFactory.ProduceUnit("swordsman");
                                this.data.AddToUnits("Swordsman");
                                break;
                            case "Archery":
                                unit = this.unitFactory.ProduceUnit("archer");
                                this.data.AddToUnits("Archer");
                                break;
                        } 
                    }

                    if (building.CanProduceResourse)
                    {
                        var buildingType = building.GetType().Name;
                        switch (buildingType)
                        {
                            case "Barracks":
                                var resource = this.resourceFactory.ProduceResorse("Steel", 10);
                                this.data.AddToResourses(resource);
                                break;
                            case "Archery":
                                resource = this.resourceFactory.ProduceResorse("Gold", 5);
                                this.data.AddToResourses(resource);
                                break;
                        }
                    }
                }
            }
        }

        public void ExecuteCommand(string[] commandArgs)
        {
            switch (commandArgs[0])
            {
                case "build":
                    var building = ExecuteBuildCommand(commandArgs[1]);
                    this.data.Buildings.Add(building);
                    break;
                case "skip":
                    break;
                case "empire-status":
                    ExecutePrintCommand();
                    break;
                case "armistice":
                    Environment.Exit(0);
                    break;
                default:
                    throw new ArgumentException("Unknown command");
                    break;
            }
        }

        private void ExecutePrintCommand()
        {
            var result = new StringBuilder();

            result.AppendLine("Treasury:");
            foreach (var resource in data.Resourses)
            {
                result.AppendLine($"--{resource.Key}: {resource.Value}");
            }
            result.AppendLine("Buildings:");

            if (this.data.Buildings.Count == 0)
            {
                result.AppendLine("N/A");
            }
            else
            {
                foreach (var building in this.data.Buildings)
                {
                    result.AppendLine(building.ToString());
                }
            }

            result.AppendLine("Units:");

            if (this.data.Units.Count == 0)
            {
                result.AppendLine("N/A");
            }
            else
            {
                foreach (var unit in this.data.Units)
                {
                    result.AppendLine($"--{unit.Key}: {unit.Value}");
                }
            }

            this.writer.WriteLine(result.ToString().Trim());
        }

        private IBuilding ExecuteBuildCommand(string bildingType)
        {
            return this.buildingFactory.ProduceBilding(bildingType);
        }
    }
}
