using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeSum
{
    internal class Program
    {
        private static void Main()
        {
            var input = new[] { -1, 0, 1, 2, -1, -4 };
            var output = (new Solution()).ThreeSum(input);
            Console.ReadKey();
        }
    }

    public class Solution
    {
        public List<List<int>> ThreeSum(int[] nums)
        {
            var result = new List<List<int>>();

            for (var i = 0; i < nums.Length - 2; i++)
            {
                var first = nums[i];

                for (var j = i + 1; j < nums.Length - 1; j++)
                {
                    var second = nums[j];

                    for (var k = j + 1; k < nums.Length; k++)
                    {
                        var third = nums[k];

                        if (first + second + third == 0)
                        {
                            result.Add(new List<int> { first, second, third });
                        }
                    }
                }
            }

            return result;
        }
    }
}
