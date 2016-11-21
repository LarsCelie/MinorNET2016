using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace Minor.Dag38.HelloWorld
{
    public class Program
    {
        static Dictionary<int, BigInteger> fibonacci = new Dictionary<int, BigInteger>();

        public static void Main(string[] args)
        {
            for (int i = 1; i <= 500; i++)
            {
                Console.WriteLine(fib(i));
                Thread.Sleep(50);
            }
        }

        private static BigInteger fib(int i)
        {
            if (i < 2)
            {
                return 1;
            }
            BigInteger a = fibonacci.Where(kv => kv.Key == i - 1).Select(kv => kv.Value).FirstOrDefault();
            BigInteger b = fibonacci.Where(kv => kv.Key == i - 2).Select(kv => kv.Value).FirstOrDefault();

            if (a == 0)
            {
                a = fib(i - 1);
            }
            if (b == 0)
            {
                b = fib(i - 2);
            }
            fibonacci.Add(i, a + b);
            return a + b;
        }
    }
}
