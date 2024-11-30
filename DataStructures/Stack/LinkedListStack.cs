using DataStructures.LinkedList.SinglyLinkedList;
using System.ComponentModel;

namespace DataStructures.Stack
{
    public class LinkedListStack<T> : IStack<T>
    {
        private readonly SinglyLinkedList<T> list = new SinglyLinkedList<T>();
        public int Count { get; private set; }

        public void Clear()
        {
            list.Clear();
        }

        public T Peek()
        {
            if (Count == 0) throw new Exception("Stack is empty!");
            return list.Head.Value;
        }

        public T Pop()
        {
            if (Count == 0) throw new Exception("Stack is empty!");
            list.RemoveFirst();
            Count--;
            return list.Head.Value;
        }

        public void Push(T item)
        {
            if (item == null) throw new ArgumentNullException("Item");
            list.AddFirst(item);
            Count++;
        }
    }
}