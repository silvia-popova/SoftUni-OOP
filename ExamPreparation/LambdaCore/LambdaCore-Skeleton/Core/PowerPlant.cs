namespace LambdaCore.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using LambdaCore.Contracts;
    using LambdaCore.IO;

    public class PowerPlant : IPowerPlant
    {
        private List<ICore> cores;
        private Dictionary<char, ICore> coresByName;

        public PowerPlant()
        {
            this.cores= new List<ICore>();
            this.coresByName= new Dictionary<char, ICore>();
        }

        public ICore CurrentCore { get; set; }

        public bool IsCurrentCoreSelected => this.CurrentCore != null;

        public void Add(ICore core)
        {
            if (core == null)
            {
                throw new ArgumentNullException(string.Format(Messages.NullParameter, nameof(core)));

            }

            this.cores.Add(core);
        }

        public void Remove(ICore core)
        {
            this.cores.Remove(core);

            if (this.CurrentCore == core)
            {
                this.CurrentCore = null;
            }
        }

        public IEnumerable<ICore> GetCores() => this.cores;

        public int CoresCount => this.cores.Count;

        public void AddCore(ICore core)
        {
            if (core == null)
            {
                throw new ArgumentNullException(string.Format(Messages.NullParameter, nameof(core)));

            }

            this.coresByName[core.Name] = core;
        }

        public void RemoveCore(char name)
        {
            if (!this.coresByName.ContainsKey(name))
            {
                throw new ArgumentException($"Failed to remove Core {name}!");
            }

            this.coresByName.Remove(name);
        }

        public ICore FindCoreByName(char name)
        {
            if (!this.coresByName.ContainsKey(name))
            {
                return null;
            }

            var core = this.coresByName[name];
            return core;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            var totalDurability = this.cores.Sum(c => c.CurrentDurability);
            var countOfCores = this.cores.Count;
            var countOfAllFragments = this.cores.Sum(c => c.CountOfFragments);

            result.AppendLine("Lambda Core Power Plant Status:");
            result.AppendLine($"Total Durability: {totalDurability}");
            result.AppendLine($"Total Cores: {countOfCores}");
            result.AppendLine($"Total Fragments: {countOfAllFragments}");

            foreach (var core in this.cores)
            {
                result.AppendLine(core.ToString());
            }

            return result.ToString().Trim();
        }
    }
}
