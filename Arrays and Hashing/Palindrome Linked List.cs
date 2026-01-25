/*
Given the head of a singly linked list, return true if it is a palindrome or false otherwise.

Example 1:
Input: head = [1,2,2,1]
Output: true
Example 2:


Input: head = [1,2]
Output: false
Constraints:
The number of nodes in the list is in the range [1, 10^5].
0 <= Node.val <= 9


🔎 Key Idea
Every palindrome can be thought of as expanding outward from a center:

Odd-length palindromes → center is a single character (e.g., "aba", center at "b").

Even-length palindromes → center is between two characters (e.g., "abba", center between "b" and "b").

So instead of generating all substrings, we expand around each possible center and count how many valid palindromes we find.

⚡ Algorithm (Expand Around Center)
Loop through each index i in the string.

Expand around:

(i, i) → odd-length palindromes.

(i, i+1) → even-length palindromes.

While characters match (s[left] == s[right]), we found a palindrome:

Increment count.

Expand outward (left--, right++).

Return the total count.
The Problem
We want to count all palindromic substrings in a string.
Instead of checking every substring (which is slow), we’ll look at each possible center and expand outward.

🔎 What is a "center"?
Think of a palindrome as a mirror:

Odd-length palindromes:
Mirror around a single character.
Example: "aba" → center at "b".

Even-length palindromes:
Mirror between two characters.
Example: "abba" → center between the two "b"s.

So for a string of length n, there are 2n - 1 possible centers:

n single-character centers (odd palindromes).

n - 1 between-character centers (even palindromes).

🧪 Example Walkthrough: "abc"
String length = 3 → centers = 5

Center at index 0 (odd)  
Expand around "a" → palindrome "a" ✅
Expand further → "ab" ❌ stop.

Center between index 0 and 1 (even)  
Expand around "a|b" → "ab" ❌ stop.

Center at index 1 (odd)  
Expand around "b" → palindrome "b" ✅
Expand further → "abc" ❌ stop.

Center between index 1 and 2 (even)  
Expand around "b|c" → "bc" ❌ stop.

Center at index 2 (odd)  
Expand around "c" → palindrome "c" ✅
Expand further → out of bounds.

Total palindromes = 3 → "a", "b", "c"
*/

public class Solution
{
    public int CountSubstrings(string s)
    {

        int count = 0;

        for (int i = 0; i < s.Length; i++)
        {
            count += ExpandAround(s, i, i);
            count += ExpandAround(s, i, i + 1);
        }

        return count;
    }
    public int ExpandAround(string s, int left, int right)
    {
        int count = 0;

        while (left >= 0 && right < s.Length && s[left] == s[right])
        {

            count++;
            left--;
            right++;
        }


        return count;

    }
}







public class Solution
{
    public int CountSubstrings(string s)
    {

        int count = 0;
        //Calculate all possible substrings and check if they are palindrome


        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i + 1; j <= s.Length; j++)
            {

                string substring = s.Substring(i, j - i);

                if (IsPalindrome(substring))
                {
                    count++;
                }


            }
        }

        return count;

    }

    bool IsPalindrome(string s)
    {

        int l = 0;
        int r = s.Length - 1;

        while (l < r)
        {

            if (s[l] != s[r])
                return false;

            l++;
            r--;

        }

        return true;
    }
}