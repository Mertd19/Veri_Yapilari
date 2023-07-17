using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    public class BubbleSort
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 16, 40, 44, 12, 55, 19, 6 };
            foreach (var item in arr)
            {
                Console.Write($"{item,-5}");
            }
            Console.WriteLine();

            //Bubble Sort
            Console.WriteLine("\nBubble Sort Küçük -> Büyük ");
            DataStructures.SortingAlgorithms.BubbleSort.Sort<int>(arr);
            foreach (var item in arr)
            {
                Console.Write($"{item,-5}");
            }

            Console.WriteLine("\nBubble Sort Büyük -> Küçük");
            DataStructures.SortingAlgorithms.BubbleSort.Sort<int>(arr, DataStructures.Shared.SortDirection.Descending);
            foreach (var item in arr)
            {
                Console.Write($"{item,-5}");
            }

            Console.WriteLine("\nBubble Sort Küçük -> Büyük ");
            DataStructures.SortingAlgorithms.BubbleSort.Sort<int>(arr, DataStructures.Shared.SortDirection.Asceding);
            foreach (var item in arr)
            {
                Console.Write($"{item,-5}");
            }

            Console.ReadKey();
        }
    }
}
