using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Shared
{
    public class CustomComparer<T> : IComparer<T>
        where T : IComparable
    {
        private readonly bool IsMax;
        private readonly IComparer<T> Comparer;
        public CustomComparer(SortDirection sortDirection, IComparer<T> comparer)
        {
            this.IsMax = sortDirection == SortDirection.Descending;
            this.Comparer = comparer;
        }
        public int Compare(T x, T y)
        {
            return IsMax ? CustomCompare(y, x) : CustomCompare(x, y);
        }

        private int CustomCompare(T x, T y) => Comparer.Compare(x, y);
   
    }
}
