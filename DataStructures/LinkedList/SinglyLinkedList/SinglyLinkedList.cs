using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructures.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        public SinglyLinkedList()
        {
        }
        public SinglyLinkedList(IEnumerable<T> collection) 
        {
            foreach (var item in collection)
            {
                this.AddLast(item);
            }
        }
        public SinglyLinkedListNode<T> Head { get; set; }

        public bool isHeadNull => Head == null;

        public void AddFirst(T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);
            newNode.Next = Head;
            Head = newNode;
        } //Başa ekleme

        public void AddLast(T value)
        {
            var current = Head;
            var newNode = new SinglyLinkedListNode<T>(value);
            if (isHeadNull)
            {
                Head = newNode;
                return;
            }
            while (current.Next != null)
            {
                current = current.Next;
            }
            var prev = current;
            prev.Next = newNode;
            newNode.Next = null;
        } //Sona ekleme 

        public void AddAfter(SinglyLinkedListNode<T> node, T value)
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

            var newNode = new SinglyLinkedListNode<T>(value);
            var current = Head;
            while (current != null)
            {
                if (current.Equals(node))
                {
                    var prev = current;
                    newNode.Next = prev.Next;
                    prev.Next = newNode;
                    return;
                }
                current = current.Next;
            }
        } //Düğümden sonraya ekleme 

        public void AddAfter(SinglyLinkedListNode<T> refNode, SinglyLinkedListNode<T> newNode)
        {
            var current = Head;

            if (refNode == null)
            {
                throw new ArgumentNullException();
            }
            if (isHeadNull)
            {
                Head = newNode;
                return;
            }

            while (current != null)
            {
                if (current.Equals(refNode))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
            }
        }

        public void AddBefore(SinglyLinkedListNode<T> node, T value)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }

            if (isHeadNull)
            {
                throw new ArgumentNullException();
            }

            var newNode = new SinglyLinkedListNode<T>(value);
            var current = Head;
            while (current != null)
            {
                if (current.Next.Equals(node))
                {
                    var prev = current;
                    newNode.Next = prev.Next;
                    prev.Next = newNode;
                    return;
                }
                current = current.Next;
            }
        } //Düğümden önceye ekleme 

        public void AddBefore(SinglyLinkedListNode<T> refNode, SinglyLinkedListNode<T> newNode)
        {
            if (isHeadNull || refNode == null)
            {
                throw new ArgumentNullException();
            }

            var current = Head;
            while (current != null)
            {
                if(current.Next.Equals(refNode))
                {
                    var prev = current;
                    var temp = refNode.Next;
                    newNode.Next = prev.Next;
                    prev.Next = newNode;
                    return;
                }
                current = current.Next;
            }

        }

        public T RemoveFirst()
        {
            if (isHeadNull)
            {
                throw new Exception("Silinebilecek eleman yok!");
            }

            var current = Head;
            if(Head.Next == null) // Listedeki tek düğüm Head ise 
            {
                Head = null;
                return current.value;
            }

            var firstValue = Head.value;
            Head = Head.Next;
            return firstValue;
        } //Başlangıç düğümü silme

        public T RemoveLast()
        {
            if (isHeadNull)
            {
                throw new Exception("Silinebilecek eleman yok!");
            }

            var current = Head;
            if (Head.Next == null) // Listedeki tek düğüm Head ise 
            {
                Head = null;
                Console.WriteLine($"{current.value} düğümü listeden kaldırıldı. Listede artık düğüm yok !!");
                return current.value;
            }

            SinglyLinkedListNode<T> prev = null;
            while (current.Next != null)
            {
                prev = current;     //Prev hep önceki elemanı tutuyor.
                current = current.Next;  //Current prevden sonraki eleman . (Başlangıçta istisna durum.)
            }
            var lastValue = prev.Next.value;
            prev.Next = null;
            return lastValue;
        } // Son düğümü silme 

        public void Remove(SinglyLinkedListNode<T> node)
        {
            if (node == null)
            {
                throw new Exception("Silinecek eleman listede yok!");
            }
            if (isHeadNull)
            {
                throw new Exception("Silinebilecek eleman yok!");
            }

            var current = Head;
            SinglyLinkedListNode<T> prev = null;
            while (current != null)
            {
                if (current.Equals(node))
                {
                    if (current.Next == null) //Son elemanmı kontrolü yapıyoruz !!
                    {
                        if(prev == null) //Listedeki tek elemanmı diye kontrol ediyoruz !!
                        {
                            Head = null;
                            Console.WriteLine($"{current.value} düğümü listeden kaldırıldı. Liste boş !!");
                            return;
                        }
                        else //Son eleman olduğunu anlıyoruz.
                        {
                            prev.Next = null;
                            Console.WriteLine($"{current.value} düğümü listeden kaldırıldı.");
                            return;
                        }
                    }
                    else
                    {
                        if(prev == null) //Head düğümü silinmek isteniyorsa !!
                        {
                            var temp = Head.value;
                            Head = Head.Next;
                            Console.WriteLine($"{temp} düğümü listeden kaldırıldı.");
                            return;
                        }
                        else
                        {
                            prev.Next = current.Next;
                            Console.WriteLine($"{node.value} düğümü listeden kaldırıldı.");
                            return;
                        }
                    }
                    
                }
                prev = current;
                current = current.Next;
            }
            Console.WriteLine("Aranan Node listede yok");
        } //Aradan düğüm silme 

        public void Remove(T value)
        {
            if (value == null)
            {
                throw new Exception("Silinecek eleman listede yok!");
            }
            if (isHeadNull)
            {
                throw new Exception("Silinebilecek eleman yok!");
            }

            var current = Head;
            SinglyLinkedListNode<T> prev = null;
            while (current != null)
            {
                if (current.value.Equals(value))
                {
                    if(current.Next == null) //Son elemanmı diye kontrol ediyoruz !!
                    {
                        if(prev == null)
                        {
                            Head = null;
                            Console.WriteLine($"{current.value} düğümü listeden kaldırıldı. Liste Boş !!!");
                            return;
                        }
                        else
                        {
                            prev.Next = null;
                            Console.WriteLine($"{current.value} düğümü listeden kaldırıldı.");
                            return;
                        }
                    }
                    else
                    {
                        if(prev == null)
                        {
                            Head = Head.Next;
                            Console.WriteLine($"{current.value} düğümü listeden kaldırıldı.");
                            return;
                        }
                        else
                        {
                            prev.Next = current.Next;
                            Console.WriteLine($"{current.value} düğümü listeden kaldırıldı.");
                            return;
                        }
                    }
                   
                }
                prev = current;
                current = current.Next;
            }
            Console.WriteLine("Aranan Eleman listede yok");
        }
        public void Listening()
        {
            var current = Head;
            Console.WriteLine("Liste: ");
            if(Head != null)
            {
                Console.Write("Head -> ");
                while (current != null)
                {
                    Console.Write(current.value + " -> ");
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

        public IEnumerator<T> GetEnumerator()
        {
            return new SinglyLinkedListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
