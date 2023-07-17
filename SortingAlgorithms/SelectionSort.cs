using DataStructures.SortingAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionSort
{
    public class SelectionSort
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 16, 40, 44, 12, 55, 19, 6 };
            foreach (var item in arr)
            {
                Console.Write($"{item,-5}");
            }
            Console.WriteLine();

            //Selection Sort
            Console.WriteLine("\nSelection Sort Küçük -> Büyük ");
            DataStructures.SortingAlgorithms.SelectionSort.Sort<int>(arr);
            foreach (var item in arr)
            {
                Console.Write($"{item,-5}");
            }

            Console.WriteLine("\nSelection Sort Büyük -> Küçük");
            DataStructures.SortingAlgorithms.SelectionSort.Sort<int>(arr, DataStructures.Shared.SortDirection.Descending);
            foreach (var item in arr)
            {
                Console.Write($"{item,-5}");
            }

            Console.WriteLine("\nSelection Sort Küçük -> Büyük ");
            DataStructures.SortingAlgorithms.SelectionSort.Sort<int>(arr, DataStructures.Shared.SortDirection.Asceding);
            foreach (var item in arr)
            {
                Console.Write($"{item,-5}");
            }

            Console.ReadKey();
        }
    }
}
