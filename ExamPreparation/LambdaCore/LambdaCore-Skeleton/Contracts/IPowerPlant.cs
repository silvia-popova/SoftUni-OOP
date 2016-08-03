namespace LambdaCore.Contracts
{
    using System.Collections.Generic;

    public interface IPowerPlant
    {
        int CoresCount { get; }

        void Add(ICore core);

        IEnumerable<ICore> GetCores();
    }
}