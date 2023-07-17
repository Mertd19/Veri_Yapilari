using CustomTypes;
using DataStructures.SortingAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    public class Students
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Array");

            var arr = new Student[]
            {
                new Student(10, "Mert", 3.02),
                new Student(15,"Dilan",2.80),
                new Student(7,"Serhat",3.12),
                new Student(9,"Yakup",2.50),
                new Student(11,"Batuhan",3.80),
            };

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }

            var newArr = new DataStructures.Array.Array<Student>(arr);

            newArr.Add(new Student(22, "Öykü", 3.5));

            Console.WriteLine("Yeni kayıt yapıldı.!");
            foreach (var item in newArr)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("SinglyLinked List");

            var linkedlist = new DataStructures.LinkedList.SinglyLinkedList.SinglyLinkedList<Student>(newArr);
            foreach (var item in linkedlist)
            {
                Console.WriteLine(item);
            }

            linkedlist.AddFirst(new Student(5, "Ozan", 2.98));

            Console.WriteLine("Yeni kayıt yapıldı.!");
            foreach (var item in linkedlist)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Binary Search Tree");

            var bst = new DataStructures.Tree.BinarySearchTree.BinarySearchTree<Student>(linkedlist);
            foreach (var item in bst)
            {
                Console.WriteLine(item);
            }

            bst.Add(new Student(3, "Burak", 3.25));

            Console.WriteLine("Yeni kayıt yapıldı.!");
            foreach (var item in bst)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("MinHeap");

            var minHeap = new DataStructures.Heap.MinHeap<Student>(bst);
            foreach (var item in minHeap)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("MaxHeap");
            var maxHeap = new DataStructures.Heap.BHeap<Student>(DataStructures.Shared.SortDirection.Descending,bst);
            foreach (var item in maxHeap)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Bubble Sort");

            BubbleSort.Sort<Student>(arr);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Insertion Sort");

            InsertionSort.Sort<Student>(arr,DataStructures.Shared.SortDirection.Descending);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }


            Console.ReadKey();
        }
    }
}
