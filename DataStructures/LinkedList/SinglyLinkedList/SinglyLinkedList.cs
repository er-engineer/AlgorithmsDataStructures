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

        public int Length { get; private set; }

        private bool IsHeadNull(SinglyLinkedListNode<T> head)
        {
            return Head == null ? throw new Exception("Head is null.") : false;
        }

        public SinglyLinkedList(IEnumerable<T> collection)
        {
            Length = 0;
            foreach(var item in collection)
            {
                this.AddLast(item);
            }
                
        }

        public SinglyLinkedList()
        {
            Length = 0;
            if (!isHeadNull)
            {
                var current = new SinglyLinkedListNode<T>();
                current = Head;
                while (current != null)
                {
                    current = current.Next;
                    Length++;
                }
            }  
        }  
        
        public void Clear()
        {
            Head = null;
            Length = 0;
        }

        public T GetElementByIndex(int index)
        {
            int counter = 0;
            var current = new SinglyLinkedListNode<T>();
            current = Head;
            while(counter != index)
            {
                current = current.Next;
                counter++;
            }

            return current.Value;
        }

        public void RemoveFirst()
        {
            IsHeadNull(this.Head);
            Head = Head.Next;
            Length--;
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
            Length--;
        }

        public void Remove(SinglyLinkedListNode<T> node)
        {
            var current = new SinglyLinkedListNode<T>();
            current = Head;
            if (isHeadNull)
            {
                throw new Exception("There is no item to be removed.");
            }

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
            Length--;
        }

        public void Remove(T value)
        {
            var current = new SinglyLinkedListNode<T>();
            current = Head;

            if(value == null)
            {
                throw new ArgumentNullException("Value is null.");
            }

            while(current != null)
            {

                if (isHeadNull)
                {
                    throw new Exception("List is empty.");
                }
                if(current.Next == null)
                {
                    throw new Exception("There is no item found.");
                }
                else if(current.Next.Value.Equals(value))
                {
                    
                    current.Next = current.Next.Next;
                    Length--;
                    return;
                    
                }
                current = current.Next;
            }
            
        }

        public void AddFirst(T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);
            newNode.Next = Head;
            Head = newNode;
            Length++;
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
            Length++;

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
                    Length++; 
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
