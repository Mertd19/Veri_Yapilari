using DataStructures.Stack;
using DataStructures.Tree.BinarySearchTree;
using DataStructures.Tree.BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class Tree
    {
        static void Main(string[] args)
        {
            var BST = new BinarySearchTree<int>(new int[] {23,16,22,3,45,99,37});

            foreach(var node in BST)
            {
                Console.Write($"{node} ");
            }

            Console.WriteLine();

            var bt = new BinaryTree<int>();
            Console.WriteLine("InOrder : ");
            bt.InOrder(BST.Root).ForEach(node => Console.Write($"{node,-3} ")); //3 karakter boşluk bırak dedik. +1 de kendimiz verdik 4 karakterle ekrana basıcaz.
            Console.WriteLine("\nNon Recursive InOrder : ");
            bt.InOrderNonRecursive(BST.Root).ForEach(node => Console.Write($"{node,-3} "));
            bt.ClearNodeList();
            Console.WriteLine("\nPreOrder : ");
            bt.PreOrder(BST.Root).ForEach(node => Console.Write($"{node,-3} "));
            bt.ClearNodeList();
            Console.WriteLine("\nNon Recursive PreOrder : ");
            bt.PreOrderNonRecursive(BST.Root).ForEach(node => Console.Write($"{node,-3} "));
            bt.ClearNodeList();
            Console.WriteLine("\nPostOrder : ");
            bt.PostOrder(BST.Root).ForEach(node => Console.Write($"{node,-3} "));
            bt.ClearNodeList();
            Console.WriteLine("\nNon Recursive PostOrder : ");
            bt.PostOrderNonRecursive(BST.Root).ForEach(node => Console.Write($"{node,-3}"));
            bt.ClearNodeList();
            Console.WriteLine("\nNon Recursive LevelOrder : ");
            bt.LevelOrderNonRecursive(BST.Root).ForEach(node => Console.Write($"{node,-3}"));
            bt.ClearNodeList();
            Console.WriteLine($"\n\nEn küçük değer : {BST.FindMin(BST.Root)}");
            Console.WriteLine($"En büyük değer : {BST.FindMax(BST.Root)}");
            Console.WriteLine($"Derinlik : {BinaryTree<int>.MaxDepth(BST.Root)}");
            Console.WriteLine($"En Derin Node : {bt.DeepstNode(BST.Root)}");
            Console.WriteLine($"Yaprak sayısı : {bt.NumberOfLeafs(BST.Root)}");
            Console.WriteLine($"Tam Node sayısı : {BinaryTree<int>.NumberOfFullNode(BST.Root)}");
            Console.WriteLine($"Yarım Node sayısı : {BinaryTree<int>.NumberOfHalfNode(BST.Root)}");


            var keyNode = BST.Find(BST.Root, 16);
            if(keyNode != null) //Arananı bulamadığında default değer dönecek .(Ekrana basma yapmıycak)
            {
                Console.WriteLine($"{keyNode} - Left : {((keyNode.LeftNode == null) ? "Null" : $"{keyNode.LeftNode.Value}")} " +
                    $"- Right : {((keyNode.RightNode == null) ? "Null" : $"{keyNode.RightNode.Value}")}"); //Çocukları varsa değerlerini yoksa null ifadesini ekrana basıyoruz.
            }

            Console.WriteLine("\nInOrder : ");
            bt.InOrder(BST.Root).ForEach(node => Console.Write($"{node,-3} "));
            bt.ClearNodeList();

            BST.Remove(BST.Root, 23);

            Console.WriteLine("\nSilme işlemi Sonrası InOrder : ");
            bt.InOrder(BST.Root).ForEach(node => Console.Write($"{node,-3} "));
            bt.ClearNodeList();
            Console.WriteLine("\n\n -------------- \n");

            //----------------------------------

            var btchar = new BinaryTree<char>();
            btchar.Root = new Node<char>('M');
            btchar.Root.LeftNode = new Node<char>('E');
            btchar.Root.RightNode = new Node<char>('R');
            btchar.Root.LeftNode.LeftNode = new Node<char>('T');
            btchar.Root.RightNode.LeftNode = new Node<char>('D');
            btchar.Root.RightNode.RightNode = new Node<char>('E');
            btchar.Root.LeftNode.LeftNode.LeftNode = new Node<char>('D');
            btchar.Root.LeftNode.LeftNode.RightNode = new Node<char>('E');
            var list = btchar.LevelOrderNonRecursive(btchar.Root);
            foreach(var node in list)
            {
                Console.Write(node + "   ");
            }
            Console.WriteLine($"\nEn Derin Node : {btchar.DeepstNode()}");
            Console.WriteLine($"En Derin Node : {btchar.DeepstNode(btchar.Root)}");
            Console.WriteLine($"Yaprak sayısı : {btchar.NumberOfLeafs(btchar.Root)}");
            Console.WriteLine($"Yaprak sayısı : {btchar.NumberOfLeafs()}");
            Console.WriteLine($"Tam Node sayısı : {BinaryTree<char>.NumberOfFullNode(btchar.Root)}");
            Console.WriteLine($"Yarım Node sayısı : {BinaryTree<char>.NumberOfHalfNode(btchar.Root)}");
            new BinaryTree<char>().PrintPaths(btchar.Root);
            
            



            Console.ReadKey();
        }
    }

}
