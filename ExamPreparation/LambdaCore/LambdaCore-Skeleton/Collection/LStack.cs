namespace LambdaCore.Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using LambdaCore.Models.Cores;

    public class LStack<IFragment>
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

        public IFragment Push(IFragment item)
        {
            this.innerList.AddLast(item);
            return item;
        }

        public void Pop()
        {
            this.innerList.RemoveLast();
        }

        public IFragment Peek()
        {
            IFragment peekedItem = this.innerList.First();
            return peekedItem;
        }

        public Boolean IsEmpty()
        {
            return this.innerList.Count > 0;
        }
    }
}
