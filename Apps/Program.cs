using DataStructures.Array;
using DataStructures.LinkedList.DoublyLinkedList;
using DataStructures.LinkedList.SinglyLinkedList;
using DataStructures.Tree.BinarySearchTree;
using DataStructures.Tree.BinaryTree;

namespace Apps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var binarySearchTree = new BinarySearchTree<int>(new int[] { 23, 16, 45, 3, 22, 37, 99 });
            var nodeList = new BinaryTree<int>().InOrder(binarySearchTree.Root);
            foreach (var node in nodeList)
            {
                Console.WriteLine(node.Value);
            }
        }
    }
}
