using DataStructures.Graph.AdjancencySet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightedGraph
{
    internal class WeightedGraph
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Yönsüz Ağırlıklı Graf");
            var graph = new WeightedGraph<char, double>(new char[] { 'A', 'B', 'C', 'D' });

            Console.WriteLine("Is there an edge between A and B ? {0}", graph.HasEdge('A', 'B') ? "Yes" : "No");
            Console.WriteLine("Is there an edge between B and A ? {0}", graph.HasEdge('B', 'A') ? "Yes" : "No");

            graph.AddEdge('A', 'B', 1.2);
            graph.AddEdge('A', 'D', 2.3);
            graph.AddEdge('D', 'C', 5.5);

            foreach (var vertex in graph)
            {
                Console.WriteLine(vertex);
                foreach (var key in graph.GetVertex(vertex))
                {
                    var node = graph.GetVertex(key);
                    Console.WriteLine($"\t{vertex} - {node.GetEdge(graph.GetVertex(vertex)).Weight<double>()} - {key}");
                }
            }

            Console.WriteLine("Is there an edge between A and B ? {0}", graph.HasEdge('A', 'B') ? "Yes" : "No");
            Console.WriteLine("Is there an edge between B and A ? {0}", graph.HasEdge('B', 'A') ? "Yes" : "No");

            graph.RemoveEdge('A', 'B');

            foreach (var vertex in graph)
            {
                Console.WriteLine(vertex);
                foreach (var key in graph.GetVertex(vertex))
                {
                    var node = graph.GetVertex(key);
                    Console.WriteLine($"\t{vertex} - {node.GetEdge(graph.GetVertex(vertex)).Weight<double>()} - {key}");
                }
            }

            Console.WriteLine("Is there an edge between A and B ? {0}", graph.HasEdge('A', 'B') ? "Yes" : "No");
            Console.WriteLine("Is there an edge between A and D ? {0}", graph.HasEdge('A', 'D') ? "Yes" : "No");

            Console.WriteLine("\nIs the vertex A in this Graph? {0}", graph.HasVertex('A') ? "Yes" : "No");
            graph.RemoveVertex('A');
            Console.WriteLine("Removed vertex A");
            Console.WriteLine("Is the vertex A in this Graph? {0}", graph.HasVertex('A') ? "Yes" : "No");
            foreach (var vertex in graph)
            {
                Console.WriteLine(vertex);
                foreach (var key in graph.GetVertex(vertex))
                {
                    var node = graph.GetVertex(key);
                    Console.WriteLine($"\t{vertex} - {node.GetEdge(graph.GetVertex(vertex)).Weight<double>()} - {key}");
                }
            }
            Console.WriteLine($"Number of vertex in the graph : {graph.Count}");

            Console.WriteLine("\n Yönlü Ağırlıklı Graf");

            var diGraph = new WeightedDiGraph<char, int>(new char[] { 'A', 'B', 'C', 'D', 'E' });


            Console.WriteLine("Is there an edge between A and B ? {0}", diGraph.HasEdge('A', 'B') ? "Yes" : "No");
            Console.WriteLine("Is there an edge between B and A ? {0}", diGraph.HasEdge('B', 'A') ? "Yes" : "No");

            diGraph.AddEdge('A', 'D', 60);
            diGraph.AddEdge('A', 'C', 12);
            diGraph.AddEdge('B', 'A', 10);
            diGraph.AddEdge('C', 'B', 20);
            diGraph.AddEdge('C', 'D', 32);
            diGraph.AddEdge('E', 'A', 7);

            foreach (var vertex in diGraph)
            {
                Console.WriteLine(vertex);
                foreach (var key in diGraph.GetVertex(vertex))
                {
                    var nodeU = diGraph.GetVertex(vertex);
                    var node = diGraph.GetVertex(key);
                    var w = nodeU.GetEdge(node).Weight<int>();
                    Console.WriteLine($"\t{vertex} - ({w}) - {key}");
                }
            }
            Console.WriteLine("Is there an edge between A and B ? {0}", diGraph.HasEdge('A', 'B') ? "Yes" : "No");
            Console.WriteLine("Is there an edge between B and A ? {0}", diGraph.HasEdge('B', 'A') ? "Yes" : "No");

            diGraph.RemoveEdge('B', 'A');

            foreach (var vertex in diGraph)
            {
                Console.WriteLine(vertex);
                foreach (var key in diGraph.GetVertex(vertex))
                {
                    var nodeU = diGraph.GetVertex(vertex);
                    var node = diGraph.GetVertex(key);
                    var w = nodeU.GetEdge(node).Weight<int>();
                    Console.WriteLine($"\t{vertex} - ({w}) - {key}");
                }
            }

            Console.WriteLine("Is there an edge between A and B ? {0}", diGraph.HasEdge('A', 'B') ? "Yes" : "No");
            Console.WriteLine("Is there an edge between B and A ? {0}", diGraph.HasEdge('B', 'A') ? "Yes" : "No");

            Console.WriteLine("\nIs the vertex A in this Graph? {0}", diGraph.HasVertex('A') ? "Yes" : "No");
            diGraph.RemoveVertex('A');
            Console.WriteLine("Removed vertex A");
            Console.WriteLine("Is the vertex A in this Graph? {0}", diGraph.HasVertex('A') ? "Yes" : "No");

            Console.WriteLine($"Number of vertex in the graph : {diGraph.Count}");

            Console.ReadLine();
        }
    }
}
