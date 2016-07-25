using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlobsGame.Contracts;

namespace BlobsGame.Core
{
    public class BlobData : IBlobData
    {
        private IList<IBlob> blobs;

        public BlobData()
        {
            this.blobs = new List<IBlob>();
        }

        public IEnumerable<IBlob> Blobs => this.blobs;

        public void AddBlobs(IBlob blob)
        {
            this.blobs.Add(blob);
        }

        public IBlob FindBlobByName(string name)
        {
            var blob = this.blobs.FirstOrDefault(b => b.Name == name);

            return blob;
        }
    }
}
