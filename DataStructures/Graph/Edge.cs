using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph
{
    public class Edge<T, TW> : IGraphEdge<T> where TW : IComparable //TW ile ağırlık tutuyoruz.
    {
        private object weight;
        public T TargetVertexKey => TargetVertex.Key;
        public Edge(IGraphVertex<T> target, TW weight)
        {
            TargetVertex = target;
            this.weight = weight;
        }
        public IGraphVertex<T> TargetVertex { get; private set; }
        public W Weight<W>() where W : IComparable
        {
            return (W)weight;
        }
        public override string ToString()
        {
            return TargetVertexKey.ToString();
        }
    }

    public class DiEdge<T, TW> : IDiGraphEdge<T>
    {
        private object weight;
        public T TargetVertexKey => TargetVertex.Key;
        public DiEdge(IDiGraphVertex<T> target,TW weight)
        {
            TargetVertex = target;
            this.weight = weight;
        }
        public IDiGraphVertex<T> TargetVertex { get; private set; }
        IGraphVertex<T> IGraphEdge<T>.TargetVertex => TargetVertex as IGraphVertex<T>;
        public W Weight<W>() where W : IComparable
        {
            return (W)weight;
        }
        public override string ToString()
        {
            return $"{TargetVertexKey}";
        }
    }
}
