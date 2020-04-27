using System;

public class Solution
{

    public static void Main()
    {
        //var input = new[] { 1, 1, 1, 1, 2, 2, 2, 2, 3, 4, 5, 6, 6, 6, 6, 9 };
        var input = new[] { 1, 1, 1, 1 };
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

        if (nums.Length <= 1) return nums.Length;

        var first = 0;
        var second = 1;

        while (second < nums.Length)
        {
            if (nums[first] != nums[second])
            {
                nums[++first] = nums[second];
            }

            second++;
        }

        return first + 1;
    }

    public static int RemoveDuplicates2(int[] nums)
    {
        if (nums == null) return 0;

        if (nums.Length <= 1) return nums.Length;

        var first = 0;
        var second = 1;

        while (second < nums.Length)
        {
            //if (nums[first] != nums[second])
            //{
            //    nums[++first] = nums[second];
            //}

            //second++;

            while (nums[first] == nums[second])
            {
                second++;
            }

            nums[++first] = nums[second];
            second++;
        }

        return first + 1;
    }
}


// 1 2 3 3 5 5
//         ^ ^