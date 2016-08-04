namespace LambdaCore.Collection
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class LStack<IFragment> : IEnumerable<IFragment>
    {
        private LinkedList<IFragment> innerList;

        public LStack()
        {
            this.innerList = new LinkedList<IFragment>();
        }

        public int Count()
        {
            return this.innerList.Count;
        }

        public void Push(IFragment item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Fragment cannot be null");
            }

            this.innerList.AddLast(item);
        }

        public IFragment Peek()
        {
            if (this.Count() == 0)
            {
                throw new ArgumentException("LStack is empty");
            }

            IFragment fragment = this.innerList.Last();

            return fragment;
        }

        public IFragment Pop()
        {
            if (this.Count() == 0)
            {
                throw new ArgumentException("LStack is empty");
            }

            IFragment fragment = this.innerList.Last();
            this.innerList.RemoveLast();

            return fragment;
        }

        public Boolean IsEmpty()
        {
            return this.innerList.Count == 0;
        }

        public IEnumerator<IFragment> GetEnumerator()
        {
            foreach (var fragment in this.innerList)
            {
                yield return fragment;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
