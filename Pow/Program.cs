using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pow
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public double MyPow(double x, int n)
        {
            if (n < 0)
                return 1.0 / Helper(x, -1 * n);

            return Helper(x, n);
        }

        private double Helper(double x, long n) //^^^ Note Uses of `long`
        {
            if (n == 0) return 1;

            var half = Helper(x, n / 2);

            if (n % 2 == 0)
                return half * half;

            return half * half * x;
        }
    }
}
