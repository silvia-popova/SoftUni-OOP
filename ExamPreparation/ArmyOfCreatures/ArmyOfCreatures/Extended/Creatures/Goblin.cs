using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class Goblin : Creature
    {
        //attack 4, defense 2, health points 5 and damage 1.5
        private const int DefaultAngelAttack = 4;
        private const int DefaultAngelDefense = 2;
        private const int DefaultAngelHealth = 5;
        private const decimal DefaultAngelDamage = 1.5M;

        public Goblin()
            : base(DefaultAngelAttack, DefaultAngelDefense, DefaultAngelHealth, DefaultAngelDamage)
        {
        }
    }
}