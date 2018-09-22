using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TPLApp
{
    class ParallelMatrix
    {
        private int[,] matrix1;
        private int[,] matrix2;
        private int[,] _result;
        private int _n;

        public int[,] Matrix1 { get => matrix1; }
        public int[,] Matrix2 { get => matrix2; }

        public ParallelMatrix(int n)
        {
            _n = n;
            matrix1 = new int[n, n];
            matrix2 = new int[n, n];
            Random rand = new Random();
            for (int i=0; i<n; i++)
                for (int j=0; j<n; j++)
                {
                    matrix1[i, j] = rand.Next(0, 10);
                    matrix2[i, j] = rand.Next(0, 10);
                }
        }

        public int[,] Multiply()
        {
            _result = new int[_n, _n];
            Parallel.For(0, _n * _n, MultiplyElement);
            return _result;
        }

        private void MultiplyElement(int k)
        {
            
            int m = k / _n;
            int n = k % _n;
            //Console.WriteLine("indexes " + m + " " + n);
            Thread.Sleep(500);
            int res = 0;
            for (int i = 0; i < _n; i++)
                res += matrix1[m, i] * matrix2[i, n];
            _result[m, n] = res;
        }

        public static void ShowMatrix(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }
        }

    }
}
