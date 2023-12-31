﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.SortingAlgorithms
{
    public static class QuickSort
    {
        public static void Sort<T>(T[] array) where T: IComparable
        {
            Sort(array, 0, array.Length - 1);
        }
        private static void Sort<T>(T[] array,int lower,int upper) where T: IComparable
        {
            if (lower < upper)
            {
                int p = Partition(array, lower, upper);
                Sort<T>(array, lower, p);
                Sort<T>(array, p + 1, upper);
            }
        }
        private static int Partition<T>(T[] array,int lower,int upper) where T : IComparable
        {
            int i = lower;
            int j = upper;

            T pivot = array[lower];
            do
            {
                while (array[i].CompareTo(pivot) < 0)
                {
                    i++;
                } 
                while (array[j].CompareTo(pivot) > 0)
                {
                    j--;
                }
                if (i >= j)
                {
                    break;
                }
                Sorting.Swap(array, i, j);
            }
            while (i<=j);

            return j;
        }
    }
}
