using DataStructures.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class Queue
    {
        private int expression;
        static void Main(string[] args)
        {
            var intset = new int[] { 11, 12, 13, 14, 15 };
            var queue1 = new DataStructures.Queue.Queue<int>();
            var queue2 = new DataStructures.Queue.Queue<int>(QueueType.LinkedList);

            foreach (var c in intset)
            {
                Console.WriteLine(c);
                queue1.EnQueue(c);
                queue2.EnQueue(c);
            }

            Console.WriteLine("\nPeek");
            Console.WriteLine($"Stack1 : {queue1.Peek()} ");
            Console.WriteLine($"Stack2 : {queue2.Peek()} ");

            Console.WriteLine("\nCount");
            Console.WriteLine($"Stack1 : {queue1.Count} ");
            Console.WriteLine($"Stack2 : {queue2.Count} ");

            Console.WriteLine("\nDeQueue");
            Console.WriteLine($"Stack1 : {queue1.DeQueue()} ");
            Console.WriteLine($"Stack2 : {queue2.DeQueue()} ");

            Console.WriteLine("\nCount");
            Console.WriteLine($"Stack1 : {queue1.Count} ");
            Console.WriteLine($"Stack2 : {queue2.Count} ");

            Console.WriteLine("\nPeek");
            Console.WriteLine($"Stack1 : {queue1.Peek()} ");
            Console.WriteLine($"Stack2 : {queue2.Peek()} ");


        }
    }
}
