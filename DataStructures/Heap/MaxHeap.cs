using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Heap
{
    /*
    internal class MaxHeap<T> : BinaryHeap<T>, IEnumerable<T> where T : IComparable
    {
        public MaxHeap() : base()
        {

        }

        public MaxHeap(int _size) : base(_size)
        {

        }

        public MaxHeap(IEnumerable<T> collection) : base(collection)
        {

        }

        protected override void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                var biggerIndex = (HasRightChild(index) &&
                    GetRightChild(index).CompareTo(GetLeftChild(index)) > 0) ?
                    GetRightChildIndex(index) : GetLeftChildIndex(index);

                if (Array[biggerIndex].CompareTo(Array[index]) < 0) break;

                Swap(index, biggerIndex);
                index = biggerIndex;
            }
        }

        protected override void HeapifyUp()
        {
            int index = Position - 1;
            while (Array[index].CompareTo(GetParent(index)) > 0 && !IsRoot(index))
            {
                Swap(GetParentIndex(index), index);
                index = GetParentIndex(index);
            }
        }
    }*/
}
