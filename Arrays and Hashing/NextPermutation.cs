/*
A permutation of an array of integers is an arrangement of its members into a sequence or linear order.

For example, for arr = [1,2,3], the following are all the permutations of arr: [1,2,3], [1,3,2], [2, 1, 3], [2, 3, 1], [3,1,2], [3,2,1].
The next permutation of an array of integers is the next lexicographically greater permutation of its integer. More formally, if all the permutations of the array are sorted in one container according to their lexicographical order, then the next permutation of that array is the permutation that follows it in the sorted container. If such arrangement is not possible, the array must be rearranged as the lowest possible order (i.e., sorted in ascending order).

For example, the next permutation of arr = [1,2,3] is [1,3,2].
Similarly, the next permutation of arr = [2,3,1] is [3,1,2].
While the next permutation of arr = [3,2,1] is [1,2,3] because [3,2,1] does not have a lexicographical larger rearrangement.
Given an array of integers nums, find the next permutation of nums.

The replacement must be in place and use only constant extra memory.

[1, 3, 5, 4, 2]	
    i

Pivot at i=1 (3 < 5)	Swap 3 and 4 → [1, 4, 5, 3, 2]	

Reverse suffix [5,3,2] → [2,3,5]	

[1, 4, 2, 3, 5]

*/

public class Solution
{
    public void NextPermutation(int[] nums)
    {



        //Find the pivot index where nums[i+1]>=nums[i] from right to left
        int i = nums.Length - 2;  //Start from 2 postion before to avoid OoB index

        while (i >= 0 && nums[i + 1] <= nums[i])
        {
            i--;
        }

        if (i >= 0)
        {

            //Find the element just larger than pivot

            int j = nums.Length - 1;
            while (nums[j] <= nums[i])
            {
                j--;
            }
            swap(nums, i, j);
        }
        reverse(nums, i + 1);

    }


    public void swap(int[] nums, int i, int j)
    {

        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;

    }

    public void reverse(int[] nums, int i)
    {

        int j = nums.Length - 1;

        while (i < j)
        {
            swap(nums, j, i);
            i++;
            j--;
        }


    }
}