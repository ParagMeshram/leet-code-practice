namespace BasicCalculatorII
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            string infix = "3 + 4 * 2 / ( 1 - 5 ) ^ 2 ^ 3";
            Console.WriteLine(infix.ToPostfix());

            // https://rosettacode.org/wiki/Parsing/Shunting-yard_algorithm#C.23
            // http://www.cubequest.org/xe/index.php?mid=csharp&document_srl=166798
        }
    }

    public static class ShuntingYard
    {
        private static readonly Dictionary<string, (string symbol, int precedence, bool rightAssociative)> operators
            = new (string symbol, int precedence, bool rightAssociative)[]
            {
                ("*", 3, false),
                ("/", 3, false),
                ("+", 2, false),
                ("-", 2, false)
            }.ToDictionary(op => op.symbol);

        public static string ToPostfix(this string infix)
        {
            var tokens = infix.Split(' ');
            var stack = new Stack<string>();
            var output = new List<string>();

            foreach (var token in tokens)
            {
                if (int.TryParse(token, out _))
                {
                    output.Add(token);
                }
                else if (operators.TryGetValue(token, out var op1))
                {
                    while (stack.Count > 0 && operators.TryGetValue(stack.Peek(), out var op2))
                    {
                        var c = op1.precedence.CompareTo(op2.precedence);

                        if (c < 0 || !op1.rightAssociative && c <= 0)
                        {
                            output.Add(stack.Pop());
                        }
                        else
                        {
                            break;
                        }
                    }

                    stack.Push(token);
                }
                else if (token == "(")
                {
                    stack.Push(token);
                }
                else if (token == ")")
                {
                    var top = "";

                    while (stack.Count > 0 && (top = stack.Pop()) != "(")
                    {
                        output.Add(top);
                    }

                    if (top != "(") throw new ArgumentException("No matching left parenthesis.");
                }
            }

            while (stack.Count > 0)
            {
                var top = stack.Pop();
                if (!operators.ContainsKey(top)) throw new ArgumentException("No matching right parenthesis.");
                output.Add(top);
            }

            return string.Join(" ", output);
        }
    }
}