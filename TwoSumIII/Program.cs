using System.Collections.Generic;

namespace TwoSumIII
{
    internal class Program
    {
        private static void Main()
        {
            //var obj = new TwoSum();
            //obj.Add(number);
            //bool param_2 = obj.Find(value);
        }
    }

    public class TwoSum
    {
        private readonly IDictionary<int, int> lookup = new Dictionary<int, int>();

        public TwoSum()
        {
        }

        public void Add(int number)
        {
            if (this.lookup.ContainsKey(number))
                this.lookup[number] += 1;
            else
                this.lookup[number] = 1;
        }

        public bool Find(int value)
        {
            foreach (var keyValuePair in this.lookup)
            {
                var number = keyValuePair.Key;
                var occurrences = keyValuePair.Value;
                var expected = value - number;

                if (expected == number)
                {
                    if (occurrences > 1)
                        return true;
                }
                else if (this.lookup.ContainsKey(expected))
                {
                    return true;
                }
            }

            return false;
        }
    }
}