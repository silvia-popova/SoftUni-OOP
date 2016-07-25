using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class Griffin : Creature
    {
        //attack 8, defense 8, health points 25 and damage 4.5. 
        private const int DefaultBehemothAttack = 8;
        private const int DefaultBehemothDefense = 8;
        private const int DefaultBehemothHealth = 25;
        private const decimal DefaultBehemothDamage = 4.5M;

        public Griffin()
            : base(DefaultBehemothAttack, DefaultBehemothDefense, DefaultBehemothHealth, DefaultBehemothDamage)
        {
            this.AddSpecialty(new DoubleDefenseWhenDefending(5));
            this.AddSpecialty(new AddDefenseWhenSkip(3));
            this.AddSpecialty(new Hate(typeof(WolfRaider)));
        }
    }
}
