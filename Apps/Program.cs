using DataStructures.Arrays;

namespace Apps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = new Array<int>(15,22,35,45,55,32,48);

            foreach (var item in array)
                Console.WriteLine(item);
            
        }
    }
}
