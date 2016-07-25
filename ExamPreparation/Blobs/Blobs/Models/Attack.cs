using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlobsGame.Contracts;

namespace BlobsGame.Models
{
    public abstract class Attack: IAttack
    {
        protected Attack(int damage)
        {
            this.Damage = damage;
        }

        public int Damage { get; private set; }

        public virtual void Hit(IBlob defender)
        {
            defender.Health -= this.Damage;
        }
    }
}
