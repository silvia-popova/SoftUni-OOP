using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlobsGame.Enums;

namespace BlobsGame.Contracts
{
    public interface IBlobFactory
    {
        IBlob ProduceBlob(string blobName, int damage, int health,
            IBehaviour behavior, AttackType attackType, IAttackFactory attackFactory);
    }
}
