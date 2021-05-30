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
    }
}
