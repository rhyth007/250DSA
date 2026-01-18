/*
A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.

Given a string s, return true if it is a palindrome, or false otherwise.

 

Example 1:

Input: s = "A man, a plan, a canal: Panama"
Output: true
Explanation: "amanaplanacanalpanama" is a palindrome.
Example 2:

Input: s = "race a car"
Output: false
Explanation: "raceacar" is not a palindrome.
Example 3:

Input: s = " "
Output: true
Explanation: s is an empty string "" after removing non-alphanumeric characters.
Since an empty string reads the same forward and backward, it is a palindrome.
 

Constraints:

1 <= s.length <= 2 * 105
s consists only of printable ASCII characters.



Brute Force :

1)Loop in through each character and  check if string has IsLetterOrDigit() and store it in a string
2)Use 2 pointers and another compare left and right if not same return false


Optimal :
1)Save the space by iterating using 2 pointers 
2)Move left++ or right-- if that character is not letter or digit --> IMP Use While becoz if there 2 consective then it will be covered together if will only move once
3)


*/


public class Solution
{
    public bool IsPalindrome(string s)
    {

        string str = "";

        foreach (char ch in s)
        {

            if (char.IsLetterOrDigit(ch))
            {
                str = str + ch;
            }
        }

        str = str.ToLower();

        int l = 0;
        int r = str.Length - 1;

        while (l < r)
        {
            if (str[l++] != str[r--])
            {
                return false;
            }

        }

        return true;

    }

}

public class Solution
{
    public bool IsPalindrome(string s)
    {

        int l = 0;
        int r = s.Length - 1;

        while (l < r)
        {

            while (l < r && !char.IsLetterOrDigit(s[l]))
            {

                l++;
            }


            while (l < r && !char.IsLetterOrDigit(s[r]))
            {
                r--;
            }

            if (Char.ToLower(s[l]) != Char.ToLower(s[r]))
                return false;

            l++;
            r--;




        }

        return true;

    }
}