using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Models
{
    public class Barracks : Building
    {
        //produces 10 steel (every 3 turns) and a swordsman (every 4 turns)
        private const int turnsNeededToSteel = 3;
        private const int turnsNeededToSwordsman = 4;

        public Barracks()
        {
        }

        public override bool CanProduceUnit
        {
            get
            {
                return this.TurnsCount != 0 && this.TurnsCount % turnsNeededToSwordsman == 0;
            }
        }

        public override bool CanProduceResourse
        {
            get
            {
                return this.TurnsCount != 0 && this.TurnsCount % turnsNeededToSteel == 0;
            }
        }

        public override string ToString()
        {
            return string.Format("--Barracks: {0} turns ({1} turns until Swordsman, {2} turns until Steel)",
                this.TurnsCount, 
                turnsNeededToSwordsman - this.TurnsCount % turnsNeededToSwordsman, 
                turnsNeededToSteel - this.TurnsCount % turnsNeededToSteel);
        }
    }
}
