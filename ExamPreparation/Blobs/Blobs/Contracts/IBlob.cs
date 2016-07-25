using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlobsGame.Enums;

namespace BlobsGame.Contracts
{
    public interface IBlob
    {
        string Name { get; }

        int Health { get; set; }

        int Damage { get; set; }

        int InitialDamage { get; set; }

        IBehaviour Behaviour { get; }

        AttackType AttackType { get; }

        BehaviourType BehaviourType { get; }

        IAttack ProduceAttack();

        IBehaviour ProduceBehaviour();

        void RespondToAttack(IAttack attack);

        void Update();
    }
}
