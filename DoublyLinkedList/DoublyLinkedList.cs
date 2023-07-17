using System;
using DataStructures.LinkedList.DoublyLinkedList;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
    public class DoublyLinkedList
    {
        static void Main(string[] args)
        {
            var linkedlist = new DoublyLinkedList<int>();
            linkedlist.AddFirst(16); //Head -> 16 -> null (Head düğümüne ekleme)
            linkedlist.Listening();
            linkedlist.AddFirst(12);  //Head -> 12 -> 16 -> null (Head düğümüne ekleme)
            linkedlist.Listening();
            linkedlist.AddAfter(linkedlist.Head, 14); //Head -> 12 -> 14 -> 16 -> null (Head sonrasına ekleme)
            linkedlist.Listening();
            linkedlist.AddAfter(linkedlist.Head, new DoublyLinkedListNode<int>(13)); //Head -> 12 -> 13 -> 14 -> 16 -> null (Head düğümünden sonra ekleme)
            linkedlist.Listening();
            linkedlist.AddLast(18); //Head -> 12 -> 13 -> 14 -> 16 -> 18 -> null (Liste sonuna ekleme)
            linkedlist.Listening();
            linkedlist.AddBefore(linkedlist.Tail, 17); //Head-> 12 -> 13 -> 14 -> 16 -> 17 -> 18 -> null (Liste sonundan öncesine ekleme)
            linkedlist.Listening();
            linkedlist.AddBefore(linkedlist.Head.Next.Next.Next, new DoublyLinkedListNode<int>(15)); //Head-> 12 -> 13 -> 14 -> 15 -> 16 -> 17 -> 18 -> null (16 düğümünden önce ekleme)
            linkedlist.Listening();
            linkedlist.Remove(linkedlist.Head.Next.Next); 
            linkedlist.Listening();

            Console.ReadKey();
        }
    }
}
