using DataStructures.LinkedList.DoublyLinkedList;

namespace DataStructures.Queue
{
    public class LinkedListQueue<T> : IQueue<T>
    {
        public int Count { get; private set; }
        private readonly DoublyLinkedList<T> list = new DoublyLinkedList<T>();

        public T DeQueue()
        {
            if (Count == 0)
            {
                throw new Exception("Empty Queue!");
            }
            var temp = list.RemoveLast();
            Count--;
            return temp;
        }

        public void EnQueue(T value)
        {
            if(value == null)
            {
                throw new ArgumentNullException();
            }
            list.AddFirst(value);
            Count++;
        }

        public T Peek() => Count == 0 ? throw new Exception("Empty Queue!") : list.Tail.Value; // Count 0'sa hata mesajını değilse Head'ın value değerini döndür.
       
    }
}