/*
Given an unsorted integer array nums. Return the smallest positive integer that is not present in nums.

You must implement an algorithm that runs in O(n) time and uses O(1) auxiliary space.

 

Example 1:

Input: nums = [1,2,0]
Output: 3
Explanation: The numbers in the range [1,2] are all in the array.
Example 2:

Input: nums = [3,4,-1,1]
Output: 2
Explanation: 1 is in the array but 2 is missing.
Example 3:

Input: nums = [7,8,9,11,12]
Output: 1
Explanation: The smallest positive integer 1 is missing.
 

Constraints:

1 <= nums.length <= 105
-231 <= nums[i] <= 231 - 1



Brute Force: go from 1 to n
check every time in the array   O(n^2)

*/

//Better solution : O(nlogn)
public class Solution
{
    public int FirstMissingPositive(int[] nums)
    {

        Array.Sort(nums);
        int missing = 1;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == missing)
            {
                missing++;
            }

        }

        return missing;
    }

    /*


    Another better approach is use HashMap
    Store all the values in hash map.
    Run the loop from i=1 to n and check if it ContainsKey



        O(N)
        1) Check for 1 in the array
        2) Convert out of range values to 1
        3) Start from first no's index i.e nums[a]  where a-> nums[i] and make that -1; 
        4) Repeat it and then loop one more time till we find postive value then return that index
        5) Other wise return n+1


        nums -> 5 -1 16 1 0 3 -8 2

                0 1  2  3 4  5  6 7  
        nums -> 5 1  1  1 1  3  1 2

                0  1  2   3 4   5  6 7  
        nums -> 5 -1 -1  -1 1  -3  1 2




    */

    public int FirstMissingPositive(int[] nums)
    {

        int checkone = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
            {
                checkone = 1;
                break;
            }

        }

        if (checkone == 0)
            return 1;


        int n = nums.Length;

        for (int i = 0; i < n; i++)
        {
            if (nums[i] <= 0 || nums[i] > n)
                nums[i] = 1;
        }


        for (int i = 0; i < nums.Length; i++)
        {

            int a = Math.Abs(nums[i]);

            if (a == n)  //To prevent out of bound index
            {
                nums[0] = -Math.Abs(nums[0]);
            }
            else
            {
                nums[a] = -Math.Abs(nums[a]);
            }

        }


        for (int i = 1; i < n; i++)
        {
            if (nums[i] > 0)
                return i;
        }

        if (nums[0] > 0)
            return n;

        return n + 1;



    }
}