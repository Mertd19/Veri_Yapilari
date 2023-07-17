using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedListNode<T>
    {
        public SinglyLinkedListNode<T> Next { get; set; }
        public T value { get; set; }

        public SinglyLinkedListNode(T value)
        {
            this.value = value;
        }
        public override string ToString()
        {
            return $"{value}";
        }
    }
}
