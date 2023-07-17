using DataStructures.Stack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataStructures.Tree.BinaryTree
{
    public class BinaryTree<T> where T : IComparable
    {
        public Node<T> Root { get; set; }
        public List<Node<T>> list;
        public BinaryTree()
        {
            list = new List<Node<T>>();
        }
        public List<Node<T>> InOrder(Node<T> root) // Left Data Right şeklinde ağaçta dolanılacak.
        {
            if (!(root == null)) //root null olmadığı sürece dolaşılıcak
            {
                InOrder(root.LeftNode);  //Sol düğümden devam edeceğiz .
                list.Add(root); // Datayı yazıcaz.
                InOrder(root.RightNode); //sağ düğümden devam edicez
            }
            return list;
        }
        public List<Node<T>> InOrderNonRecursive(Node<T> root)
        {
            var list = new List<Node<T>>();
            var stack = new Stack.Stack<Node<T>>();
            Node<T> currentNode = root;
            bool done = false;
            while (!done)
            {
                if (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.LeftNode;
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        done = true;
                    }
                    else
                    {
                        currentNode = stack.Pop();
                        list.Add(currentNode);
                        currentNode = currentNode.RightNode;
                    }
                }

            }
            return list;

        }
        public List<Node<T>> PreOrder(Node<T> root)// Data Left Right şeklinde ağaçta dolanılacak.
        {
            if (!(root == null))
            {
                list.Add(root);
                PreOrder(root.LeftNode);
                PreOrder(root.RightNode);
            }
            return list;
        }
        public List<Node<T>> PreOrderNonRecursive(Node<T> root)
        {
            var list = new List<Node<T>>();
            if (root == null)
            {
                throw new Exception("Empty Tree!");
            }
            else
            {
                var stack = new Stack.Stack<Node<T>>();
                stack.Push(root);
                while (!(stack.Count == 0))
                {
                    var temp = stack.Pop();
                    list.Add(temp);
                    if (temp.RightNode != null)
                    {
                        stack.Push(temp.RightNode);
                    }
                    if (temp.LeftNode != null)
                    {
                        stack.Push(temp.LeftNode);
                    }
                }
            }
            return list;
        }
        public List<Node<T>> PostOrder(Node<T> root) // Left Right Data şeklinde ağaçta dolanılacak.
        {
            if (!(root == null))
            {
                PostOrder(root.LeftNode);
                PostOrder(root.RightNode);
                list.Add(root);
            }
            return list;
        }
        public List<Node<T>> PostOrderNonRecursive(Node<T> root)
        {

            var list = new List<Node<T>>();
            var stack = new Stack.Stack<Node<T>>();
            stack.Push(root);
            var outstack = new Stack.Stack<Node<T>>();
            while(stack.Count != 0)
            {
                Node<T> currentNode = stack.Pop();
                outstack.Push(currentNode);
                if(currentNode.LeftNode != null)
                {
                    stack.Push(currentNode.LeftNode);
                }
                if(currentNode.RightNode != null)
                {
                    stack.Push(currentNode.RightNode);
                }
            }
            while(outstack.Count != 0)
            {
                var listNode = outstack.Pop();
                list.Add(listNode);
            }
            return list;

        }
        public List<Node<T>> LevelOrderNonRecursive(Node<T> root)  //Levele göre ağaçta dolanılacak.
        {
            var list = new List<Node<T>>();
            if (root == null)
            {
                throw new Exception("Empty Tree");
            }
            else
            {
                var queue = new Queue.Queue<Node<T>>();
                queue.EnQueue(root);
                while (!(queue.Count == 0))
                {
                    var temp = queue.DeQueue();
                    list.Add(temp);
                    if (temp.LeftNode != null)
                    {
                        queue.EnQueue(temp.LeftNode);
                    }
                    if (temp.RightNode != null)
                    {
                        queue.EnQueue(temp.RightNode);
                    }
                }

            }
            return list;
        }
        public static int MaxDepth(Node<T> root) // Max derinlik bulma
        {
            if (root == null)
            {
                return 0;
            }
            int LeftDepth = MaxDepth(root.LeftNode);
            int RightDepth = MaxDepth(root.RightNode);

            return (LeftDepth > RightDepth) ? LeftDepth + 1 : RightDepth + 1;
        }
        public Node<T> DeepstNode(Node<T> root)
        {
            Node<T> temp = null;
            if (root == null)
            {
                throw new Exception("Empty Tree");
            }

            var queue = new Queue.Queue<Node<T>>();
            queue.EnQueue(root);
            while (queue.Count > 0)
            {
                temp = queue.DeQueue();
                if (temp.LeftNode != null)
                {
                    queue.EnQueue(temp.LeftNode);
                }
                if (temp.RightNode != null)
                {
                    queue.EnQueue(temp.RightNode);
                }
            }
            return temp;
        }  //En alttaki Node
        public Node<T> DeepstNode()
        {
            var list = LevelOrderNonRecursive(Root);
            return list[list.Count - 1];

        }
        public int NumberOfLeafs(Node<T> root) //Yaprak node sayısı
        {
            int count = 0;
            if (root == null)
            {
                return count;
            }
            var queue = new Queue.Queue<Node<T>>();
            queue.EnQueue(root);
            while (queue.Count > 0)
            {
                var temp = queue.DeQueue();
                if (temp.LeftNode == null && temp.RightNode == null)
                {
                    count++;
                }
                if (temp.LeftNode != null)
                {
                    queue.EnQueue(temp.LeftNode);
                }
                if (temp.RightNode != null)
                {
                    queue.EnQueue(temp.RightNode);
                }
            }
            return count;
        }
        public int NumberOfLeafs()
        {
            return new BinaryTree<T>().LevelOrderNonRecursive(Root).Where(x => x.LeftNode == null && x.RightNode == null).ToList().Count; //Alınan örnek Node sol ve sağ çocuğu boş ise yeni liste solnuştur ve Count değerini dönder.
        }
        public static int NumberOfFullNode(Node<T> root) => new BinaryTree<T>().LevelOrderNonRecursive(root)
            .Where(x => x.LeftNode != null && x.RightNode != null).ToList().Count;
        public static int NumberOfHalfNode(Node<T> root) => new BinaryTree<T>().LevelOrderNonRecursive(root)
            .Where(x => (x.LeftNode != null && x.RightNode == null) || (x.LeftNode == null && x.RightNode != null)).ToList().Count;
        public void PrintPaths(Node<T> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException("");
            }
            var paths = new T[256];
            PrintPaths(root, paths, 0);
        }
        private void PrintPaths(Node<T> root, T[] path, int pathLen)
        {
            if(root == null)
            {
                return;
            }
            path[pathLen] = root.Value;
            pathLen++;

            if(root.LeftNode == null && root.RightNode == null)
            {
                PrintArray(path, pathLen);
            }
            else
            {
                PrintPaths(root.LeftNode, path, pathLen);
                PrintPaths(root.RightNode, path, pathLen);
            }
        } //Yolları yazdırıyoruz .
        private void PrintArray(T[] path, int len)
        {
            Console.Write("Yol :");
            for (int i = 0; i < len; i++)
            {
                Console.Write($" {path[i]} ");
            }
            Console.WriteLine("");
        } //Diziyi yazdırıyoruz .

        public void ClearNodeList() => list.Clear();

    }
}
