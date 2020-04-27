namespace GroupShiftedStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Program
    {
        private static void Main()
        {
            var o = new Solution();
            var output = o.GroupStrings(new[] { "abc", "bcd", "acef", "xyz", "az", "ba", "a", "z" });

            Console.ReadKey();
        }
    }

    public class Solution
    {
        public IList<IList<string>> GroupStrings(string[] strings)
        {
            // 0 => 48
            // 9 => 57 (49 + 9)
            // A => 65
            // Z => 90 (65 + 26)
            // a => 97
            // z => 122 (97 + 26)
            
            var map = new Dictionary<string, IList<string>>(); //^^^

            foreach (var item in strings)
            {
                var key = this.GetKey(item);

                if (map.ContainsKey(key))
                {
                    map[key].Add(item);
                }
                else
                {
                    map[key] = new List<string> { item }; //^^^
                }
            }

            return map.Values.ToList();
        }

        private string GetKey(string item)
        {
            var keyBuilder = new StringBuilder(item.Length);

            for (var index = 0; index < item.Length - 1; index++)
            {
                var diff = item[index + 1] - item[index];

                if (diff < 0) diff += 26;

                keyBuilder.Append(diff); //^^^
            }

            return keyBuilder.ToString();
        }
    }


}
