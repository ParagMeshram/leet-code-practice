using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParenthesesValidator
{
    internal class Program
    {
        private static void Main()
        {

        }
    }

    public class Solution
    {
        public bool IsValid(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return true;

            var stack = new Stack<char>();

            foreach (var ch in input)
            {
                if (IsClosingBrace(ch))
                {
                    var top = stack.Count > 0 ? stack.Peek() : '\0';

                    if (AreComplement(top, ch))
                    {
                        stack.Pop();
                        continue;
                    }

                    return false;
                }

                stack.Push(ch);
            }

            return stack.Count == 0;
        }

        private bool IsOpeningBrace(char ch)
        {
            return ch == '(' || ch == '{' || ch == '[';
        }

        private bool IsClosingBrace(char ch)
        {
            return ch == ')' || ch == '}' || ch == ']';
        }

        private bool AreComplement(char top, char ch)
        {
            return (top == '(' && ch == ')')
                   || (top == '{' && ch == '}')
                   || (top == '[' && ch == ']');
        }
    }
}
