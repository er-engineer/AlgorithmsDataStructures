using DataStructures.Arrays;

namespace Apps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = new Array<int>(10,0,30,40,50,60);
            array.RemoveAt(2);
            
            foreach (var item in array)
                Console.WriteLine(item);
            
        }
    }
}
