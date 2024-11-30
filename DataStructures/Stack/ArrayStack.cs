namespace DataStructures.Stack
{
    public class ArrayStack<T> : IStack<T>
    {
        public int Count { get; private set; }
        private readonly List<T> list = new List<T>();

        public void Clear()
        {
            list.Clear();
        }

        public T Peek()
        {
            if (Count == 0) throw new Exception("Stack is empty!");
            return list[list.Count - 1];
        }

        public T Pop()
        {
            if (Count == 0) throw new Exception("Stack is empty!");
            var result = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            Count--;
            return result;
        }

        public void Push(T item)
        {
            if(item == null) throw new ArgumentNullException("Item");
            list.Add(item);
            Count++;
        }
    }
}