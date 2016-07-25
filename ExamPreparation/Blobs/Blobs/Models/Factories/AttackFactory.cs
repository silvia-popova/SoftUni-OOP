using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlobsGame.Contracts;
using BlobsGame.Enums;

namespace BlobsGame.Models
{
    public class AttackFactory : IAttackFactory
    {
        public IAttack ProduceAttack(AttackType attackType, int damage)
        {
            switch (attackType)
            {
                   case AttackType.PutridFart:
                    return new PutridFartAttack(damage);
                case AttackType.Blobplode:
                    return new BlobplodeAttack(damage);
                default:
                    throw new InvalidOperationException("unknown type of attack");
            }
        }
    }
}
