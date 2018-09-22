using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLApp
{
    class Program
    {
        public static void Task1()
        {
            ParallelMatrix parallelMatrix = new ParallelMatrix(100);
            Console.WriteLine("Matrix 1:");
            ParallelMatrix.ShowMatrix(parallelMatrix.Matrix1);
            Console.WriteLine("Matrix 2:");
            ParallelMatrix.ShowMatrix(parallelMatrix.Matrix2);
            var result = parallelMatrix.Multiply();
            Console.WriteLine("Multiply Result:");
            ParallelMatrix.ShowMatrix(result);
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Task1();
        }
    }
}
