namespace Problem4.WorkForce.Contracts
{
    using System.Collections.Generic;

    public interface IData
    {
        List<IEmploee> Employees { get; }

        List<IJob> Jobs { get; }

        void AddJob(IJob job);
    }
}
