using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Set
{
    public class DisjointSet<T> : IEnumerable<T>
    {
        public DisjointSet()
        {
            
        }
        public DisjointSet(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                MakeSet(item);
            }
        }
        private Dictionary<T, DisjointSetNode<T>> set = new Dictionary<T, DisjointSetNode<T>> ();
        public int Count { get; private set; }
        public void MakeSet(T value)
        {
            if (set.ContainsKey(value))
            {
                throw new Exception($"The {value} has already been defined!");
            }

            var NewSet = new DisjointSetNode<T>(value, 0);
            NewSet.Parent = NewSet;
            set.Add(value, NewSet);
            Count++;
        }
        public T FindSet(T value)
        {
            if (!set.ContainsKey(value))
            {
                throw new Exception($"The {value} is not in this set!");
            }
            return findSet(set[value]).Value;

            throw new NotImplementedException();
        }
        private DisjointSetNode<T> findSet(DisjointSetNode<T> setNode)
        {
            var parent = setNode.Parent;
            if(setNode != parent) //Düğüm parentına eşit değilse (Parentına eşit olan düğüm kök)
            {
                setNode.Parent =  findSet(setNode.Parent);
                return setNode.Parent;
            }
            return parent;
        }
        public void UnionSet(T valueA, T valueB)
        {
            var rootA = FindSet(valueA);
            var rootB = FindSet(valueB);

            if(rootA.Equals(rootB))
            {
                return;
            }
            var nodeA = set[rootA];
            var nodeB = set[rootB];

            if(nodeA.Rank == nodeB.Rank)
            {
                nodeB.Parent = nodeA;
                nodeA.Rank++;
            }
            else
            {
                if(nodeA.Rank < nodeB.Rank)
                {
                    nodeA.Parent = nodeB;
                    nodeB.Rank++;
                }
                else
                {
                    nodeB.Parent = nodeA;
                    nodeA.Rank++;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return set.Values.Select(x => x.Value).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
