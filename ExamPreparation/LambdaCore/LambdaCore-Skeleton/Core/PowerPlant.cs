namespace LambdaCore.Core
{
    using System;
    using System.Collections.Generic;
    using LambdaCore.Contracts;

    public class PowerPlant : IPowerPlant
    {
        private List<ICore> cores;

        public PowerPlant()
        {
            this.cores= new List<ICore>();
        }

        public void Add(ICore core)
        {
            if (core == null)
            {
                throw new ArgumentNullException("Failed to create Core!");
            }

            this.cores.Add(core);
        }

        public IEnumerable<ICore> GetCores() => this.cores;

        public int CoresCount => this.cores.Count;
    }
}
