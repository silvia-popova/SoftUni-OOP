using System;

namespace LambdaCore_Skeleton.Models.Cores
{
    using System.Text;
    using LambdaCore.Collection;
    using LambdaCore.Contracts;
    using LambdaCore.Models.Fragments;

    public abstract class Core : ICore
    {
        private char name;
        private int durability;
        private int initialDurability;
        private int currentDurability;
        private int pressure;
        private LStack<IFragment> fragments;

        protected Core(char name, int initialDurability)
        {
            this.Name = name;
            this.InitialDurability = initialDurability;
            this.CurrentDurability = initialDurability;
            this.fragments = new LStack<IFragment>();
            this.Status = "NORMAL";
        }

        public char Name { get; private set; }

        public int CurrentDurability
        {
            get
            {
                return this.currentDurability;
            }

            set
            {
                if (value < 0)
                {
                    value = 0;

                }

                this.currentDurability = value;
            }
        }

        protected int InitialDurability
        {
            get
            {
                return this.durability;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Failed to create Core!");
                }

                this.durability = value;
            }
        }

        public int Pressure
        {
            get
            {
                return this.pressure;
            }

            set
            {
                if (value > 0)
                {
                    this.CurrentDurability -= value;
                    this.Status = "CRITICAL";
                }

                this.pressure = value;
            }
        }

        public string Status { get; set; }

        public int CountOfFragments => this.fragments.Count();

        public void AddFragment(IFragment fragment)
        {
            if (fragment == null)
            {
                throw new ArgumentException($"Failed to attach Fragment {fragment.Name}!");
            }

            this.fragments.Push(fragment);

            fragment.ChangePressure(this);
        }

        public IFragment RemoveFragment()
        {
            if (this.fragments.IsEmpty())
            {
                throw new ArgumentException("Failed to detach Fragment!");
            }

            var fragment = this.fragments.Pop();

            return fragment;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Core {this.Name}:");
            result.AppendLine($"####Durability: {this.CurrentDurability}");
            result.AppendLine($"####Status: {this.Status}");

            return result.ToString().Trim();
        }
    }
}
