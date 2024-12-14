using DataStructures.Queue;
using DataStructures.Stack;
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
        public Node<T> Root { get; set; }
        public BinaryTree()
        {
            Nodes = new List<Node<T>>();
        }
        
        public void ClearNodes() => Nodes.Clear();
        public List<Node<T>> InOrderRecursive(Node<T> root)
        {
            if (root != null)
            {
                InOrderRecursive(root.Left);
                Nodes.Add(root);
                InOrderRecursive(root.Right);
            }
            return Nodes;
        }
        public List<Node<T>> PreOrderRecursive(Node<T> root)
        {
            if(root != null)
            {
                Nodes.Add(root);
                PreOrderRecursive(root.Left);
                PreOrderRecursive(root.Right);
            }
            return Nodes;
        }
        public List<Node<T>> PostOrderRecursive(Node<T> root)
        {
            if (root != null)
            {
                PostOrderRecursive(root.Left);
                PostOrderRecursive(root.Right);
                Nodes.Add(root);
            }
            return Nodes;
        }

        public List<Node<T>> InOrderIterative(Node<T> root)
        {
            var stack = new DataStructures.Stack.Stack<Node<T>>();
            Node<T> currentNode = root;
            bool isDone = false;
            while (!isDone)
            {
                if(currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.Left;
                }
                else
                {
                    if(stack.Count == 0)
                    {
                        isDone = true;
                    }
                    else
                    {
                        currentNode = stack.Pop();
                        Nodes.Add(currentNode);
                        currentNode = currentNode.Right;
                    }
                }
            }
            return Nodes;
        }
        public List<Node<T>> PreOrderIterative(Node<T> root)
        {
            var stack = new DataStructures.Stack.Stack<Node<T>>();
            if (root == null) throw new Exception();

            stack.Push(root);
            while(stack.Count != 0)
            {
                var temp = stack.Pop();
                Nodes.Add(temp);
                if (temp.Right != null) stack.Push(temp.Right);
                if (temp.Left != null) stack.Push(temp.Left);
            }
            return Nodes;
        }
        public List<Node<T>> PostOrderIterative(Node<T> root)
        {
            throw new NotImplementedException();
        }

        public List<Node<T>> LevelOrderIterative(Node<T> root)
        {
            var queue = new DataStructures.Queue.Queue<Node<T>>();
            queue.EnQueue(root);
            while (queue.Count > 0)
            {
                var temp = queue.DeQueue();
                Nodes.Add(temp);
                if (temp.Left != null)
                    queue.EnQueue(temp.Left);
                if (temp.Right != null)
                    queue.EnQueue(temp.Right);
            }
            return Nodes;
        }

        public Node<T> DeepestNode(Node<T> root)
        {
            Node<T> temp = null;

            if (root == null) throw new Exception("The tree is empty.");

            var queue = new DataStructures.Queue.Queue<Node<T>>();

            queue.EnQueue(root);
            while(queue.Count > 0)
            {
                temp = queue.DeQueue();
                if(temp.Left != null)
                {
                    queue.EnQueue(temp.Left);
                }
                if(temp.Right != null)
                {
                    queue.EnQueue(temp.Right);
                }    
            }
            return temp;
        }
        public Node<T> DeepestNode()
        {
            var list = LevelOrderIterative(Root);
                return list[list.Count - 1];
        }

        public static int LeafCount(Node<T> root)
        {
            int count = 0;
            if (root == null) return count;
            var queue = new DataStructures.Queue.Queue<Node<T>>();
            queue.EnQueue(root);

            while(queue.Count > 0)
            {
                var temp = queue.DeQueue();
                if(temp.Left == null && temp.Right == null)
                {
                    count++;
                }
                if(temp.Left != null)
                {
                    queue.EnQueue(temp.Left);
                }
                if (temp.Right != null)
                {
                    queue.EnQueue(temp.Right);
                }
            }
            return count;
        }

        public static int NumberOfFullNodes(Node<T> root)
        {
           return new BinaryTree<T>().LevelOrderIterative(root)
                .Where(x => x.Left != null && x.Right != null)
                .ToList().Count();
        }

        public static int NumberOfHalfNodes(Node<T> root)
        {
            return new BinaryTree<T>().LevelOrderIterative(root)
                .Where(x => (x.Left != null && x.Right == null) || (x.Left == null && x.Right != null))
                .ToList().Count();
        }

        public void PrintPaths(Node<T> root)
        {
            var path = new T[256];
            PrintPaths(root, path, 0);
        }

        private void PrintPaths(Node<T> root, T[] path, int pathLength)
        {
            if (root == null) return;
            path[pathLength] = root.Value;
            pathLength++;
            if(root.Left == null && root.Right == null)
            {
                PrintArray(path, pathLength);
            }
            else
            {
                PrintPaths(root.Left, path, pathLength);
                PrintPaths(root.Right, path, pathLength);
            }
        }

        private void PrintArray(T[] path, int length)
        {
            for(int i =0; i<length; i++)
            {
                Console.Write($"{path[i]} ");
                Console.WriteLine();
            }
        }
    }
}
