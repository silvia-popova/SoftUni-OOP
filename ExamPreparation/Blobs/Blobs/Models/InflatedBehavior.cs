using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlobsGame.Contracts;

namespace BlobsGame.Models
{
    public class InflatedBehavior : Behaviour
    {
        private int behaviourCount;

        public override void ExecuteBehavior(IBlob blob)
        {
            if (this.behaviourCount == 0)
            {
                blob.Health += 50;
            }
            else
            {
                blob.Health -= 10;
            }
            
            this.behaviourCount++;
        }
    }
}
