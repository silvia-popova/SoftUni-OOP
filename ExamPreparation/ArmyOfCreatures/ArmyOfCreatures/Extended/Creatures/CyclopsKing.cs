using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Extended.Specialties;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class CyclopsKing : Creature
    {
        //attack 17, defense 13, health points 70, damage 18 
        private const int DefaultBehemothAttack = 17;
        private const int DefaultBehemothDefense = 13;
        private const int DefaultBehemothHealth = 70;
        private const decimal DefaultBehemothDamage = 18M;

        public CyclopsKing()
            : base(DefaultBehemothAttack, DefaultBehemothDefense, DefaultBehemothHealth, DefaultBehemothDamage)
        {
            this.AddSpecialty(new AddAttackWhenSkip(3));
            this.AddSpecialty(new DoubleAttackWhenAttacking(4));
            this.AddSpecialty(new DoubleDamage(1));
        }
    }
}
