using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph.AdjancencySet
{
    public class Graph<T> : IGraph<T>
    {
        private Dictionary<T, GraphVertex<T>> vertices;
        public bool isWeightGraph => false;
        public int Count => vertices.Count;
        public IGraphVertex<T> ReferenceVertex => vertices[this.First()];
        public IEnumerable<IGraphVertex<T>> VerticesAsEnumerable => vertices.Select(x => x.Value);
        public Graph()
        {
            vertices = new Dictionary<T, GraphVertex<T>>();
        }
        public Graph(IEnumerable<T> collection)
        {
            vertices = new Dictionary<T, GraphVertex<T>>();
            foreach (var item in collection)
            {
                AddVertex(item);
            }
        }
        public void AddVertex(T key)
        {
            if(key == null)
            {
                throw new ArgumentNullException();
            }
            var NewVertex = new GraphVertex<T>(key);
            vertices.Add(key, NewVertex);
        }
        public void AddEdge(T source, T dest)
        {
            if (source == null || dest == null)
            {
                throw new ArgumentNullException();
            }
            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest))
            {
                throw new ArgumentException("Source or Dest vertex is not in this Graph!");
            }
            if (vertices[source].Edges.Contains(vertices[dest]) || vertices[dest].Edges.Contains(vertices[source]))
            {
                throw new ArgumentException("The Edge has been already defined!");
            }
            vertices[source].Edges.Add(vertices[dest]);
            vertices[dest].Edges.Add(vertices[source]); //Yönsüz graf olduğu için 2 düğümede kenar ekliyoruz . (A - B ve B - A şeklinde olmalı .)
        }
        IGraph<T> IGraph<T>.Clone()
        {
            return Clone();
        }
        public Graph<T> Clone()
        {
            var graph = new Graph<T>();
            foreach (var vertex in vertices)
            {
                graph.AddVertex(vertex.Key);
            }
            foreach (var vertex in vertices)
            {
                foreach (var node in vertex.Value.Edges)
                {
                    graph.AddEdge(vertex.Value.Key, node.Key);
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
            if(key == null)
            {
                throw new ArgumentNullException();
            }
            return vertices[key].Edges.Select(x => x.Key);
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
            return vertices[source].Edges.Contains(vertices[dest]) && vertices[dest].Edges.Contains(vertices[source]);
        }
        public bool HasVertex(T key)
        {
            if(key == null)
            {
                throw new ArgumentNullException();
            }
            return vertices.ContainsKey(key);
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
            if (!vertices[source].Edges.Contains(vertices[dest]) || !vertices[dest].Edges.Contains(vertices[source]))
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
                vertices[vertex.Key].Edges.Remove(vertices[key]);
            }
            vertices.Remove(key);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private class GraphVertex<T> : IGraphVertex<T>
        {
            public T Key { get; set; }
            public HashSet<IGraphVertex<T>> Edges { get; private set; }
            public GraphVertex(T key)
            {
                Key = key;
                Edges = new HashSet<IGraphVertex<T>>();
            }

            IEnumerable<IGraphEdge<T>> IGraphVertex<T>.Edges => Edges.Select(x => new Edge<T, int>(x, 1));

            public IGraphEdge<T> GetEdge(IGraphVertex<T> targetVertex)
            {
                return new Edge<T,int>(targetVertex, 1);
            }

            public IEnumerator<T> GetEnumerator()
            {
                return Edges.Select(x => x.Key).GetEnumerator(); 
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
