using DataStructures.LinkedList.SinglyLinkedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SinglyLinkedList
{
    public class SinglyLinkedList
    {
        static void Main(string[] args)
        {

            var rnd = new Random();
            var initial = Enumerable.Range(1, 10).OrderBy(x => rnd.Next()).ToList();
            var lList = new SinglyLinkedList<int>(initial);

            lList.Listening();

            var q = from item in lList where item % 2 == 1 select item;

            lList.Where(x =>  x % 5 == 0).ToList().ForEach(x => Console.Write(x + " "));
            Console.WriteLine();

            foreach (var item in q)
            {
                Console.WriteLine(item);
            }


            var linkedList = new SinglyLinkedList<int>();
            var newNode = new SinglyLinkedListNode<int>(14);
            var newNodee = new SinglyLinkedListNode<int>(95);
            linkedList.AddFirst(12);  //Head -> 12 -> null
            linkedList.Listening();
            linkedList.AddFirst(15);  //Head -> 15 -> 12 -> null
            linkedList.Listening();
            linkedList.AddFirst(18);  //Head -> 18 -> 15 -> 12 -> null
            linkedList.Listening();
            linkedList.AddLast(13);   //Head -> 18 -> 15 -> 12 -> 13 -> null
            linkedList.Listening();
            linkedList.AddAfter(linkedList.Head.Next, 11); //Head-> 18-> 15 -> 11 -> 12 -> 13 -> null
            linkedList.Listening();
            linkedList.AddBefore(linkedList.Head.Next, 9); //Head -> 18 -> 9 -> 15 -> 11 -> 12 -> 13 -> null
            linkedList.Listening();
            linkedList.Remove(linkedList.Head.Next.Next); //Head -> 18 -> 9 -> 11 -> 12 -> 13 -> null
            linkedList.Listening();
            linkedList.RemoveLast();  //Head -> 18 -> 9 -> 11 -> 12 -> null
            linkedList.Listening();
            linkedList.RemoveFirst();  //Head -> 9 -> 11 -> 12 -> null
            linkedList.Listening();
            linkedList.AddAfter(linkedList.Head.Next, newNode); //Head -> 9 -> 11 -> 14 -> 12 -> null
            linkedList.Listening();
            linkedList.AddBefore(linkedList.Head.Next.Next, newNodee);  //Head -> 9 -> 11 -> 95 -> 14 -> 12 -> null
            linkedList.Listening();
            linkedList.Remove(95); //Head -> 9 -> 11 -> 14 -> 12 -> null
            linkedList.Listening();
            linkedList.Remove(9); //Head -> 9 -> 11 -> 14 -> 12 -> null
            linkedList.Listening();

            Console.ReadKey();
        }
    }
}