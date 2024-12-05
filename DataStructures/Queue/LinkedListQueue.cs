using DataStructures.LinkedList.DoublyLinkedList;

namespace DataStructures.Queue
{
    internal class LinkedListQueue<T> : IQueue<T>
    {   
        private readonly DoublyLinkedList<T> list = new DoublyLinkedList<T>();
        public int Count { get; private set; }

        public T DeQueue()
        {
            if (Count == 0) throw new Exception("Queue is empty!");
            var result = list.Head.Value;
            list.RemoveFirst();
            Count--;
            return result;
            
        }

        public void EnQueue(T item)
        {
            if(item  == null) throw new ArgumentNullException("Item");
            list.AddLast(item);
            Count++;
        }

        public T Peek()
        {
            if (Count == 0) throw new Exception("Queue is empty!");
            return list.Head.Value;
        }

        public int Size()
        {
            throw new NotImplementedException();
        }
    }
}