using System;
using System.Collections.Generic;
using System.Text;

namespace ATSD_Lab4
{
    class Graph
    {
        class Edge : IComparable<Edge>
        {
            public int from;
            public int to;
            public int weight;
            public int CompareTo(Edge compareEdge)
            {
                return this.weight
                       - compareEdge.weight;
            }
        }
        public int NumVertices { get; set; }

        public bool Directed = false;

        public int[,] Matrix { get; set; }

        public Graph(int numVertices)
        {
            NumVertices = numVertices;

            GenerateEmptyMatrix(numVertices);
        }

        private void GenerateEmptyMatrix(int num)
        {
            this.Matrix = new int[num, num];

            for(int row = 0; row < num; row++)
            {
                for(int col = 0; col < num; col++)
                {
                    Matrix[row, col] = 0;
                }
            }
        }

        public void AddEdge(int v1, int v2, int weight = 1)
        {
            if(v1 >= NumVertices || v2 >= NumVertices || v1 < 0 || v2 < 0)
            {
                throw new ArgumentOutOfRangeException("Vertices are out of bounds");
            }
            if(weight < 1)
            {
                throw new ArgumentException("Weight cannot be less than 1");
            }
            Matrix[v1, v2] = weight;
            if (!Directed)
            {
                Matrix[v2, v1] = weight;
            }
        }

        public List<int> GetAdjacentVertices(int v)
        {
            if(v < 0 || v >= NumVertices)
            {
                throw new ArgumentOutOfRangeException("Cannot acces the vertex");
            }

            List<int> AdjacentVertices = new List<int>();
            for(int i = 0; i < NumVertices; i++)
            {
                if(Matrix[v,i] > 0)
                {
                    AdjacentVertices.Add(v);
                }
            }
            return AdjacentVertices;
        }

        public int GetEdgeWeight(int v1, int v2)
        {
            if (v1 > NumVertices || v2 > NumVertices || v1 < 0 || v2 < 0)
            {
                throw new ArgumentOutOfRangeException("Vertices are out of bounds");
            }
            return Matrix[v1, v2];
        }

        public void RemoveEdge(int v1, int v2)
        {
            if (v1 > NumVertices || v2 > NumVertices || v1 < 0 || v2 < 0)
            {
                throw new ArgumentOutOfRangeException("Vertices are out of bounds");
            }
            if(Matrix[v1, v2] > 0)
            {
                Matrix[v1, v2] = 0;
            }
        }

        public void PrintMatrix()
        {
            Console.WriteLine("**************************");
            for(int i = 0; i < NumVertices; i++)
            {
                for(int j = 0; j < NumVertices; j++)
                {
                    Console.Write(Matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("**************************");
        }

        public void Dijkstra(int src)
        {
            int[] dist = new int[NumVertices];
            bool[] spt = new bool[NumVertices];

            for(int i = 0; i < NumVertices; i++)
            {
                dist[i] = int.MaxValue; //infinity
                spt[i] = false;
            }

            dist[src] = 0;

            for(int i = 0; i < NumVertices-1; i++)
            {
                int u = MinDistance(dist, spt);

                spt[u] = true;

                for (int v = 0; v < NumVertices; v++)
                {
                    if(!spt[v] && Matrix[u,v] != 0 && dist[u] != int.MaxValue
                        && dist[u] + Matrix[u,v] < dist[v])
                    {
                        dist[v] = dist[u] + Matrix[u, v];
                    }
                }
            }
            PrintDijkstra(dist, src);
        }

        private void PrintDijkstra(int[] dist, int src)
        {
            Console.Write("Vertex \t\t Distance "
                      + "from Source: {0}\n", src );
            for (int i = 0; i < NumVertices; i++)
                Console.Write(i + " \t\t " + dist[i] + "\n");
        }

        private int MinDistance(int[] dist, bool[] spt)
        {
            int min = int.MaxValue;
            int min_index = -1;

            for(int v = 0; v < NumVertices; v++)
            {
                if(spt[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }
            }
            return min_index;
        }
    }
}
