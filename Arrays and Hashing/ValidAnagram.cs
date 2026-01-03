/*
242. Valid Anagram
Solved
Easy
Topics
premium lock icon
Companies
Given two strings s and t, return true if t is an anagram of s, and false otherwise.

 

Example 1:

Input: s = "anagram", t = "nagaram"

Output: true

Example 2:

Input: s = "rat", t = "car"

Output: false

 

Constraints:

1 <= s.length, t.length <= 5 * 104
s and t consist of lowercase English letters.
 
*/

public class ValidAnagram
{

    //Using Fixed Size Frequency Array for 26 characters
    public bool IsAnagram(string s, string t)
    {

        if (s.Length != t.Length)
            return false;


        int[] freq = new int[26];

        for (int i = 0; i < s.Length; i++)
        {
            freq[s[i] - 'a']++;
            freq[t[i] - 'a']--;
        }

        foreach (int count in freq)
        {
            if (count != 0)
                return false;
        }

        return true;

    }

    //If it contains Unicode then use HashMap

    public bool IsAnagram(string s, string t)
    {

        if (s.Length != t.Length)
            return false;

        Dictionary<char, int> map = new Dictionary<char, int>();

        foreach (char ch in s)
        {

            if (!map.ContainsKey(ch))
                map[ch] = 0;   //Initialized to zero when it sees first time becoz C# doesn't have default zeros

            map[ch]++;
        }

        foreach (char ch in t)
        {
            if (!map.ContainsKey(ch))
                return false;

            map[ch]--;

            if (map[ch] < 0)
                return false;
        }

        return true;


    }



}