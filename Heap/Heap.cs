using DataStructures.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class Heap
    {
        static void Main(string[] args)
        {
            int[] dizi = new int[] { 4, 1, 10, 8, 7, 5, 9, 3 };
            var minHeap = new DataStructures.Heap.MinHeap<int>(dizi);
            var maxHeap = new DataStructures.Heap.MaxHeap<int>(dizi);
            var maxheap = new DataStructures.Heap.BHeap<int>(SortDirection.Descending, dizi);
            var minheap = new DataStructures.Heap.BHeap<int>(SortDirection.Asceding, dizi);
            int sayi1 = 11;
            int sayi2 = 2;
            Console.Write("Dizi -> ");
            foreach(var item in dizi)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("\n");
            //Min Heap
            Console.WriteLine(minHeap.DeleteMinMax() + " has been removed.");

            Console.Write("Min Heap -> ");
            foreach (var item in minHeap)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine($"\n{sayi2} has been added");
            minHeap.Add(sayi2);
            Console.Write("Min Heap -> ");
            foreach (var item in minHeap)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("\n");

            Console.WriteLine(minheap.DeleteMinMax() + " has been removed.");
            Console.WriteLine($"{sayi2} has been added");
            minheap.Add(sayi2);

            Console.Write("Heap Min -> ");
            foreach (var item in minheap)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("\n");

            //Max Heap

            Console.WriteLine(maxHeap.DeleteMinMax() + " has been removed.");
            Console.Write("Max Heap -> ");
            foreach (var item in maxHeap)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine($"\n{sayi1} has been added");
            maxHeap.Add(sayi1);

            Console.Write("Max Heap -> ");
            foreach (var item in maxHeap)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("\n");

            Console.WriteLine(maxheap.DeleteMinMax() + " has been removed.");
            Console.WriteLine($"{sayi1} has been added");
            maxheap.Add(sayi1);
            Console.Write("Heap Max -> ");
            foreach (var item in maxheap)
            {
                Console.Write($"{item} ");
            }
            
            Console.ReadLine();
        }
    }
}
