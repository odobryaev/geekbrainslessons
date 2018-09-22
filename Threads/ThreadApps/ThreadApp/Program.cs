using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadApp
{
    class Program
    {
        static void Task1()
        {
            ThreadCalc factorial = new ThreadCalc(10);
            Thread thread1 = new Thread(new ThreadStart(factorial.ThreadFactorialCalculate))
            {
                Priority = ThreadPriority.Normal,
                Name = "Factorial Thread"
            };
            
            ThreadCalc sum = new ThreadCalc(10);
            Thread thread2 = new Thread(new ThreadStart(sum.ThreadSumCalculate))
            {
                Priority = ThreadPriority.Normal,
                Name = "Sum Thread"
            };

            thread1.Start();
            Console.WriteLine("Thread 1 Started");
            thread2.Start();
            Console.WriteLine("Thread 2 Started");
            Console.ReadKey();
        }

        static void Task2()
        {
            ThreadCSVParser csv = new ThreadCSVParser(@"example.csv");
            Thread readFile = new Thread(new ThreadStart(csv.Parse));
            Thread writeFile = new Thread(new ThreadStart(csv.WriteToTXT));

            readFile.Start();
            writeFile.Start();
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            //Task1();
            Task2();
        }
    }
}
