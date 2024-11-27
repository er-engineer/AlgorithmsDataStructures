using DataStructures.Array;
using DataStructures.LinkedList.SinglyLinkedList;

namespace Apps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 1,2,3,4,5,6};
            var linkedlist = new SinglyLinkedList<int>(array);
            linkedlist.Remove();
            foreach (var item in linkedlist)
            {
                Console.WriteLine(item);
            }
        }
    }
}
