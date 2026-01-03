/*
219. Contains Duplicate

Given an integer array nums and an integer k, return true if there are two distinct indices i and j in the array such that nums[i] == nums[j] and abs(i - j) <= k.
Example 1:

Input: nums = [1,2,3,1], k = 3
Output: true



*/

public class Solution
{
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {


        // Brute Force Approach to run 2 for loops : O(N*K)

        for (int i = 0; i < nums.Length; i++)
        {

            for (int j = i + 1; j < nums.Length && j <= i + k; j++)
            {

                if (nums[i] == nums[j])
                    return true;

            }

        }

        return false;
    }

    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {

        //Using HashSet

        //Add the numbers in HashSet
        //Check if HashSet count 

        HashSet<int> set = new HashSet<int>();

        for (int i = 0; i < nums.Length; i++)
        {

            if (set.Contains(nums[i])) return true;

            set.Add(nums[i]);

            if (set.Count > k)
            {
                set.Remove(nums[k - i]);
            }


        }
        return false;


        /* Dry Run
        1)Check if contains 
        2)Push to Set
        3)Check the count < K

        Input: nums = [1,2,3,1], k = 3
        Output: true


        Set :
        i=0  set = 1 count = 1
        i=1  set = 1,2 count = 2
        i=2  set = 1,2,3 count = 3
        i=3  set = 1,2,3 it already contains 1 so return true



        Input: nums = [1,2,3,1,2,3], k = 2
        Output: false

        i = 0 , set = 1   count = 1  
        i = 1 , set = 1,2 count = 2 
        i = 2 , set = 1,2,3 count = 3 which is > K so remove 1 from set so : set.Remove(nums[2-2]) --> set.Remove(nums[0]) --> set = 2,3
        i = 3 , set = 2,3,1 count = 3
        */

    }
}
