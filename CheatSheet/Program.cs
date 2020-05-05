namespace CheatSheet.HowToCompareChars
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        public static class CharComparision
        {
            public static readonly CharComparer CurrentCulture = new CharComparer(StringComparison.CurrentCulture);

            public static readonly CharComparer CurrentCultureIgnoreCase =
                new CharComparer(StringComparison.CurrentCultureIgnoreCase);

            public static readonly CharComparer InvariantCulture = new CharComparer(StringComparison.InvariantCulture);

            public static readonly CharComparer InvariantCultureIgnoreCase =
                new CharComparer(StringComparison.InvariantCultureIgnoreCase);

            public static readonly CharComparer Ordinal = new CharComparer(StringComparison.Ordinal);

            public static readonly CharComparer
                OrdinalIgnoreCase = new CharComparer(StringComparison.OrdinalIgnoreCase);

            public sealed class CharComparer : IComparer<char>
            {
                private readonly StringComparison stringComparison;

                public CharComparer(StringComparison stringComparison)
                {
                    this.stringComparison = stringComparison;
                }

                public int Compare(char x, char y)
                {
                    return string.Compare(x.ToString(), y.ToString(), this.stringComparison);
                }
            }
        }
    }
}

namespace CheatSheet.HowToCheckIfStringIsASymbolOrANumber
{
    using System;
    using System.Text.RegularExpressions;

    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine(IsNumber("23"));
            Console.WriteLine(IsNumber("-23"));
            Console.WriteLine(IsOperator("-"));
        }

        private static bool IsSymbol(string token)
        {
            return Regex.IsMatch(token, "^[\\d]+$");
        }

        private static bool IsOperator(string token)
        {
            return Regex.IsMatch(token, "^[+\\-*/]+$");
        }

        private static bool IsNumber(string token)
        {
            return Regex.IsMatch(token, "^(-)?[\\d]+$");
        }
    }
}

namespace CheatSheet.DictionaryWithCaseInSensetiveComparision
{
    using System;
    using System.Collections.Generic;


    public sealed class CharEqualityComparer : IEqualityComparer<char> //^^^
    {
        public bool Equals(char x, char y)
        {
            return char.ToLower(x) == char.ToLower(y);
        }

        public int GetHashCode(char ch)
        {
            return char.ToLower(ch).GetHashCode(); //^^^
        }
    }

    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine(IsAnagram("PARAG", "garap"));
        }

        public static bool IsAnagram(string s, string t)
        {
            if (s == null && t == null)
                return true;

            if (s == string.Empty && t == string.Empty)
                return true;

            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t))
                return false;

            if (s.Length != t.Length)
                return false;

            var lookup = new Dictionary<char, int>(s.Length, new CharEqualityComparer()); //^^^

            foreach (var ch in s)
            {
                if (lookup.ContainsKey(ch))
                {
                    lookup[ch]++;
                }
                else
                {
                    lookup[ch] = 1;
                }
            }

            foreach (var ch in t)
            {
                if (!lookup.ContainsKey(ch))
                {
                    return false;
                }
                else
                {
                    lookup[ch]--;

                    if (lookup[ch] == 0)
                    {
                        lookup.Remove(ch);
                    }
                }
            }

            return true;
        }
    }
}

namespace CheatSheet.RandomNumberGenerator
{
    using System;

    internal class Program
    {
        public static void Main()
        {
            var random = new Random(); //^^^
            random.Next(0, 100);
        }
    }
}

namespace CheatSheet.Print.All.Substrings.Of.A.String
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        public static void Main()
        {
            const string input = "Parag";

            for (var i = 0; i < input.Length; i++)
            {
                for (var j = i + 1; j <= input.Length; j++)
                {
                    var sub = input.Substring(i, j - i);
                    Console.WriteLine(sub);
                }
            }
        }
    }

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private class PQItem
        {
            public T Item { get; set; }
            public int Index { get; set; }
        }

        private int index = 0;
        private readonly SortedSet<PQItem> set;

        public PriorityQueue()
        {
            set = new SortedSet<PQItem>(Comparer<PQItem>.Create((x, y) =>
                x.Item.CompareTo(y.Item) == 0 ? x.Index - y.Index : x.Item.CompareTo(y.Item)));
        }

        public void Enqueue(T item)
        {
            set.Add(new PQItem { Item = item, Index = index++ });
        }

        public T Dequeue()
        {
            var min = set.Min;
            this.set.Remove(min);
            return min.Item;
        }
    }
}

namespace CheatSheet.Difference.Between.Jagged.Array.vs.Array
{
    using System;

    internal class Program
    {
        public static void Main()
        {
            int[][] jagged_arr = new int[4][];

            // Initialize the elements 
            jagged_arr[0] = new[] { 1, 2, 3, 4 };
            jagged_arr[1] = new[] { 11, 34, 67 };
            jagged_arr[2] = new[] { 89, 23 };
            jagged_arr[3] = new[] { 0, 45, 78, 53, 99 };

            //Console.WriteLine(jagged_arr.GetLowerBound(0));
            //Console.WriteLine(jagged_arr.GetUpperBound(0));
            //Console.WriteLine(jagged_arr.GetLowerBound(1));
            //Console.WriteLine(jagged_arr.GetUpperBound(1));

            for (int i = 0; i < jagged_arr.Length; i++)
            {
                for (int j = 0; j < jagged_arr[i].Length; j++)
                {
                    Console.Write(jagged_arr[i][j] + ",");
                }

                Console.WriteLine();
            }

            // Console.ReadKey();


            int[,] array = new int[4, 6];

            // Initialize the elements 
            array = new int[,]
            {
                {1, 2, 3, 4, 9, 7},
                {6, 9, 3, 10, 4, 2},
                {56, 1, 45, 4, 1, 0},
                {1, 99, 3, 4, 4, 8},
            };

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + ",");
                }

                Console.WriteLine();
            }

            Console.WriteLine(array.GetLowerBound(0));
            Console.WriteLine(array.GetUpperBound(0));
            Console.WriteLine(array.GetLowerBound(1));
            Console.WriteLine(array.GetUpperBound(1));


            Console.ReadKey();
        }
    }
}

namespace CheatSheet.How.To.Sort.List
{
    using System.Collections.Generic;

    internal class Program
    {
        public static void Main()
        {
            List<int> list = new List<int> { 2, 3, 4, 5, 6, 7, 8 }; //^^^ Use List and not IList

            list.Sort();
        }
    }
}

namespace CheatSheet.How.To.Trim.Array.With.Preceding.Zeros
{
    using System;
    using System.Linq;

    internal class Program
    {
        public static void Main()
        {
            var array = new[] { 0, 0, 0, 0, 0, 1234, 0, 0, 0, 0 };

            foreach (var digit in array.SkipWhile(d => d == 0))
            {
                Console.Write(digit);
            }
        }
    }
}