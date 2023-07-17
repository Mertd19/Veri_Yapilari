using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisjointSet
{
    public  class DisjointSet
    {
        static void Main(string[] args)
        {
            int[] dizi = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
            var disjointSet = new DataStructures.Set.DisjointSet<int>(dizi);

            disjointSet.UnionSet(5, 7); // 7 -> 5 olucak
            disjointSet.UnionSet(1, 2); // 2 -> 1 olucak
            disjointSet.UnionSet(0, 2); // 2 -> 1 rankı daha büyük birleşmede 0 -> 1 ve 2 -> 1 olucak.
            disjointSet.UnionSet(4, 7); // 7 -> 5 rankı daha büyük birleşmede 4 -> 5 ve 7 -> 5 olucak.
            for (int i = 0; i < dizi.Length; i++)
            {
                Console.WriteLine($"Find({i}) = {disjointSet.FindSet(i)}");
            }

            Console.ReadKey();
        }
    }
}
