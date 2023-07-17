using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph
{
    public interface IGraph<T> : IEnumerable<T>
    {
        bool isWeightGraph { get; } // Ağırlıklımı ? 
        int Count { get; } //Grafdaki düğümlerin sayısı
        IGraphVertex<T> ReferenceVertex { get; } //Referans düğüm için
        IEnumerable<IGraphVertex<T>> VerticesAsEnumerable { get; } //Düğümler arası gezmek için
        IEnumerable<T> Edges(T Key); //Düğümün kenar bilgileri
        IGraph<T> Clone(); //Kopyasını oluşturma 
        bool ContainsVertex(T key); // Bu düğüm varmı ? 
        IGraphVertex<T> GetVertex (T key); //Düğümü özelliklerini istiyoruz
        bool HasEdge(T source, T dest); // 2 düğüm arası bağlantı varmı ? 
        void AddVertex(T key); // Düğümü ekleme
        void RemoveVertex(T key); // Düğümü silme
        void RemoveEdge(T source , T dest); // Kenar silme
    }
    public interface IDiGraph<T> : IGraph<T>
    {
        new IDiGraphVertex<T> ReferenceVertex { get; }
        new IEnumerable<IDiGraphVertex<T>> VerticesAsEnumerable { get; }
        new IDiGraphVertex<T> GetVertex(T key);
    }
    public interface IGraphVertex<T> : IEnumerable<T>
    {
        T Key { get; }
        IEnumerable<IGraphEdge<T>> Edges { get; }
        IGraphEdge<T> GetEdge(IGraphVertex<T> targetVertex);
    }
    public interface IDiGraphVertex<T> : IGraphVertex<T>
    {
        IDiGraphEdge<T> GetOutEdge(IDiGraphVertex<T> targetVertex);
        IEnumerable<IDiGraphEdge<T>> OutEdges { get; }
        IEnumerable<IDiGraphEdge<T>> InEdges { get; }
        int OutEdgesCount { get; }
        int InEdgesCount { get; }
    }
    public interface IGraphEdge<T> 
    {
        T TargetVertexKey { get; } //Düğümün değeri
        IGraphVertex<T> TargetVertex { get; } //Düğümün tüm özellikleri
        W Weight<W>() where W : IComparable; //Düğümün ağırlık değeri  
    }
    public interface IDiGraphEdge<T> : IGraphEdge<T>
    {
        new IDiGraphVertex<T> TargetVertex { get; }
    }
}
