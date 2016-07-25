using System;
using System.Linq;
using System.Reflection;

namespace CustmClassAttribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class WeaponAttribute : Attribute
    {
        public WeaponAttribute(string author, int revision, string description, params string[] reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.Reviewers = reviewers;
        }

        public string Author { get; set; }

        public int Revision { get; set; }

        public string Description { get; set; }

        public string[] Reviewers { get; set; }
    }

    [Weapon("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
    public abstract class Weapon
    {
        private const int PointOfStrengthToAddToMinDamage = 2;
        private const int PointOfStrengthToAddToMaxDamage = 3;
        private const int PointOfAgilityToAddToMaxDamage = 4;

        private int minDamage;
        private int maxDamage;
        private int strength;
        private int agility;
        private int vitality;

        public string Name { get; set; }

        public override string ToString()
        {
            return $"{this.Name}: {this.minDamage}-{this.maxDamage} Damage, +{this.strength} Strength, " +
                   $"+{this.agility} Agility, +{this.vitality} Vitality";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var type = Assembly.GetExecutingAssembly()
                   .GetTypes()
                   .FirstOrDefault(c => c.CustomAttributes.Any(a => a.AttributeType == typeof(WeaponAttribute)));

            var attr = type.GetCustomAttribute<WeaponAttribute>();

            while (input != "END")
            {
                if (input == "Author")
                {
                    Console.WriteLine("Author: {0}", attr.Author);
                }
                else if (input == "Revision")
                {
                    Console.WriteLine("Revision: {0}", attr.Revision);
                }
                else if (input == "Description")
                {
                    Console.WriteLine("Class description: {0}", attr.Description);
                }
                else
                {
                    Console.WriteLine("Reviewers: {0}", string.Join(", ", attr.Reviewers.ToList()));
                }

                input = Console.ReadLine();
            }
        }
    }
}
