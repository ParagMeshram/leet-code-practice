using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplyStrings
{
    internal class Program
    {
        private static void Main()
        {
        }
    }

    public class Solution
    {
        public string Multiply(string num1, string num2)
        {
            var n1 = num1.Length;
            var n2 = num2.Length;
            var n3 = n1 + n2;

            var products = new int[n3];
            var sb = new StringBuilder(n3);

            for (var i = n1 - 1; i >= 0; i--)
            {
                for (var j = n2 - 1; j >= 0; j--)
                {
                    var d1 = num1[i] - '0';
                    var d2 = num2[j] - '0';
                    var prod = d1 * d2;
                    var sum = prod + products[i + j + 1];

                    products[i + j] += sum / 10;
                    products[i + j + 1] = sum % 10;
                }
            }

            foreach (var num in products.SkipWhile(d => d == 0))
            {
                sb.Append(num);
            }

            return sb.Length == 0 ? "0" : sb.ToString();
        }
    }
}
