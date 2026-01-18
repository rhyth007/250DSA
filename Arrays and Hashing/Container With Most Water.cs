/*
You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).

Find two lines that together with the x-axis form a container, such that the container contains the most water.

Return the maximum amount of water a container can store.

Notice that you may not slant the container.


Input: height = [1,8,6,2,5,4,8,3,7]
Output: 49
Explanation: The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7]. In this case, the max area of water (blue section) the container can contain is 49.
Example 2:

Input: height = [1,1]
Output: 1

📝 Two-Pointer Approach (Optimal Solution)
Idea
Start with the widest container (lines at both ends).

The area is limited by the shorter line.

To potentially increase the area, move the pointer at the shorter line inward, hoping to find a taller line.

Steps
Initialize two pointers

left = 0 (start of array)

right = n - 1 (end of array)

Calculate area

width = right - left

height = Math.Min(height[left], height[right])

area = width * height

Update max if this area is larger.

Move pointer

If height[left] < height[right], move left++

Else move right--

(Because moving the taller line cannot improve the area — only the shorter one matters.)

Repeat until pointers meet

Continue shrinking the window while checking for larger areas.

Complexity
Time: O(n) → Each pointer moves at most once across the array.

Space: O(1) → Only a few variables used.

Why It Works
The width decreases as pointers move inward.

To compensate, we must find a taller line.


*/

public class Solution
{
    public int MaxArea(int[] height)
    {

        int max = 0;
        int left = 0;
        int right = height.Length - 1;


        while (left < right)
        {

            int width = right - left;
            int area = Math.Min(height[left], height[right]) * width;

            max = Math.Max(max, area);

            if (height[left] <= height[right])
                left++;
            else
                right--;



        }

        return max;

    }
}