namespace LambdaCore.Contracts
{
    using System.Collections.Generic;

    public interface IPowerPlant
    {
        int CoresCount { get; }

        ICore CurrentCore { get; set; }

        bool IsCurrentCoreSelected { get; }

        void Add(ICore core);

        void Remove(ICore core);

        IEnumerable<ICore> GetCores();

        void AddCore(ICore core);

        void RemoveCore(char name);

        ICore FindCoreByName(char name);
    }
}