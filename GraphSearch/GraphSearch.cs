using DataStructures.Graph.AdjancencySet;
using DataStructures.Graph.MinimumSpanningTree;
using DataStructures.Graph.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphSearch
{
    public class GraphSearch
    {
        static void Main(string[] args)
        {
            var graph = new Graph<int>();
            for(int i = 0; i <= 11; i++)
            {
                graph.AddVertex(i);
            }

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(0, 4);
            graph.AddEdge(1, 4);
            graph.AddEdge(2, 5);
            graph.AddEdge(2, 9);
            graph.AddEdge(2, 10);
            graph.AddEdge(5, 6);
            graph.AddEdge(5, 7);
            graph.AddEdge(5, 8);
            graph.AddEdge(7, 8);
            graph.AddEdge(9, 11);
            graph.AddEdge(10, 11);

            //Depth First Search
            var dfs = new DepthFirst<int>();
            Console.WriteLine("{0} " , dfs.Find(graph, 100) ? "Yes." : "No!");
            Console.WriteLine("{0} " , dfs.Find(graph, 5) ? "Yes." : "No!");

            //Breadth First Search
            var bfs = new BreadthFirst<int>();
            Console.WriteLine("{0} ", bfs.Find(graph, 100) ? "Yes." : "No!");
            Console.WriteLine("{0} ", bfs.Find(graph, 5) ? "Yes." : "No!");

            //--------------------------------------------
            
            var pGraph = new WeightedGraph<int, int>();
            for (int i = 0; i <= 11; i++)
            {
                pGraph.AddVertex(i);
            }

            pGraph.AddEdge(0, 1, 4);
            pGraph.AddEdge(0, 7, 8);
            pGraph.AddEdge(1, 7, 11);
            pGraph.AddEdge(1, 2, 8);
            pGraph.AddEdge(2, 8, 2);
            pGraph.AddEdge(2, 3, 7);
            pGraph.AddEdge(2, 5, 4);
            pGraph.AddEdge(3, 4, 9);
            pGraph.AddEdge(3, 5, 14);
            pGraph.AddEdge(4, 5, 10);
            pGraph.AddEdge(5, 6, 2);
            pGraph.AddEdge(6, 7, 1);
            pGraph.AddEdge(6, 8, 6);
            pGraph.AddEdge(7, 8, 7);

            //Prim's Algoritması
            Console.WriteLine("Prim's Algoritması");
            var prims = new Prims<int, int>();
            prims.FindMinimumSpanningTree(pGraph).ForEach(edge => Console.WriteLine(edge));

            //Kruskal Algoritması
            Console.WriteLine("Kruskal Algoritması");
            var kruskal = new Kruskals<int, int>();
            kruskal.FindMinimumSpanningTree(pGraph).ForEach(edge => Console.WriteLine(edge));

            Console.ReadKey();
        }
    }
}
