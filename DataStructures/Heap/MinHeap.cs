using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Heap
{/*
    public class MinHeap<T> : BinaryHeap<T>, IEnumerable<T> where T : IComparable
    {
        public MinHeap() : base()
        {

        }
        public MinHeap(int _size) : base(_size)
        {
            
        }
        public MinHeap(IEnumerable<T> collection) : base(collection)
        {

        }
        protected override void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                var smallerIndex = (HasRightChild(index) && 
                    GetRightChild(index).CompareTo(GetLeftChild(index)) < 0) ?
                    GetRightChildIndex(index) : GetLeftChildIndex(index);

                if (Array[smallerIndex].CompareTo(Array[index]) >= 0) break;

                Swap(index, smallerIndex);
                index = smallerIndex;
            }
        }
        protected override void HeapifyUp()
        {
            int index = Position - 1;
            while (Array[index].CompareTo(GetParent(index)) < 0 && !IsRoot(index))
            {
                Swap(GetParentIndex(index), index);
                index = GetParentIndex(index);
            }
        }
    }*/
}
