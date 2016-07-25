using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlobsGame.Contracts;

namespace BlobsGame.Models
{
    public class AggressiveBehavior : Behaviour
    {
        private int behaviourCount;

        public override void ExecuteBehavior(IBlob blob)
        {
            if (this.behaviourCount == 0)
            {
                blob.InitialDamage = blob.Damage;
                blob.Damage *= 2;
            }
            else
            {
                blob.Damage -= 5;

                if (blob.Damage < blob.InitialDamage)
                {
                    blob.Damage = blob.InitialDamage;
                }
            }

            this.behaviourCount++;
        }
    }
}
