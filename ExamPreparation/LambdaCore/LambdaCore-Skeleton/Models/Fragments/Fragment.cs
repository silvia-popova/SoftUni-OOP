namespace LambdaCore.Models.Fragments
{
    using System;
    using LambdaCore.Contracts;
    using LambdaCore.Enums;
    using LambdaCore.IO;

    public abstract class Fragment : IFragment
    {
        private string name;
        private FragmentType type;
        private int pressureAffection;

        protected Fragment(FragmentType type, string name, int pressureAffection)
        {
            this.Name = name;
            this.PressureAffection = pressureAffection;
            this.Type = type;
        }

        public string Name { get; protected set; }

        public FragmentType Type { get; protected set; }

        public int PressureAffection
        {
            get
            {
                return this.pressureAffection;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(Messages.NegativeParameter, nameof(this.PressureAffection)));
                }

                this.pressureAffection = value;
            }
        }

        public abstract void ChangePressure(ICore core);
    }
}
