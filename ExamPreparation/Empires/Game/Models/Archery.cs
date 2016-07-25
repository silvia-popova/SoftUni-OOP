using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models
{
    public class Archery : Building
    {
        //produces 5 gold (every 2 turns) and an archer (every 3 turns)
        private const int turnsNeededToGold = 2;
        private const int turnsNeededToArcher = 3;

        public Archery()
        {
        }

        public override bool CanProduceUnit
        {
            get
            {
                return this.TurnsCount != 0 && this.TurnsCount % turnsNeededToArcher == 0;
            }
        }

        public override bool CanProduceResourse
        {
            get
            {
                return this.TurnsCount != 0 && this.TurnsCount % turnsNeededToGold == 0;
            }
        }

        public override string ToString()
        {
            return string.Format("--Archery: {0} turns ({1} turns until Archer, {2} turns until Gold)",
                this.TurnsCount,
                turnsNeededToArcher - this.TurnsCount % turnsNeededToArcher,
                turnsNeededToGold - this.TurnsCount % turnsNeededToGold);
        }
    }
}

    