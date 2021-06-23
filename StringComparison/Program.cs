namespace StringComparison
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
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
        public class Deque
        {
            private LinkedList<int> list = new LinkedList<int>();

            

            public void EnqueueFront(int value)
            {

            }

            public void EnqueueBack(int value)
            {

            }

            public void DequeueFront()
            {

            }

            public void DequeueBack()
            {

            }
        }

        public class User
        {
            public User()
            {
                
            }
        }


        private async static Task Main()
        { 
            var user = new object();

            if (user is {})
            {
                
            }


            var directions = new [,] { { 1, 2 }, { 2, 1 }, { -2, 1 }, { -1, 2 }, { -1, -2 }, { -2, -1 }, { 2, -1 }, { 1, -2 } };

            // *** Wrong **
            foreach (var direction in directions) //^^^ :(
            {
                Console.WriteLine(direction);
            }

            for(var index = 0; index < directions.GetLength(0); index++) //^^^
            {
                Console.WriteLine(directions[index, 0]);
            }


            var sortedList = new SortedList<int, int>();

            var comparer = Comparer<int>.Default;

            Console.WriteLine(Math.Sign(0));
            
            Console.WriteLine(comparer.Compare(34, 22));
            
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