using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertDeleteGetRandom
{
    internal class Program
    {
        private static void Main()
        {

        }
    }

	public class RandomizedSet
    {
        private readonly IDictionary<int, int> hashMap;
        private readonly IList<int> numbers;
        private readonly Random random;

        /** Initialize your data structure here. */
        public RandomizedSet()
        {
            hashMap = new Dictionary<int, int>(); // HashMap (Java), HashTable (typed)
            numbers = new List<int>();
            random = new Random(); //^^^
        }

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            if (hashMap.ContainsKey(val))
                return false;

            numbers.Add(val);
            hashMap[val] = numbers.Count - 1;

            return true;
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val)
        {
            if (!hashMap.ContainsKey(val))
                return false;

            // Get Last Number and Number's Index
            var last = new { index = numbers.Count - 1, number = numbers[numbers.Count - 1] }; //^^^
            var remove = new { index = hashMap[val], number = val }; //^^^


            numbers[remove.index] = last.number;
            hashMap[last.number] = remove.index;


            numbers.RemoveAt(last.index);
            hashMap.Remove(remove.number);

            return true;
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            return numbers[random.Next(0, numbers.Count)]; //^^^
        }
    }
}
