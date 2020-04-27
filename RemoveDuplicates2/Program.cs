using System;
using System.Threading;

public class Solution
{

    public static void Main()
    {
        var input = new[] { 1, 1, 1, 1, 2, 2, 2, 2, 3, 4, 5, 6, 6, 6, 6, 9 };
        var output = RemoveDuplicates(input);

        for (int index = 0; index < output; index++)
        {
            Console.WriteLine(input[index]);
        }

        Console.ReadKey();
    }


    public static int RemoveDuplicates(int[] nums)
    {
        if (nums == null) return 0;

        if (nums.Length <= 3) return nums.Length;

        var first = 0;
        var second = 1;
        var dupCount = 1;

        while (second < nums.Length)
        {
            if (nums[first] != nums[second])
            {
                nums[++first] = nums[second];
                dupCount = 0;
            }
            else if (dupCount < 2)
            {
                nums[++first] = nums[second];
            }

            dupCount++;
            second++;
        }

        return first + 1;
    }
}

// 0 1 2 3 4 5 6 7
// 1 1 1 2 3 3 5 5
//       ` ^