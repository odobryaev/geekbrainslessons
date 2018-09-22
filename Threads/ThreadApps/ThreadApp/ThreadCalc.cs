using System;

namespace ThreadApp
{
    class ThreadCalc
    {
        private long _n;

        public ThreadCalc(long n)
        {
            _n = n;
        }

        public void ThreadFactorialCalculate()
        {
            long _result = 1;
            for (long i = 1; i <= _n; i++)
            {
                _result *= i;
            }
            Console.WriteLine("Result of factorial is " + _result.ToString());
        }

        public void ThreadSumCalculate()
        {
            long _result = 0;
            for (long i = 1; i <= _n; i++)
            {
                _result += i;
            }
            Console.WriteLine("Result of sum is " + _result.ToString());
        }
    }
}
