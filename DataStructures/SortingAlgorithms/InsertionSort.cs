using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.SortingAlgorithms
{
    public class InsertionSort
    {
        public static void Sort<T>(T[] array) where T : IComparable
        {
            int i = 1;
            while (i < array.Length)
            {
                int j = i;
                while (j > 0 && (array[j - 1].CompareTo(array[j]) > 0))
                {
                    Sorting.Swap(array, j, j - 1);
                    j = j - 1;
                }
                i = i + 1;
            }
        }
        public static void Sort<T>(T[] array, Shared.SortDirection sortDirection = Shared.SortDirection.Asceding) where T : IComparable
        {
            var comparer = new Shared.CustomComparer<T>(sortDirection, Comparer<T>.Default);
            int i = 1;
            while (i < array.Length)
            {
                int j = i;
                while (j > 0 && comparer.Compare(array[j - 1], array[j]) > 0)
                {
                    Sorting.Swap(array, j, j - 1);
                    j = j - 1; 
                }
                i = i + 1;
            }
        }
    }
}
