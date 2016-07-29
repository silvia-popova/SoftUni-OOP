namespace Executor.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface ISimpleOrderedBag<T> : IEnumerable<T> where T : IComparable<T>
    {
        int Size { get; }

        int Capasity { get; }

        void Add(T element);

        void AddAll(ICollection<T> elements);

        bool Remove(T element);

        string JoinWith(string joiner);
    }
}
