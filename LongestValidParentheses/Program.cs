namespace LongestValidParentheses
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main()
        {
            var o = new Solution();

            Console.WriteLine(o.LongestValidParenthesesStack(")()("));
        }
    }

    public class Solution
    {
        public int LongestValidParenthesesStack(string input)
        {
            var longest = 0;
            var stack = new Stack<int>();

            stack.Push(-1);

            for (var index = 0; index < input.Length; index++)
            {
                if (input[index] == '(')
                {
                    stack.Push(index);
                }
                else
                {
                    stack.Pop();

                    if (stack.Count == 0)
                    {
                        stack.Push(index);
                    }
                    else
                    {
                        longest = Math.Max(longest, index - stack.Peek());
                    }
                }
            }

            return longest;
        }


        public int LongestValidParenthesesBruteForce(string input)
        {
            if (string.IsNullOrWhiteSpace(input) || input.Length == 1) return 0;

            var longest = 0;

            for (var i = 0; i < input.Length - 1; i++)
            {
                for (var j = i + 1; j <= input.Length; j++)
                {
                    var substring = input.Substring(i, j); //^^^

                    if (IsValid(substring))
                    {
                        longest = Math.Max(longest, substring.Length);
                    }
                }
            }

            return longest;
        }


        public bool IsValid(string input)
        {
            var stack = new Stack<char>();

            foreach (var current in input)
            {
                if (IsClosing(current))
                {
                    var top = stack.Count > 0 ? stack.Peek() : '\0';

                    if (!IsValidOpenClose(top, current))
                    {
                        return false;
                    }

                    stack.Pop();
                }
                else
                {
                    stack.Push(current);
                }
            }

            return stack.Count == 0;
        }

        private IDictionary<char, char> braces = new Dictionary<char, char>
        {
            {')', '('},
            {'}', '{'},
            {']', '['}
        };

        private bool IsClosing(char brace)
        {
            return this.braces.ContainsKey(brace);
        }

        private bool IsValidOpenClose(char opening, char closing)
        {
            return this.braces[closing] == opening;
        }
    }
}