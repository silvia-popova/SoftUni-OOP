using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlobsGame.Contracts;
using BlobsGame.Enums;

namespace BlobsGame.Models
{
    public class Blob : IBlob
    {
        private readonly IAttackFactory attackFactory;
        private int behaviourTriggerHealth;
        private bool isBehaviourTriggered;
        private int initialDamage;
        private int health;

        public Blob(string name, int damage, int health,
            IBehaviour behaviour,
            AttackType attackType,  
            IAttackFactory attackFactory)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.AttackType = attackType;
            this.Behaviour = behaviour;
            this.attackFactory = attackFactory;
            this.behaviourTriggerHealth = health/2;
        }

        public string Name { get; }

        public int Health
        {
            get
            {
                return this.health;
            }

            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.health = value;
            } 
            
        }

        public int Damage { get; set; }

        public int InitialDamage { get; set; }

        public IBehaviour Behaviour { get; }

        public AttackType AttackType { get; }

        public BehaviourType BehaviourType { get; }

        public IAttack ProduceAttack()
        {
            IAttack attack;

            if (this.AttackType == AttackType.PutridFart)
            {
                attack = this.attackFactory.ProduceAttack(this.AttackType, this.Damage);
                return attack;
            }
            else
            {
                attack = this.attackFactory.ProduceAttack(this.AttackType, this.Damage * 2);

                this.Health -= this.Health/2;

                if (this.Health < 1)
                {
                    this.Health = 1;
                }

                return attack;
            }
        }

        public IBehaviour ProduceBehaviour()
        {
            if (this.BehaviourType == BehaviourType.AggressiveBehavior)
            {
                var aggressBehaviour = new AggressiveBehavior();

                this.initialDamage = this.Damage;
                this.Damage *= 2;

                return aggressBehaviour;
            }
            else
            {
                var inflBehaviour = new InflatedBehavior();

                this.Health += 50;

                return inflBehaviour;
            }
        }

        public void RespondToAttack(IAttack attack)
        {
            attack.Hit(this);
        }

        public void Update()
        {
            this.isBehaviourTriggered = this.behaviourTriggerHealth >= this.Health;

            if (this.isBehaviourTriggered && !this.Behaviour.IsTriggered)
            {
                this.Behaviour.IsTriggered = true;
            }

            if (this.Behaviour.IsTriggered)
            {
                this.Behaviour.ExecuteBehavior(this);
            }
        }

        public override string ToString()
        {
            if (this.Health > 0)
            {
                return $"Blob {this.Name}: {this.Health} HP, {this.Damage} Damage";
            }
            else
            {
                return $"Blob {this.Name}: KILLED";
            }
        }
    }
}
