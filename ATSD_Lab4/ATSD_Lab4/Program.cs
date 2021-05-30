using System;

namespace ATSD_Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph(4);
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 3);

            graph.PrintMatrix();
        }
    }
}
