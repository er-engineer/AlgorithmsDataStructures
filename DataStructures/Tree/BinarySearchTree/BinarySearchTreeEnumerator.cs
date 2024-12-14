
using DataStructures.Tree.BinaryTree;
using System.Collections;

namespace DataStructures.Tree.BinarySearchTree
{
    public class BinarySearchTreeEnumerator<T> : IEnumerator<T> where T : IComparable<T>
    {
        private List<Node<T>> list;
        private int index = -1;
        public BinarySearchTreeEnumerator(Node<T> root)
        {
            list = new BinaryTree<T>().LevelOrderIterative(root);
        }
        public T Current => list[index].Value;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            list = null;
        }

        public bool MoveNext()
        {
            return ++index < list.Count ? true : false;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}