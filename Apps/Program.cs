using DataStructures.Array;
using DataStructures.LinkedList.DoublyLinkedList;
using DataStructures.LinkedList.SinglyLinkedList;

namespace Apps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new DoublyLinkedList<int>();
            linkedList.AddLast(15);
            linkedList.AddLast(25);
            linkedList.AddLast(45);
            linkedList.AddLast(455);
            linkedList.AddLast(65);

        }
    }
}
