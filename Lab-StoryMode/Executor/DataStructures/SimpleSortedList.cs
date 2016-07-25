namespace Executor.DataStructures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    using Contracts;

    public class SimpleSortedList<T> : ISimpleOrderedBag<T> where T : IComparable<T>
    {
        private const int DefaultSize = 16;

        private readonly IComparer<T> comparer;

        private T[] innerCollection;
        private int size;

        public SimpleSortedList(IComparer<T> comparer, int capacity)
        {
            this.comparer = comparer;
            this.InitializeInnerColection(capacity);
        }

        public SimpleSortedList(int capacity) : this(Comparer<T>.Create((x, y) => x.CompareTo(y)), capacity)
        {
        }

        public SimpleSortedList(IComparer<T> comparer) : this(comparer, DefaultSize)
        {
        }

        public SimpleSortedList() : this(Comparer<T>.Create((x, y) => x.CompareTo(y)), DefaultSize)
        {
        }

        public int Size => this.size;

        public void Add(T element)
        {
            if (this.Size + 1 >= this.innerCollection.Length)
            {
                this.Resize();
            }

            this.innerCollection[this.size] = element;
            this.size++;

            this.BubbleSort(this.innerCollection,  this.comparer);
        }

        public void AddAll(ICollection<T> elements)
        {
            if (this.Size + elements.Count >= this.innerCollection.Length)
            {
                this.MultiResize(elements);
            }

            foreach (var element in elements)
            {
                this.innerCollection[this.Size] = element;
                this.size++;
            }

            this.BubbleSort(this.innerCollection, this.comparer);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Size; i++)
            {
                yield return this.innerCollection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        
        public string JoinWith(string joiner)
        {
            var result = new StringBuilder();

            foreach (var element in this)
            {
                result.Append(element);
                result.Append(joiner);
            }

            result.Remove(result.Length - 1, 1);
            return result.ToString();
        }

        private void InitializeInnerColection(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Capacity cannot be negative!");
            }

            this.innerCollection = new T[capacity];
        }

        private void Resize()
        {
            T[] newCollection = new T[this.Size * 2];
            Array.Copy(this.innerCollection, newCollection, this.Size);
            this.innerCollection = newCollection;
        }

        private void MultiResize(ICollection<T> elements)
        {
            int newSize = this.innerCollection.Length * 2;

            while (this.Size + elements.Count >= newSize)
            {
                newSize *= 2;
            }

            T[] newCollection = new T[newSize];
            Array.Copy(this.innerCollection, newCollection, this.Size);
            this.innerCollection = newCollection;
        }

        private void BubbleSort(T[] arr, IComparer<T> comparer1)
        {
            T temp = default(T);

            for (int write = 0; write < this.Size; write++)
            {
                for (int sort = 0; sort < this.Size - 1; sort++)
                {
                    if (comparer1.Compare(arr[sort], arr[sort + 1]) > 0)
                    {
                        temp = arr[sort + 1];
                        arr[sort + 1] = arr[sort];
                        arr[sort] = temp;
                    }
                }
            }
        }
    }
}
