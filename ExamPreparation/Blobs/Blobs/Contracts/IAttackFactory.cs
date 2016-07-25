using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlobsGame.Enums;

namespace BlobsGame.Contracts
{
    public interface IAttackFactory
    {
        IAttack ProduceAttack(AttackType attackType, int damage);
    }
}
