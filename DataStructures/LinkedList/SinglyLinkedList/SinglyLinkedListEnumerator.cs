
using System.Collections;

namespace DataStructures.LinkedList.SinglyLinkedList
{
    internal class SinglyLinkedListEnumerator<T> : IEnumerator<T>
    {
        private SinglyLinkedListNode<T> Head;
        private SinglyLinkedListNode<T> _Current;

        public SinglyLinkedListEnumerator(SinglyLinkedListNode<T> head)
        {
            Head = head;
            _Current = null;
        }
            

        public T Current => _Current.Value;
        object IEnumerator.Current => Current;

        public void Dispose()
        {
            Head = null;
        }

        public bool MoveNext()
        {
            if(_Current == null)
            {
                _Current = Head;
                return true;
            }
            else
            {
                _Current = _Current.Next;
                return _Current != null;
            }
        }

        public void Reset()
        {
            _Current = null;
        }
    }
}