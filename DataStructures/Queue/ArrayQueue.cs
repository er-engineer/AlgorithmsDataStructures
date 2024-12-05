namespace DataStructures.Queue
{
    internal class ArrayQueue<T> : IQueue<T>
    {
        private readonly List<T> list = new List<T>();
        public int Count { get; private set; }

        public T DeQueue()
        {
            if (Count == 0) throw new Exception("Queue is empty!");
            var result = list[0];
            list.RemoveAt(0);
            Count--;
            return result;

        }

        public void EnQueue(T item)
        {
            if(item == null) throw new ArgumentNullException("Item");
            list.Add(item);
            Count++;
        }

        public T Peek()
        {
            if (Count == 0) throw new Exception("Queue is empty!");
            return list[0];
        }
    }
}