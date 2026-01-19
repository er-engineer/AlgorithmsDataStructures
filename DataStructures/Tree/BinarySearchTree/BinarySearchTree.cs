using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tree.BinaryTree;

namespace DataStructures.Tree.BinarySearchTree
{
    public class BinarySearchTree<T> : IEnumerable<T> where T: IComparable
    {
        public Node<T> Root { get; set; }

        public BinarySearchTree()
        {
            
        }

        public BinarySearchTree(IEnumerable<T> collection)
        {
            foreach (var item in collection) Add(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new BinarySearchTreeEnumerator<T>(Root);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T value)
        {
            if (value == null) throw new ArgumentNullException("Item");
            var newNode = new Node<T>(value);
            if(Root == null)
            {
                Root = newNode;
            }
            else
            {
                var current = Root;
                Node<T> parent;
                while (true)
                {
                    parent = current;
                    if(value.CompareTo(current.Value) < 0)
                    {
                        current = current.Left;
                        if(current == null)
                        {
                            parent.Left = newNode;
                            break;
                        }

                    }
                    else
                    {
                        current = current.Right;
                        if(current == null)
                        {
                            parent.Right = newNode;
                            break;
                        }
                    }
                }
            }
        }
        
        public Node<T> Minimum(Node<T> root)
        {
            var current = root;
            while (current.Left != null)
                current = current.Left;
            return current;
        }

        public Node<T> Maximum(Node<T> root)
        {
            var current = root;
            while(current.Right != null)
                current = current.Right;
            return current;
        }

        public Node<T> Find(T value, Node<T> root)
        {
            Root = root;
            if (Root == null) throw new Exception("Tree is empty.");
            var current = Root;

            while(value.CompareTo(current.Value) != 0)
            {
                if(value.CompareTo(current.Value) < 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }

                if (current == null) throw new Exception("Item could not found.");
             
            }
            return current;
            
        }

        public Node<T> Remove(Node<T> root, T value)
        {
            if (root == null) throw new ArgumentNullException();

            if(value.CompareTo(root.Value) < 0)
            {
                root.Left = Remove(root.Left, value);
            }
            else if(value.CompareTo(root.Value) > 0)
            {
                root.Right = Remove(root.Right, value);
            }
            else
            {
                // Single Child or Leaf
                if(root.Left == null)
                {
                    return root.Right;
                }
                else if(root.Right == null)
                {
                    return root.Left;
                }

                root.Value = Maximum(root.Right).Value;
                root.Right = Remove(root.Right, root.Value);
            }
            return root;
        }

        public static int MaxDepth(Node<T> root)
        {
            if (root == null)
                return 0;

            int leftDepth = MaxDepth(root.Left);
            int rightDepth = MaxDepth(root.Right);

            return leftDepth > rightDepth ? leftDepth + 1 : rightDepth + 1;
        }

    }
}
