using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrobogrammaticNumber
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        private readonly Dictionary<char, char> strobos = new Dictionary<char, char>
        {
            {'0', '0'},
            {'1', '1'},
            {'6', '9'},
            {'8', '8'},
            {'9', '6'},
        };

        public bool IsStrobogrammatic(string num)
        {
           
            for (int i = 0, j = num.Length - 1; i <= j; i++, j--)
            {
               if(AreStrobogrammatic(num[i], num[j]))
                    return false;
            }

            return true;
        }

        public bool AreStrobogrammatic(char a, char b)
        {
            return ((!strobos.ContainsKey(a) || !strobos.ContainsKey(b)) && a != strobos[b]);
        }
    }
}
