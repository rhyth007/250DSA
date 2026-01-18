/*
Given two strings s1 and s2, return true if s2 contains a permutation of s1, or false otherwise.

In other words, return true if one of s1's permutations is the substring of s2.

 

Example 1:

Input: s1 = "ab", s2 = "eidbaooo"
Output: true
Explanation: s2 contains one permutation of s1 ("ba").
Example 2:

Input: s1 = "ab", s2 = "eidboaoo"
Output: false
 

Constraints:

1 <= s1.length, s2.length <= 104
s1 and s2 consist of lowercase English letters.


Logic is to check frequencies but in the window size of S1
Just frequencies will not work it should be in same window size

*/

public class Solution
{
    public bool CheckInclusion(string s1, string s2)
    {

        if (s1.Length > s2.Length)
            return false;


        int[] s1Freq = new int[26];
        int[] s2Freq = new int[26];


        //Initialize Frequency maps for S1 and First Window of S2

        for (int i = 0; i < s1.Length; i++)
        {

            s1Freq[s1[i] - 'a']++;
            s2Freq[s2[i] - 'a']++;
        }


        //Slide the window through S2 and compare Frequencies


        for (int i = 0; i < s2.Length - s1.Length; i++)
        {
            if (freqMatches(s1Freq, s2Freq))
                return true;

            s2Freq[s2[i + s1.Length] - 'a']++; //Add next (current index + window length)
            s2Freq[s2[i] - 'a']; //Remove first element

        }

        return FreqMatches(s1Freq, s2Freq);
    }

    public boolean FreqMatches(int[] s1Freq, int[] s2Freq)
    {

        for (int i = 0; i < 26; i++)
        {
            if (s1Freq[i] != s2Freq[i])
                return false;
        }

        return true;

    }
}