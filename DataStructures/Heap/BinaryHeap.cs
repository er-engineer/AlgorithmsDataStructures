using DataStructures.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Heap
{
    public class BinaryHeap<T> : IEnumerable<T> where T : IComparable
    {
        public T[] Array { get; private set; }
        protected int Position { get; set; }
        public int Count { get; private set; }

        private readonly IComparer<T> Comparer;
        private readonly bool IsMax;

        public BinaryHeap()
        {
            Count = 0;
            Array = new T[128];
            Position = 0;
        }
        public BinaryHeap(int _size)
        {
            Count = 0;
            Array = new T[_size];
            Position = 0;
        }
        public BinaryHeap(IEnumerable<T> collection)
        {
            Count = 0;
            Array = new T[collection.Count()];
            Position = 0;
            foreach (var item in collection) Add(item);
        }
        
        public BinaryHeap(SortDirection sortDirection,
            IEnumerable<T> initial,
            IComparer<T> comparer)
        {
            Position = 0;
            Count = 0;

            // SortDirection is a non-nullable enum, so remove the null check
            this.IsMax = sortDirection == SortDirection.Descending;

            if (comparer != null)
            {
                this.Comparer = new CustomComparer<T>(sortDirection, comparer);
            }
            else
            {
                this.Comparer = new CustomComparer<T>(sortDirection, Comparer<T>.Default);
            }

            if (initial != null)
            {
                Array = new T[initial.Count()];
                foreach (var item in initial) Add(item);
            }
            else
            {
                Array = new T[128];
            }
        }
        public BinaryHeap(SortDirection sortDirection,
            IComparer<T> comparer)
            : this(sortDirection, null, comparer)
        {
        }
        public BinaryHeap(SortDirection sortDirection = SortDirection.Ascending)
            : this(sortDirection, null, null)
        {
        }
        public BinaryHeap(SortDirection sortDirection,
            IEnumerable<T> initial)
            : this(sortDirection, initial, null)
        {
        }

        protected int GetLeftChildIndex(int parentIndex) => 2 * parentIndex + 1;
        protected int GetRightChildIndex(int parentIndex) => 2 * parentIndex + 2;
        protected int GetParentIndex(int childIndex) => (childIndex - 1) / 2;
        protected bool HasLeftChild(int index) => GetLeftChildIndex(index) < Position;
        protected bool HasRightChild(int index) => GetRightChildIndex(index) < Position;
        protected bool IsRoot(int index) => index == 0;

        protected T GetLeftChild(int index) => Array[GetLeftChildIndex(index)];
        protected T GetRightChild(int index) => Array[GetRightChildIndex(index)];
        protected T GetParent(int index) => Array[GetParentIndex(index)];
        
        public bool IsEmpty() => Position == 0;
        public T Peek()
        {
            if (IsEmpty()) throw new Exception("Heap is empty!");
            return Array[0];
        }

        public void Swap(int first, int second)
        {
            var temp = Array[first];
            Array[first] = Array[second];
            Array[second] = temp;
        }

        public void Add(T value)
        {
            if(Position == Array.Length) throw new IndexOutOfRangeException("Heap is full!");
            Array[Position] = value;
            Position++;
            Count++;
            HeapifyUp();
        }

        public T Delete()
        {
            if(Position == 0) throw new IndexOutOfRangeException("Heap is empty!");
            var temp = Array[0];
            Array[0] = Array[Position - 1];
            Position--;
            Count--;
            HeapifyDown();
            return temp;
        }

        protected void HeapifyUp()
        {
            int index = Position - 1;
            while (Comparer.Compare(Array[index], GetParent(index)) < 0 && !IsRoot(index))
            {
                Swap(GetParentIndex(index), index);
                index = GetParentIndex(index);
            }
        }
        protected void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                var variableIndex = (HasRightChild(index) &&
                    Comparer.Compare(GetRightChild(index), GetLeftChild(index)) < 0) ?
                    GetRightChildIndex(index) : GetLeftChildIndex(index);

                if (Comparer.Compare(Array[variableIndex], Array[index]) >= 0) break;

                Swap(index, variableIndex);
                index = variableIndex;
            }
        }



        public IEnumerator<T> GetEnumerator()
        {
            return Array.Take(Position).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
