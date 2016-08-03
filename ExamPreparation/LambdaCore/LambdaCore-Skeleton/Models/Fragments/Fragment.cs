namespace LambdaCore.Models.Fragments
{
    using System;
    using System.Runtime.Remoting.Activation;
    using LambdaCore.Contracts;
    using LambdaCore.Enums;

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

        public int PressureAffection {
            get
            {
                return this.pressureAffection;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
            }
        }

        public abstract void ChangePressure(ICore core);
    }
}
