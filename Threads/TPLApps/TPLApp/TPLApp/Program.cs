using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLApp
{
    class Program
    {
        /*  Задание 1.
            Даны 2 двумерных матрицы. Размерность 100х100 каждая. Напишите приложение,
            производящее параллельное умножение матриц. Матрицы заполняются случайными целыми
            числами от 0 до10.        */
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

        /*  Задание 2.
            В некой директории лежат файлы. По структуре они содержат 3 числа, разделенные
            пробелами. Первое число - целое, обозначает действие, 1- умножение и 2- деление,
            остальные два - числа с плавающей точкой. Написать многопоточное приложение,
            выполняющее выполняющее вышеуказанные действия над числами и сохраняющими
            результат в файл result.dat. Количество файлов в директории заведомо много.        */
        public static void Task2()
        {
            Calc calc = new Calc();
            calc.ReadFilesAsync(AppDomain.CurrentDomain.BaseDirectory + @"sources");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            //Task1();
            Task2();
        }
    }
}
