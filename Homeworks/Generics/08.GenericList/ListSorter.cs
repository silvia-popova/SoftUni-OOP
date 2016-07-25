using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.GenericList
{
    public static class ListSorter
    {
        public static GenericList<T> Sort<T>(GenericList<T> arr)
            where T : IComparable
        {
            T temp;

            for (int write = 0; write < arr.Count; write++)
            {
                for (int sort = 0; sort < arr.Count - 1; sort++)
                {
                    if (arr[sort].CompareTo(arr[sort + 1]) > 0)
                    {
                        temp = arr[sort + 1];
                        arr[sort + 1] = arr[sort];
                        arr[sort] = temp;
                    }
                }
            }

            return arr;
        }
    }
}
