using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces;

namespace Game.Models
{
    public abstract class Unit : IUnit
    {
        private int health;
        private int damage;

        protected Unit(int health, int damage)
        {
            this.Health = health;
            this.Damage = damage;
        }

        public int Health { get; private set; }
        public int Damage { get; private set; }
    }
}
