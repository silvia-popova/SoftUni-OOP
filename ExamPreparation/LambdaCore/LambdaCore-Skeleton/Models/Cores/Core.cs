using System;
using System.Collections.Generic;
namespace LambdaCore_Skeleton.Models.Cores
{
    using LambdaCore.Collection;
    using LambdaCore.Contracts;
    using LambdaCore.Models.Fragments;

    public abstract class Core : ICore
    {
        private char name;
        private int durability;
        private int pressure;
        private LStack<IFragment> fragments;

        protected Core(char name, int durability)
        {
            this.Name = name;
            this.Durability = durability;
            this.fragments = new LStack<IFragment>();
        }

        public char Name { get; private set; }

        public int Durability
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

        public int Pressure { get; set; }
    }
}
