/*
Given a string s, find the length of the longest substring without duplicate characters.
Example 1:

Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3. Note that "bca" and "cab" are also correct answers.
Example 2:

Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.
Example 3:

Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
 

Constraints:

0 <= s.length <= 5 * 104
s consists of English letters, digits, symbols and spaces.



Brute Force

1) Generate All substrings 2 For loops inside that use function to check unqiue and check max length
So total Time Complexity (O(n)^3)

Optimal Approach
Use Sliding Window + 2 Pointers
left , right
keep moving right and adding in hashset
Keep checking if unique else remove left element and move left by one by one

*/


public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {

        if (s.Length == 0)
            return 0;

        if (s.Length == 1)
            return 1;


        HashSet<char> set = new HashSet<char>();
        int left = 0;
        int right = 0;
        int result = 0;


        while (right < s.Length)
        {
            char ch = s[right];

            while (set.Contains(ch))
            {
                set.Remove(s[left]);
                left++;
            }

            set.Add(ch);


            result = Math.Max(result, set.Count());
            right++;

        }

        return result;



    }
}