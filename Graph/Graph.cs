using DataStructures.Graph.AdjancencySet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Graph
    {
        static void Main(string[] args)
        {
            //Yönsüz Graf
            Console.WriteLine("Yönsüz Graf : ");
            var graph = new Graph<char>(new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G' });

            graph.AddEdge('A', 'B');
            graph.AddEdge('A', 'D');
            graph.AddEdge('D', 'C');
            graph.AddEdge('D', 'E');
            graph.AddEdge('C', 'E');
            graph.AddEdge('E', 'F');
            graph.AddEdge('F', 'G');

            foreach (var key in graph)
            {
                Console.WriteLine(key);
                foreach (var vertex in graph.GetVertex(key))
                {
                    Console.WriteLine("\t {0}", vertex);
                }
            }

            Console.WriteLine("\nIs the vertex A in this Graph? {0}", graph.HasVertex('A') ? "Yes" : "No");
            Console.WriteLine("Is there an edge between A and B ? {0}", graph.HasEdge('A', 'B') ? "Yes" : "No");
            Console.WriteLine("Is there an edge between B and A ? {0}", graph.HasEdge('B', 'A') ? "Yes" : "No");
            Console.WriteLine("Is there an edge between B and D ? {0}", graph.HasEdge('B', 'D') ? "Yes" : "No");
            Console.WriteLine("Is there an edge between D and B ? {0}", graph.HasEdge('D', 'B') ? "Yes" : "No");

            graph.RemoveEdge('A', 'B');

            foreach (var key in graph)
            {
                Console.WriteLine(key);
                foreach (var vertex in graph.GetVertex(key))
                {
                    Console.WriteLine("\t {0}", vertex);
                }
            }
            Console.WriteLine("Is there an edge between A and B ? {0}", graph.HasEdge('A', 'B') ? "Yes" : "No");
            Console.WriteLine("Is there an edge between A and D ? {0}", graph.HasEdge('A', 'D') ? "Yes" : "No");

            Console.WriteLine("\nIs the vertex A in this Graph? {0}", graph.HasVertex('A') ? "Yes" : "No");
            graph.RemoveVertex('A');
            Console.WriteLine("Removed vertex A");
            Console.WriteLine("Is the vertex A in this Graph? {0}", graph.HasVertex('A') ? "Yes" : "No");

            foreach (var key in graph)
            {
                Console.WriteLine(key);
                foreach (var vertex in graph.GetVertex(key))
                {
                    Console.WriteLine("\t {0}", vertex);
                }
            }

            Console.WriteLine($"Number of vertex in the graph : {graph.Count}");
            //Yönlü Graf
            Console.WriteLine("\nYönlü Graf : ");

            var diGraph = new DiGraph<char>(new char[] { 'A', 'B', 'C', 'D', 'E' });

            diGraph.AddEdge('A', 'D');
            diGraph.AddEdge('B', 'A');
            diGraph.AddEdge('D', 'E');
            diGraph.AddEdge('C', 'A');
            diGraph.AddEdge('C', 'B');
            diGraph.AddEdge('C', 'D');
            diGraph.AddEdge('C', 'E');

            foreach (var key in diGraph)
            {
                Console.WriteLine(key);
                foreach (var vertex in diGraph.GetVertex(key))
                {
                    Console.WriteLine("\t {0}", vertex);
                }
            }

            Console.WriteLine("\nIs the vertex A in this Graph? {0}", diGraph.HasVertex('A') ? "Yes" : "No");
            Console.WriteLine("Is there an edge between A and B ? {0}", diGraph.HasEdge('A', 'B') ? "Yes" : "No");
            Console.WriteLine("Is there an edge between B and A ? {0}", diGraph.HasEdge('B', 'A') ? "Yes" : "No");

            diGraph.RemoveEdge('B', 'A');

            foreach (var key in diGraph)
            {
                Console.WriteLine(key);
                foreach (var vertex in diGraph.GetVertex(key))
                {
                    Console.WriteLine("\t {0}", vertex);
                }
            }

            Console.WriteLine("\nIs there an edge between B and A ? {0}", diGraph.HasEdge('B', 'A') ? "Yes" : "No");
            Console.WriteLine("Is there an edge between A and D ? {0}", diGraph.HasEdge('A', 'D') ? "Yes" : "No");

            Console.WriteLine("\nIs the vertex A in this Graph? {0}", diGraph.HasVertex('A') ? "Yes" : "No");
            diGraph.RemoveVertex('A');
            Console.WriteLine("Removed vertex A");
            Console.WriteLine("Is the vertex A in this Graph? {0}", diGraph.HasVertex('A') ? "Yes" : "No");

            foreach (var key in diGraph)
            {
                Console.WriteLine(key);
                foreach (var vertex in diGraph.GetVertex(key))
                {
                    Console.WriteLine("\t {0}", vertex);
                }
            }

            Console.WriteLine($"Number of vertex in the graph : {diGraph.Count}");
            Console.ReadKey();
        }
    }
}
