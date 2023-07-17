using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tree.BinaryTree;

namespace DataStructures.Tree.BinarySearchTree
{
    public class BinarySearchTree<T> : IEnumerable<T> where T : IComparable
    {
        public Node<T> Root { get; set; }
        public BinarySearchTree()
        {
            
        }
        public BinarySearchTree(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public void Add(T value) //Ekleme
        {
            if (value == null)
            {
                throw new ArgumentNullException("");
            }

            var newNode = new Node<T>(value);

            if(Root == null)
            {
                Root = newNode;
            }
            else
            {
                var current = Root;
                Node<T> parent;
                while (true)
                {
                    parent = current;
                    //Sol alt ağaç 
                    if (value.CompareTo(current.Value)<0) //CompareTo 3 sonuç -1 0 1 : -1 küçük : 0 eşit : 1 büyük
                    {
                        current = current.LeftNode;
                        if (current == null)
                        {
                            parent.LeftNode = newNode;
                            break;
                        }
                    }
                    //Sağ alt ağaç
                    else
                    {
                        current = current.RightNode;
                        if(current == null)
                        {
                            parent.RightNode = newNode;
                            break;
                        }

                    }
                }
            }
        } 

        public Node<T> FindMin(Node<T> root)
        {
            var current = root;
            while(current.LeftNode != null)
            {
                current = current.LeftNode;
            }
            return current;
        } //En küçük elemanı bulma 
        public Node<T> FindMax(Node<T> root)
        {
            var current = root;
            while( current.RightNode != null)
            {
                current = current.RightNode;
            }
            return current;
        } //En büyük elemanı bulma 
        public Node<T> Find(Node<T> root,T key)
        {
            var current = root;
            while (key.CompareTo(current.Value)!=0) //current değeri büyükse -1 , küçükse 1 , eşitse 0 değeri döner.
            {
                if (key.CompareTo(current.Value) < 0)
                {
                    current = current.LeftNode;
                }
                else
                {
                    current = current.RightNode;
                }
                if(current == null)
                {
                    return default(Node<T>);
                }
            }
            return current;
        } //Key değerini arama
        public Node<T> Remove(Node<T> root,T value) //Silme
        {
            if (root == null)
            {
                throw new Exception("Empty Tree");
            }
            //Rekürsif ilerleme yapılcak.

            if(value.CompareTo(root.Value) < 0) //Silinecek eleman o anki Node'dan küçükse  
            {
                root.LeftNode = Remove(root.LeftNode, value);
            }
            else if(value.CompareTo(root.Value) > 0)  //Silinecek eleman o anki Node'dan büyükse  
            {
                root.RightNode = Remove(root.RightNode, value);
            }
            //Elemanı bulduk silme işlemi uygulanıcak
            else
            {
                //Tek çocuk var ise yada çocuk yok ise
                if(root.LeftNode == null)
                {
                    return root.RightNode;
                }
                else if(root.RightNode == null)
                {
                    return root.LeftNode;
                }
                //İki çocuğu var ise Sağ ağacın en küçük elamanı silenen eleman yerine yazılıyor.
                root.Value = FindMin(root.RightNode).Value; 
                root.RightNode = Remove(root.RightNode, root.Value);
            }
            return root;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new BSTEnumerator<T>(Root);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
