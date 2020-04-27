using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public string AddStrings(string num1, string num2)
        {
            var i = num1.Length - 1;
            var j = num2.Length - 1;

            var carry = 0;

            var builder = new StringBuilder();

            while (i >= 0 || j >= 0 || carry > 0)
            {
                var digit1 = i >= 0 ? num1[i--] - '0' : 0;
                var digit2 = j >= 0 ? num2[j--] - '0' : 0;

                var sum = digit1 + digit2 + carry;

                var digit3 = sum % 10;
                builder.Insert(0, digit3);
                carry = sum / 10;
            }

            return builder.ToString();
        }
    }
}
