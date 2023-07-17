using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.DoublyLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable
    {
        public DoublyLinkedListNode<T> Head { get; set; }
        public DoublyLinkedListNode<T> Tail { get; set; }
        public bool isHeadNull => Head == null;
        public bool isTailNull => Tail == null;

        public DoublyLinkedList()
        {

        }

        public DoublyLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                this.AddLast(item);
            }
        }
        public void AddFirst(T value)
        {
            var newNode = new DoublyLinkedListNode<T>(value);
            if (Head != null)
            {
                Head.Prev = newNode;
            }

            newNode.Next = Head;
            Head = newNode;

            if (Tail == null)
            {
                Tail = Head;
            }
        }

        public void AddLast(T value)
        {
            if (Tail == null)
            {
                AddFirst(value);
                return;
            }
            var newNode = new DoublyLinkedListNode<T>(value);
            Tail.Next = newNode;
            newNode.Prev = Tail;
            Tail = newNode;
            return;
        }

        public void AddAfter(DoublyLinkedListNode<T> node, T value)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }

            if (isHeadNull)
            {
                AddFirst(value);
                return;
            }

            var newNode = new DoublyLinkedListNode<T>(value);
            var current = Head;
            while (current != null)
            {
                var temp = current.Next;
                if (current.Equals(node))
                {
                    if (temp == null)
                    {
                        AddLast(value);
                        return;
                    }

                    newNode.Next = temp;
                    newNode.Prev = current;
                    temp.Prev = newNode;
                    current.Next = newNode;
                    return;

                }
                current = current.Next;
            }
        }

        public void AddAfter(DoublyLinkedListNode<T> refNode,DoublyLinkedListNode<T> newNode)
        {
            if (refNode == null)
            {
                throw new ArgumentNullException();
            }
            if (isHeadNull)
            {
                Head = newNode;
                Tail = newNode;
                return;
            }
            var current = Head;
            while(current != null)
            {
                var temp = current.Next;
                if (current.Equals(refNode))
                {
                    if(temp == null)
                    {
                        newNode.Prev = current;
                        newNode.Next = null;
                        current.Next = newNode;
                        Tail = newNode;
                        return;
                    }
                    newNode.Prev = current;
                    newNode.Next = temp;
                    current.Next = newNode;
                    temp.Prev = newNode;
                    return;
                }
                current = current.Next;
            }
        }

        public void AddBefore(DoublyLinkedListNode<T> node, T value)
        {
            if (isHeadNull || node == null)
            {
                throw new ArgumentNullException();
            }

            var current = Head;
            var newNode = new DoublyLinkedListNode<T>(value);

            while (current != null)
            {
                var temp = current.Prev;
                if (current.Equals(node))
                {
                    newNode.Next = current;
                    newNode.Prev = temp;
                    temp.Next = newNode;
                    current.Prev = newNode;
                    return;
                }
                current = current.Next;
            }
        }

        public void AddBefore(DoublyLinkedListNode<T> refNode,DoublyLinkedListNode<T> newNode)
        {
            if(isHeadNull || refNode == null)
            {
                throw new ArgumentNullException();
            }

            var current = Head;
            while (current != null)
            {
                var temp = current.Prev;
                if(current.Equals(refNode))
                {
                    newNode.Next = current;
                    newNode.Prev = temp;
                    temp.Next = newNode;
                    current.Prev = newNode;
                    return;
                }
                current = current.Next;
            }
        }

        public T RemoveFirst()
        {
            if (isHeadNull)
            {
                throw new ArgumentNullException();
            }
            if(Head == Tail)
            {
                var temp = Head;
                Head = null;
                Tail = null;
                Console.WriteLine($"{temp.Value} düğümü listeden kaldırıldı. Listede artık düğüm yok !! ");
                return temp.Value;
            }

            var firstValue = Head.Value;
            Head = Head.Next;
            Head.Prev = null;
            return firstValue;
        } 

        public T RemoveLast()
        {
            if (isTailNull)
            {
                throw new ArgumentNullException();
            }

            if (Head == Tail)
            {
                var tmp = Head;
                Head = null;
                Tail = null;
                Console.WriteLine($"{tmp.Value} düğümü listeden kaldırıldı. Listede artık düğüm yok !!");
                return tmp.Value;
            }

            var lastValue = Tail.Value;
            var temp = Tail.Prev;
            temp.Next = null;
            Tail = temp;
            return lastValue;
        }

        public void Remove(DoublyLinkedListNode<T> refNode)
        {
            if (refNode == null)
            {
                throw new ArgumentNullException();
            }
            if (isHeadNull)
            {
                throw new ArgumentNullException();
            }

            var current = Head;
            while(current != null)
            {
                if (current.Equals(refNode))
                {
                    if (current == Tail) //Son elemanmı kontrolü
                    {
                        if (Head == Tail) //Listedeki tek eleman mı kontrolü
                        {
                            Head = null;
                            Tail = null;
                            Console.WriteLine($"{current.Value} düğümü listeden kaldırıldı. Listede artık düğüm yok !! ");
                            return;
                        }
                        else  // Son eleman olduğunu anladık.
                        {
                            var temp = current.Prev;
                            temp.Next = null;
                            Tail = temp;
                            Console.WriteLine($"{current.Value} düğümü listeden kaldırıldı.");
                            return;
                        }
                    }
                    else
                    {
                        if(current == Head)
                        {
                            var temp = Head.Value;
                            Head = Head.Next;
                            Head.Prev = null;
                            Console.WriteLine($"{temp} düğümü listeden kaldırıldı.");
                            return;
                        }
                        else
                        {
                            var after = current.Next;
                            var before = current.Prev;
                            after.Prev = before;
                            before.Next = after;
                            Console.WriteLine($"{refNode.Value} düğümü listeden kaldırıldı.");
                            current = null;
                            return;
                        }
                    }
                }
                current = current.Next;
            }


        }

        private List<DoublyLinkedListNode<T>> GetAllNodes()
        {
            var list = new List<DoublyLinkedListNode<T>>();
            var current = Head;
            while (current != null)
            {
                list.Add(current);
                current = current.Next;
            }
            return list;
        }

        public void Listening()
        {
            var current = Head;
            Console.WriteLine("Liste: ");
            if (Head != null)
            {
                Console.Write("Head -> ");
                while (current != null)
                {
                    Console.Write(current.Value + " -> ");
                    current = current.Next;
                }
                Console.Write("null");
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine("Head -> null (Liste Boş)");
            }
        }

        public IEnumerator GetEnumerator()
        {
            return GetAllNodes().GetEnumerator();
        }
    }

   
}
