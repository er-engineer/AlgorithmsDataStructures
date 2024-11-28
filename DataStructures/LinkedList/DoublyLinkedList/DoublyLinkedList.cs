using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.DoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        public DoublyLinkedListNode<T> Head { get; set; }
        public DoublyLinkedListNode<T> Tail { get; set; }
        private bool IsHeadNull => Head == null;
        private bool IsTailNull => Tail == null;

        public void AddFirst(T value)
        {
            var newNode = new DoublyLinkedListNode<T>(value);
            if (!IsHeadNull)
            {
                Head.Previous = newNode;
            }
            newNode.Next = Head;
            Head = newNode;
            if (IsTailNull)
            {
                Tail = Head;
            }
        }

        public void AddFirst(DoublyLinkedListNode<T> newNode)
        {
            if (!IsHeadNull)
            {
                newNode.Next = Head;
            }
            newNode.Previous = null;        
            Head = newNode;
            if (IsTailNull)
            {
                Tail = Head;
            }
            
        }

        public void AddLast(T value)
        {
            var newNode = new DoublyLinkedListNode<T>(value);
            if (!IsTailNull)
            {
                Tail.Next = newNode;
            }
            newNode.Previous = Tail;
            Tail = newNode;
            if (IsHeadNull)
            {
                Head = newNode;
                newNode.Previous = null;
            }
        }

        public void AddLast(DoublyLinkedListNode<T> newNode)
        {
            if (IsTailNull)
            {
                Tail = newNode;
            }
            newNode.Next = null;
            newNode.Previous = Tail;
            Tail = newNode;
            if (IsHeadNull)
            {
                Head = newNode;
            }

        }

        public void AddAfter(T value, DoublyLinkedListNode<T> referenceNode)


        {
            var newNode = new DoublyLinkedListNode<T>(value);

            newNode.Next = referenceNode.Next;
            referenceNode.Next.Previous = newNode;
            referenceNode.Next = newNode;
            newNode.Previous = referenceNode;
        }

        public void AddBefore(T value, DoublyLinkedListNode<T> referenceNode)
        {
            var newNode = new DoublyLinkedListNode<T>(value);

            referenceNode.Previous.Next = newNode;
            newNode.Previous = referenceNode.Previous;
            referenceNode.Previous = newNode;
            newNode.Next = referenceNode;
        }
    }
}
