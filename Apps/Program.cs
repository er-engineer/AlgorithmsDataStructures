using DataStructures.Arrays;

namespace Apps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = new Array<int>(1,2,3,4,5,6);
            array.Insert(3, 20);
            
            foreach (var item in array)
                Console.WriteLine(item);
            
        }
    }
}
