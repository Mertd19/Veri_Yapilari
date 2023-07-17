using DataStructures.Tree.BinaryTree;
using System.Collections;

namespace DataStructures.Tree.BinarySearchTree
{
    internal class BSTEnumerator<T> : IEnumerator<T> where T : IComparable
    {
        private List<Node<T>> list;
        private int indexer = -1;
        public BSTEnumerator(Node<T> root)
        {
            list = new BinaryTree<T>().InOrderNonRecursive(root);
        }
        public T Current => list[indexer].Value;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            list = null;
        }

        public bool MoveNext()
        {
            indexer++;
            return indexer < list.Count ? true : false;
        }

        public void Reset()
        {
            indexer = -1;
        }
    }
}