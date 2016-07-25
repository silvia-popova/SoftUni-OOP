using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Extended.Creatures;
using ArmyOfCreatures.Logic.Creatures;

namespace ArmyOfCreatures.Logic
{
    public class CreatureFacturyExtention : CreaturesFactory
    {
        public override Creature CreateCreature(string name)
        {
            switch (name)
            {
                case "Goblin":
                    return new Goblin();
                case "WolfRaider":
                    return new WolfRaider();
                case "CyclopsKing":
                    return new CyclopsKing();
                case "AncientBehemoth":
                    return new AncientBehemoth();
                case "Griffin":
                    return new Griffin();
                default:
                    return base.CreateCreature(name);
            }
            
        }
    }
}
