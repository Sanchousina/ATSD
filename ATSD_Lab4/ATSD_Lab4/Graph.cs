using System;
using System.Collections.Generic;
using System.Text;

namespace ATSD_Lab4
{
    class Graph
    {
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
            if(v1 > NumVertices || v2 > NumVertices || v1 < 0 || v2 < 0)
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
    }
}
