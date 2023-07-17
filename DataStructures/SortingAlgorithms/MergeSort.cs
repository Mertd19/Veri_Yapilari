using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.SortingAlgorithms
{
    public class MergeSort
    {
        public static void Sort<T>(T[] array) where T: IComparable
        {
            Sort(array, 0, array.Length - 1);
        }

        private static void Sort<T>(T[] array,int left,int right) where T : IComparable
        {
            if (left < right)
            {
                int mid = (left + right) / 2;

                Sort(array, left, mid);
                Sort(array, mid + 1, right);
                Merge(array, left, mid, right);
            }
        }

        private static void Merge<T>(T[] array, int left, int mid, int right) where T : IComparable
        {
            T[] LeftArray = new T[mid - left + 1];
            T[] RightArray = new T[right - mid];

            System.Array.Copy(array, left, LeftArray, 0, mid - left + 1);
            System.Array.Copy(array, mid + 1, RightArray, 0, right - mid);

            int i = 0;
            int j = 0;

            for (int k = left; k < right + 1; k++)
            {
                if(i == LeftArray.Length)
                {
                    array[k] = RightArray[j];
                    j++;
                }
                else if (j == RightArray.Length)
                {
                    array[k] = LeftArray[i];
                    i++;
                }
                else if (LeftArray[i].CompareTo(RightArray[j]) < 0)
                {
                    array[k] = LeftArray[i];
                    i++;
                }
                else
                {
                    array[k] = RightArray[j];
                    j++;
                }
            }
        }
    }
}
