using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlobsGame.Contracts;
using BlobsGame.Enums;
using BlobsGame.Models;

namespace BlobsGame.Core
{
    public class Engine : IEngine
    {
        private readonly IBlobFactory blobFactory;
        private readonly IAttackFactory attackFactory;
        private readonly IBlobData data;
        private readonly IInputReader reader;
        private readonly IOutputWritter writer;

        public Engine(
            IBlobFactory blobFactory,
            IAttackFactory attackFactory,
            IBlobData data,
            IInputReader reader,
            IOutputWritter writer)
        {
            this.blobFactory = blobFactory;
            this.attackFactory = attackFactory;
            this.data = data;
            this.reader = reader;
            this.writer = writer;
        }

        // Made method virtual
        public virtual void Run()
        {
            while (true)
            {
                string[] input = this.reader.ReadLine().Split();

                this.ExecuteCommand(input);
                this.UpdateBlobs();
            }
        }

        private void UpdateBlobs()
        {
            foreach (var blob in data.Blobs)
            {
                blob.Update();
            }
        }

        private void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "status":
                    this.ExecuteStatusCommand();
                    break;
                case "drop":
                    Environment.Exit(0);
                    break;
                case "pass":
                    break;
                case "create":
                    this.ExecuteCreateCommand(inputParams.Skip(1).ToList());
                    break;
                case "attack":
                    this.ExecuteAttackCommand(inputParams);
                    break;
                default:
                    throw new ArgumentException("Unknown command.");
            }
        }

        private void ExecuteAttackCommand(string[] inputParams)
        {
            var attackerName = inputParams[1];
            var defenderName = inputParams[2];

            var attacker = this.data.FindBlobByName(attackerName);
            var defender = this.data.FindBlobByName(defenderName);

            if (attacker.Health < 1)
            {
                return;
            }

            if (defender.Health < 1)
            {
                return;
            }

            var attack = attacker.ProduceAttack();
            defender.RespondToAttack(attack);
        }

        private void ExecuteCreateCommand(List<string> commandParams)
        {
            //create Cenko 30 15 Inflated PutridFart
            string name = commandParams[0];
            int health = int.Parse(commandParams[1]);
            int damage = int.Parse(commandParams[2]);
            string behavior = commandParams[3];
            string attack = commandParams[4];

            IBehaviour behaviour;

            if (behavior == "Inflated")
            {
                behaviour = new InflatedBehavior();
            }
            else
            {
                behaviour = new AggressiveBehavior();
            }

            var attackType = (AttackType) Enum.Parse(typeof (AttackType), attack);

            var blob = this.blobFactory.ProduceBlob(name, damage, health, behaviour, attackType,
                this.attackFactory);

            this.data.AddBlobs(blob);
        }

        private void ExecuteStatusCommand()
        {
            foreach (var blob in this.data.Blobs)
            {
                this.writer.WriteLine(blob.ToString());
            }
        }
    }
}
