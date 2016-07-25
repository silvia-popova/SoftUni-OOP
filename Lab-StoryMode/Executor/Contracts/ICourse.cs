namespace Executor.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface ICourse : IComparable<ICourse>
    {
        string Name { get; }

        IReadOnlyDictionary<string, ISudent> StudentsByName { get; }

        void EnrollStudent(ISudent student);
    }
}
