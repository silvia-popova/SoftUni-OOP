namespace LambdaCore.Models.Cores
{
    using System;
    using System.Text;
    using LambdaCore.Collection;
    using LambdaCore.Contracts;
    using LambdaCore.IO;
    using LambdaCore.Models.Fragments;

    public abstract class Core : ICore
    {
        private char name;
        private int initialDurability;
        private int currentDurability;
        private int pressure;
        private LStack<IFragment> fragments;

        protected Core(char name, int initialDurability)
        {
            this.Name = name;
            this.InitialDurability = initialDurability;
            this.Pressure = 0;
            this.fragments = new LStack<IFragment>();
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
                return this.initialDurability;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(Messages.NegativeParameter, nameof(this.InitialDurability)));

                }

                this.initialDurability = value;
            }
        }

        public int TempPressure { get; set; }

        protected int Pressure
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

                if (value <= 0)
                {
                    this.CurrentDurability = this.InitialDurability;
                    this.Status = "NORMAL";
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

            this.ApplyPressureAffection();
        }

        public IFragment RemoveFragment()
        {
            if (this.fragments.IsEmpty())
            {
                throw new ArgumentException("Failed to detach Fragment!");
            }

            var fragment = this.fragments.Pop();

            this.Pressure = 0;

            this.ApplyPressureAffection();

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

        private void ApplyPressureAffection()
        {
            foreach (var fragment in this.fragments)
            {
                fragment.ChangePressure(this);
            }

            this.Pressure = this.TempPressure;
            this.TempPressure = 0;
        }
    }
}
