using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces;

namespace Game.Models
{
    public abstract class Building : IBuilding
    {
        private int turnsCount;

        protected Building()
        {
            this.turnsCount = -1;
        }

        public abstract bool CanProduceUnit { get; }

        public abstract bool CanProduceResourse { get; }

        public int TurnsCount => this.turnsCount;

        public void Update()
        {
            this.turnsCount++;
        }
    }
}
