using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobsGame.Contracts
{
    public interface IAttack
    {
        int Damage { get; }

        void Hit(IBlob defender);
    }
}
