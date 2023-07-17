using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph.AdjancencySet
{
    public class WeightedGraph<T, TW> : IGraph<T> where TW : IComparable
    {
        private Dictionary<T, WeightedGrapVertex<T,TW>> vertices;
        public bool isWeightGraph => true;
        public IGraphVertex<T> ReferenceVertex => vertices[this.First()];
        public IEnumerable<IGraphVertex<T>> VerticesAsEnumerable => vertices.Select(x => x.Value);

        public int Count => vertices.Count;
        public WeightedGraph()
        {
            vertices = new Dictionary<T, WeightedGrapVertex<T,TW>>();
        }
        public WeightedGraph(IEnumerable<T> collection)
        {
            vertices = new Dictionary<T, WeightedGrapVertex<T, TW>>();
            foreach (var item in collection)
            {
                AddVertex(item);
            }
        }

        public void AddVertex(T key)
        {
            if (key == null)
            {
                throw new ArgumentNullException();
            }
            var NewVertex = new WeightedGrapVertex<T, TW>(key);
            vertices.Add(key, NewVertex);
        }
        IGraph<T> IGraph<T>.Clone()
        {
            return Clone();
        }
        public WeightedGraph<T,TW> Clone()
        {
            var graph = new WeightedGraph<T,TW>();

            foreach (var vertex in vertices)
            {
                graph.AddVertex(vertex.Key);
            }
            foreach (var vertex in vertices)
            {
                foreach (var edge in vertex.Value.Edges)
                {
                    graph.AddEdge(vertex.Value.Key, edge.Key.Key, edge.Value);
                }
            }
            return graph;
        }
        public bool ContainsVertex(T key)
        {
            return vertices.ContainsKey(key);
        }
        public IEnumerable<T> Edges(T key)
        {
            if (key == null)
            {
                throw new ArgumentNullException();
            }
            return vertices[key].Edges.Select(x => x.Key.Key);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return vertices.Select(x => x.Key).GetEnumerator();
        }
        public IGraphVertex<T> GetVertex(T key)
        {
            return vertices[key];
        }
        public bool HasEdge(T source, T dest)
        {
            if (source == null || dest == null)
            {
                throw new ArgumentNullException();
            }
            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest))
            {
                throw new ArgumentException("Source or Dest vertex is not in this Graph!");
            }
            return vertices[source].Edges.ContainsKey(vertices[dest]) && vertices[dest].Edges.ContainsKey(vertices[source]);
        }
        public bool HasVertex(T key)
        {
            if (key == null)
            {
                throw new ArgumentNullException();
            }
            return vertices.ContainsKey(key);
        }
        public void AddEdge(T source, T dest, TW weight)
        {
            if (source == null || dest == null)
            {
                throw new ArgumentNullException();
            }
            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest))
            {
                throw new ArgumentException("Source or Dest vertex is not in this Graph!");
            }

            vertices[source].Edges.Add(vertices[dest], weight);
            vertices[dest].Edges.Add(vertices[source], weight); //Yönsüz graf olduğu için 2 düğümede kenar ekliyoruz . (A - B ve B - A şeklinde olmalı .)
        }
        public void RemoveEdge(T source, T dest)
        {
            if (source == null || dest == null)
            {
                throw new ArgumentNullException();
            }
            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest))
            {
                throw new ArgumentException("Source or Dest vertex is not in this Graph!");
            }
            if (!vertices[source].Edges.ContainsKey(vertices[dest]) || !vertices[dest].Edges.ContainsKey(vertices[source]))
            {
                throw new ArgumentException("The Edge does not exists!");
            }
            vertices[source].Edges.Remove(vertices[dest]);
            vertices[dest].Edges.Remove(vertices[source]);
        }
        public void RemoveVertex(T key)
        {
            if (key == null)
            {
                throw new ArgumentNullException();
            }
            if (!vertices.ContainsKey(key))
            {
                throw new ArgumentException("The vertex is not in this Graph!");
            }
            foreach (var vertex in vertices[key].Edges)
            {
                vertices[vertex.Key.Key].Edges.Remove(vertices[key]);
            }
            vertices.Remove(key);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class WeightedGrapVertex<T, TW> : IGraphVertex<T> where TW : IComparable
        {
            public Dictionary<WeightedGrapVertex<T, TW>, TW> Edges;
            public T Key { get; set; }
            public WeightedGrapVertex(T key)
            {
                Key = key;
                Edges = new Dictionary<WeightedGrapVertex<T, TW>, TW>();
            }

            IEnumerable<IGraphEdge<T>> IGraphVertex<T>.Edges => Edges.Select(x => new Edge<T, TW>(x.Key, x.Value));
            public IGraphEdge<T> GetEdge(IGraphVertex<T> targetVertex)
            {
                return new Edge<T, TW>(targetVertex, Edges[targetVertex as WeightedGrapVertex<T, TW>]);
            }
            public IEnumerator<T> GetEnumerator()
            {
                return Edges.Select(x => x.Key.Key).GetEnumerator(); //x.Key => WeightGraphVertex (Distionary key) , x.Key.Key => WeightGraphVertex.Key ( T )
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

        }

    }
}
