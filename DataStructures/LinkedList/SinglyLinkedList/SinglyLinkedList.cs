using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        public SinglyLinkedListNode<T> Head {  get; set; }
        private bool isHeadNull => Head == null;

        public SinglyLinkedList(IEnumerable<T> collection)
        {
            foreach(var item in collection)
                this.AddLast(item);
        }

        public SinglyLinkedList()
        {
            
        }
        public void RemoveFirst()
        {
            if (isHeadNull)
            {
                throw new Exception("There is nothing to remove.");
            }
            Head = Head.Next;
        }

        public void RemoveLast()
        {
            if (isHeadNull)
                RemoveFirst();
            
            var current = new SinglyLinkedListNode<T>();
            current = Head;
            while(current.Next.Next != null)
                current = current.Next;
            current.Next = null;
        }

        public void Remove(SinglyLinkedListNode<T> node)
        {
            var current = new SinglyLinkedListNode<T>();
            current = Head;
            if (node.Equals(Head))
            {
                RemoveFirst();
                return;
            }

            while (!current.Next.Equals(node))
            {
                current = current.Next;
            }

            current.Next = node.Next;
        }

        public void AddFirst(T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);
            newNode.Next = Head;
            Head = newNode;
        }

        public void AddLast(T value)
        {
            var current = Head;
            var newNode = new SinglyLinkedListNode<T>(value);
            if (current == null)
            {
                Head = newNode;  
            }
            else
            {
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            
        }

        public void AddAfter(SinglyLinkedListNode<T> node, T value)
        {
            if(node == null)
            {
                throw new ArgumentNullException();
            }

            if(isHeadNull)
            {
                AddFirst(value);
                return;
            }
            
            var current = Head;
            var newNode = new SinglyLinkedListNode<T>(value);
            while(current != null)
            {
                if (current.Equals(node))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
            }
            throw new ArgumentException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new SinglyLinkedListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
