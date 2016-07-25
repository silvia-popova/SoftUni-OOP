using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces;

namespace Game.Core
{
    public class EmpiresData
    {
        private readonly IList<IBuilding> buildings;

        public EmpiresData()
        {
            this.buildings = new List<IBuilding>();
            this.Units = new Dictionary<string, int>();
            this.Resourses = new Dictionary<ResourseType, int>();
            this.InitResources();
        }

        private void InitResources()
        {
            var types = Enum.GetValues(typeof (ResourseType));

            foreach (ResourseType type in types)
            {
                this.Resourses.Add(type, 0);
            }
        }

        public IList<IBuilding> Buildings
        {
            get
            {
                return this.buildings;
            }
        }

        public IDictionary<string, int> Units { get; }

        public IDictionary<ResourseType, int> Resourses { get; }

        public void AddToResourses(IResourse resourse)
        {
            this.Resourses[resourse.ResourseType] += resourse.Quantity;
        }

        public void AddToUnits(string unitType)
        {
            if (!this.Units.ContainsKey(unitType))
            {
                this.Units.Add(unitType, 0);
            }

            this.Units[unitType]++;
        }
    }
}
