using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlobsGame.Enums;

namespace BlobsGame.Contracts
{
    public interface IBehaviourFactory
    {
        IBehaviour ProduceBehaviour(BehaviourType behaviourType);
    }
}
