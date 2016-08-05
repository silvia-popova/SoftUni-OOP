using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem5.KingsGambitExtended
{
    public delegate void OnAttackEventHandler(King sender, EventArgs eventArgs);

    public class King
    {
        public event OnAttackEventHandler OnAttack;

        public King(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public void RespondToAttack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");
            this.OnAttack?.Invoke(this, EventArgs.Empty);
        }
    }

    public interface ISolder
    {
        event OnDeathEventHandler OnDeath;

        string Name { get; }

        void OnAttackInfo(King sender, EventArgs eventArgs);

        void Kill();
    }

    public class OnDeathEventArgs : EventArgs
    {
        public OnDeathEventArgs(King king)
        {
            this.King = king;
        }

        public King King { get; private set; }
    }

    public delegate void OnDeathEventHandler(ISolder sender, OnDeathEventArgs eventArgs);

    public class Footman : ISolder
    {
        public event OnDeathEventHandler OnDeath;
        
        private int lives;
        private King king;

        public Footman(string name, King king)
        {
            this.king = king;
            this.Name = name;
            this.lives = 2;
        }

        public string Name { get; }

        public void OnAttackInfo(King sender, EventArgs eventArgs)
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }

        public void Kill()
        {
            this.lives--;

            if (this.lives == 0)
            {
                this.OnDeath?.Invoke(this, new OnDeathEventArgs(king));
            }
        }
    }

    public class RoyalGuard : ISolder
    {
        public event OnDeathEventHandler OnDeath;

        private int lives;
        private King king;

        public RoyalGuard(string name, King king)
        {
            this.Name = name;
            this.king = king;
            this.lives = 3;
        }

        public string Name { get; }

        public void OnAttackInfo(King sender, EventArgs eventArgs)
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }

        public void Kill()
        {
            this.lives--;
            if (this.lives == 0)
            {
                this.OnDeath?.Invoke(this, new OnDeathEventArgs(king));
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            var king = new King(name);
            var soldiers = new List<ISolder>();

            string[] royalGardsNames = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var royalName in royalGardsNames)
            {
                var royalGuard = new RoyalGuard(royalName, king);
                king.OnAttack += royalGuard.OnAttackInfo;
                royalGuard.OnDeath += RespondToDeath;
                soldiers.Add(royalGuard);
            }

            string[] footmanNames = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var footmanName in footmanNames)
            {
                var footman = new Footman(footmanName, king);
                king.OnAttack += footman.OnAttackInfo;
                footman.OnDeath += RespondToDeath;
                soldiers.Add(footman);
            }

            string line = Console.ReadLine();

            while (line != "End")
            {
                var commandArgs = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var command = commandArgs[0];

                switch (command)
                {
                    case "Kill":
                        var nameOfVictim = commandArgs[1];
                        var victim = soldiers.FirstOrDefault(s => s.Name == nameOfVictim);

                        if (victim != null)
                        {
                            victim.Kill();
                        }
                        break;
                    case "Attack":
                        king.RespondToAttack();
                        break;
                }

                line = Console.ReadLine();
            }
        }

        private static void RespondToDeath(ISolder sender, OnDeathEventArgs eventArgs)
        {
            eventArgs.King.OnAttack -= sender.OnAttackInfo;
        }
    }
}
