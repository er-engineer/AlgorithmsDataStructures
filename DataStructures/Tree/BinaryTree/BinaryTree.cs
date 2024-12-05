using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree.BinaryTree
{
    public class BinaryTree<T> where T : IComparable
    {
        public List<Node<T>> Nodes {  get; private set; }
        public BinaryTree()
        {
            Nodes = new List<Node<T>>();
        }
        public List<Node<T>> InOrder(Node<T> root)
        {
            if (root != null)
            {
                InOrder(root.Left);
                Nodes.Add(root);
                InOrder(root.Right);
            }
            return Nodes;
        }
    }
}
