using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlobsGame.Contracts;
using BlobsGame.Enums;

namespace BlobsGame.Models.Factories
{
    public class BlobFactory : IBlobFactory
    {
        public IBlob ProduceBlob(string blobName, int damage, int health, IBehaviour behavior, AttackType attackType, IAttackFactory attackFactory)
        {
            return new Blob(blobName, damage, health, behavior, attackType, attackFactory);
        }
    }
}
