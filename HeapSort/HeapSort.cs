using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSort
{
    public class HeapSort
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 16, 40, 44, 12, 55, 19, 6 };
            foreach (var item in arr)
            {
                Console.Write($"{item,-5}");
            }
            Console.WriteLine();

            //Heap Sort
            Console.WriteLine("\nHeap Sort Küçük -> Büyük ");
            var heapkb = new DataStructures.Heap.MinHeap<int>(arr);
            foreach (var item in heapkb)
            {
                Console.Write($"{heapkb.DeleteMinMax(),-5}");
            }
            Console.WriteLine();
            Console.WriteLine("\nHeap Sort Büyük -> Küçük ");
            var heapbk = new DataStructures.Heap.MaxHeap<int>(arr);
            foreach (var item in heapbk)
            {
                Console.Write($"{heapbk.DeleteMinMax(),-5}");
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
