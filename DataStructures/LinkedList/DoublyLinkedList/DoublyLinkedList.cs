using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.DoublyLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable
    {
        public DoublyLinkedListNode<T> Head { get; set; }
        public DoublyLinkedListNode<T> Tail { get; set; }
        private bool IsHeadNull => Head == null;
        private bool IsTailNull => Tail == null;
        private bool IsSingleItem => Head == Tail;

        public DoublyLinkedList()
        {
            
        }

        public DoublyLinkedList(IEnumerable<T> collection)
        {
            foreach(var item in collection)
            {
                AddLast(item);
            }
        }

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

        private List<DoublyLinkedListNode<T>> GetAllNodes()
        {
            var list = new List<DoublyLinkedListNode<T>>();
            var current = Head;
            while (current != null)
            {
                list.Add(current);
                current = current.Next;
            }
            return list;
        }

        public void RemoveFirst()
        {
            if (IsHeadNull)
                throw new Exception("List is empty.");
            if(IsSingleItem)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Head = Head.Next;
                Head.Previous = null;
            }  
        }

        public void RemoveLast()
        {
            if (IsTailNull)
            {
                throw new Exception("There is no item.");
            }

            if (IsSingleItem)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail = Tail.Previous;
                Tail.Next = null;
            }
            
        }

        public void Remove(T value)
        {
            var current = new DoublyLinkedListNode<T>(value);
            current = Head;
            if (IsHeadNull)
            {
                throw new Exception("There is no item.");
            }
            if (IsSingleItem)
            {
                if (Head.Value.Equals(value))
                {
                    RemoveFirst();
                }
            }
            
            while(current != null)
            {
                if (current.Value.Equals(value))
                {
                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;
                }
                current = current.Next;
            }
            
            if(current == null)
            {
                throw new Exception("The item is not in the list.");
            }

        }

        public void Remove(DoublyLinkedListNode<T> deletedNode)
        {
            if (IsHeadNull)
            {
                throw new Exception("There is no item.");
            }
            if(deletedNode == Tail)
            {
                deletedNode.Previous.Next = null;
                Tail = deletedNode.Previous;
            }
            else if(deletedNode == Head)
            {
                deletedNode.Next.Previous = null;
                Head = deletedNode.Next;
            }
            else
            {
                deletedNode.Next.Previous = deletedNode.Previous;
                deletedNode.Previous.Next = deletedNode.Next;
            }
            

        }
        public IEnumerator GetEnumerator()
        {
            return GetAllNodes().GetEnumerator();
        }
    }
}
