/*
Given a 1-indexed array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number. Let these two numbers be numbers[index1] and numbers[index2] where 1 <= index1 < index2 <= numbers.length.

Return the indices of the two numbers, index1 and index2, added by one as an integer array [index1, index2] of length 2.

The tests are generated such that there is exactly one solution. You may not use the same element twice.

Your solution must use only constant extra space.

 

Example 1:

Input: numbers = [2,7,11,15], target = 9
Output: [1,2]
Explanation: The sum of 2 and 7 is 9. Therefore, index1 = 1, index2 = 2. We return [1, 2].
Example 2:

Input: numbers = [2,3,4], target = 6
Output: [1,3]
Explanation: The sum of 2 and 4 is 6. Therefore index1 = 1, index2 = 3. We return [1, 3].
Example 3:

Input: numbers = [-1,0], target = -1
Output: [1,2]
Explanation: The sum of -1 and 0 is -1. Therefore index1 = 1, index2 = 2. We return [1, 2].



Brute Force : O(N^2) 

Better Approach : Binary Search + 2 Pointer (O(NlogN))

Complement -> Target - Current --> 
Apply Binary Search on Complement --> BinarySearch(nums, i + 1, nums.Length - 1, complement

while (left <= right) { 
int mid = left + (right - left) / 2;
 if (nums[mid] == target)
  return mid; 
  else if (nums[mid] < target) 
  left = mid + 1; 
  else right = mid - 1;
  
   }

    v
Optimal Approach : 2 Pointers and Calculating Sum if Sum < Target move l++ else r--



*/

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {

        int left = 0;
        int right = nums.Length - 1;


        while (left < right)
        {

            if (nums[left] + nums[right] < target)
            {
                left++;
            }

            else if (nums[left] + nums[right] > target)
            {
                right--;
            }
            else
            {

                break;
            }
        }

        return new int[] { left + 1, right + 1 };
    }
}