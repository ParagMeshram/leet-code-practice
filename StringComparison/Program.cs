namespace StringComparison
{
    using System;
    using System.Collections.Generic;
    using StringComparison = System.StringComparison;

    public static class CharComparision
    {
        public static readonly CharComparer CurrentCulture = new CharComparer(StringComparison.CurrentCulture);
        public static readonly CharComparer CurrentCultureIgnoreCase = new CharComparer(StringComparison.CurrentCultureIgnoreCase);
        public static readonly CharComparer InvariantCulture = new CharComparer(StringComparison.InvariantCulture);
        public static readonly CharComparer InvariantCultureIgnoreCase = new CharComparer(StringComparison.InvariantCultureIgnoreCase);
        public static readonly CharComparer Ordinal = new CharComparer(StringComparison.Ordinal);
        public static readonly CharComparer OrdinalIgnoreCase = new CharComparer(StringComparison.OrdinalIgnoreCase);

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

    internal class Program
    {
        private static void Main()
        {
            var sortedList = new SortedList<int, int>();

            var i = 5;
            var j = 5;

            for (; j < i; j++)
            {
                Console.WriteLine(j);
            }

            Console.ReadKey();

            var input = "cbaCBââââāāąąááääĀÂĄÃÄÁÀĂăÅåÆ".ToCharArray();

            Array.Sort(input, CharComparision.CurrentCulture);
            Console.WriteLine($"CurrentCulture: {new string(input)}");

            Array.Sort(input, CharComparision.CurrentCultureIgnoreCase);
            Console.WriteLine($"CurrentCultureIgnoreCase: {new string(input)}");

            Array.Sort(input, CharComparision.InvariantCulture);
            Console.WriteLine($"InvariantCulture: {new string(input)}");

            Array.Sort(input, CharComparision.InvariantCultureIgnoreCase);
            Console.WriteLine($"InvariantCultureIgnoreCase: {new string(input)}");

            Array.Sort(input, CharComparision.Ordinal);
            Console.WriteLine($"Ordinal: {new string(input)}");

            Array.Sort(input, CharComparision.OrdinalIgnoreCase);
            Console.WriteLine($"OrdinalIgnoreCase: {new string(input)}");

            var s1 = "é"; //é as one character (ALT+0233)
            var s2 = "é"; //'e', plus combining acute accent U+301 (two characters)

            Console.WriteLine(s1.IndexOf(s2, StringComparison.Ordinal)); // -1
            Console.WriteLine(s1.IndexOf(s2, StringComparison.InvariantCulture)); // 0
            Console.WriteLine(s1.IndexOf(s2, StringComparison.CurrentCulture)); // 0

            var lookup = new HashSet<int>();

            lookup.Add(5);
            lookup.Add(5);

            Console.ReadKey();
        }
    }
}
