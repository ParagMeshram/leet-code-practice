namespace EvaluateReversePolishNotation
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public int EvalRPN(string[] tokens)
        {
            if (tokens == null || tokens.Length == 0)
                return 0;

            var stack = new Stack<int>();

            foreach (var token in tokens)
            {
                if (IsOperator(token))
                {
                    var second = stack.Pop();
                    var first = stack.Pop();

                    var result = Evaluate(first, token, second);

                    stack.Push(result);
                }
                else if (IsNumber(token))
                {
                    var number = int.Parse(token);
                    stack.Push(number);
                }
            }

            return stack.Pop();
        }

        private int Evaluate(int first, string op, int second)
        {
            switch (op)
            {
                case "+":
                    return first + second;

                case "-":
                    return first - second;

                case "*":
                    return first * second;

                case "/":
                    return first / second;

                default:
                    throw new InvalidOperationException("Unknown operator");
            }
        }

        private bool IsOperator(string token)
        {
            return token == "+" || token == "-" || token == "*" || token == "/";
        }


        private bool IsNumber(string token)
        {
            int number;
            return int.TryParse(token, out number);
        }
    }
}