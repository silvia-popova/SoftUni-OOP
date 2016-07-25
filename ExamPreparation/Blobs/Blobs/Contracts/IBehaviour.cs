using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobsGame.Contracts
{
    public interface IBehaviour
    {
        bool IsTriggered { get; set; }

        void ExecuteBehavior(IBlob blob);
    }
}
