using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    public  class QuickSort
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 16, 40, 44, 12, 55, 19, 6 };
            foreach (var item in arr)
            {
                Console.Write($"{item,-5}");
            }
            Console.WriteLine();

            //Quick Sort
            Console.WriteLine("\nQuick Sort Küçük -> Büyük ");
            DataStructures.SortingAlgorithms.QuickSort.Sort<int>(arr);
            foreach (var item in arr)
            {
                Console.Write($"{item,-5}");
            }
            Console.ReadKey();
        }
    }
}
