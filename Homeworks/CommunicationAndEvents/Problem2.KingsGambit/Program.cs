using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2.KingsGambit
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
        string Name { get; }

        void OnAttackInfo(King sender, EventArgs eventArgs);
    }

    public class Footman : ISolder
    {
        public Footman(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public void OnAttackInfo(King sender, EventArgs eventArgs)
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }

    public class RoyalGuard : ISolder
    {
        public RoyalGuard(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public void OnAttackInfo(King sender, EventArgs eventArgs)
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
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
                var royalGuard = new RoyalGuard(royalName);
                king.OnAttack += royalGuard.OnAttackInfo;
                soldiers.Add(royalGuard);
            }

            string[] footmanNames = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var footmanName in footmanNames)
            {
                var footman = new Footman(footmanName);
                king.OnAttack += footman.OnAttackInfo;
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
                            king.OnAttack -= victim.OnAttackInfo;
                        }
                        break;
                    case "Attack":
                        king.RespondToAttack();
                        break;
                }

                line = Console.ReadLine();
            }
        }
    }
}
