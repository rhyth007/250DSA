/*
Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

Notice that the solution set must not contain duplicate triplets.

 

Example 1:

Input: nums = [-1,0,1,2,-1,-4]
Output: [[-1,-1,2],[-1,0,1]]
Explanation: 
nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
The distinct triplets are [-1,0,1] and [-1,-1,2].
Notice that the order of the output and the order of the triplets does not matter.


1) Sort the orignal nums array.
2) Loop from 1st to n-2 ( Three Sum so you will be at 3rd Last Element)
3) Check if adjacent is duplicate if yes then skip to next iteration
4) Use two pointers left = i+1 and right = n - 1;
5) Loop while (left<right) -> Calculate Sum as nums of left,right and i
6) If Sum < 0 ;left++ else if Sum>0 right --;
7) If Sum == 0  (Add the nums of left,right and i) once added keep moving left++ till no duplicate simarly for right -- 



*/

public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        var result = new List<IList<int>>();
        Array.Sort(nums); // Step 1: Sort the array

        for (int i = 0; i < nums.Length - 2; i++)
        {
            // Skip duplicate values for i
            if (i > 0 && nums[i] == nums[i - 1])
                continue;

            int left = i + 1;
            int right = nums.Length - 1;

            while (left < right)
            {
                int sum = nums[i] + nums[left] + nums[right];

                if (sum == 0)
                {
                    result.Add(new List<int> { nums[i], nums[left], nums[right] });

                    // Skip duplicates for left
                    while (left < right && nums[left] == nums[left + 1])
                        left++;

                    // Skip duplicates for right
                    while (left < right && nums[right] == nums[right - 1])
                        right--;

                    left++;
                    right--;
                }
                else if (sum < 0)
                {
                    left++; // Need a larger sum
                }
                else
                {
                    right--; // Need a smaller sum
                }
            }
        }

        return result;
    }
}
