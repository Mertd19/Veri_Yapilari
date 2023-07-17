namespace DataStructures.Queue
{
    public class ArrayQueue<T> : IQueue<T>
    {

        private readonly List<T> list = new List<T>();
        public int Count { get; private set; }

        public void EnQueue(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            list.Add(value);
            Count++;
        }

        public T DeQueue()
        {
            if(Count == 0)
            {
                throw new ArgumentException("Queue Boş!");
            }
            var temp = list[0];
            list.RemoveAt(0);
            Count--;
            return temp;
        }

        public T Peek() => Count == 0 ? throw new ArgumentException("Queue Boş!") : list[0];  // Count 0'sa hata mesajını değilse Dizinin ilk elemanının değerini döndür.
    }
}