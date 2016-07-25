using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlobsGame.Contracts;

namespace BlobsGame.Models
{
    public abstract class Behaviour : IBehaviour
    {
        protected Behaviour()
        {
        }

        public bool IsTriggered { get; set; }

        public abstract void ExecuteBehavior(IBlob blob);
    }
}
