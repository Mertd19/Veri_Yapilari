using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree.BinaryTree
{
    public class Node<T>
    {
        public T Value { get; set; }  //Node içindeki değer
        public Node<T> LeftNode { get; set; } //Sol çocuk   
        public Node<T> RightNode { get; set; } //Sağ çocuk
        public Node()
        {

        }
        public Node(T value)
        {
            Value = value;
        }
        public override string ToString()
        {
            return $"{Value}";
        } //Düğümü ekrana yazma
    }
}
