using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobsGame.Contracts
{
    public interface IBlobData
    {
        IEnumerable<IBlob> Blobs { get; }

        void AddBlobs(IBlob blob);

        IBlob FindBlobByName(string name);
    }
}
