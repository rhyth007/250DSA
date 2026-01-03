/*
49. Group Anagrams
Given an array of strings strs, group the anagrams together. You can return the answer in any order.
Example 1:

Input: strs = ["eat","tea","tan","ate","nat","bat"]

Output: [["bat"],["nat","tan"],["ate","eat","tea"]]

Explanation:

There is no string in strs that can be rearranged to form "bat".
The strings "nat" and "tan" are anagrams as they can be rearranged to form each other.
The strings "ate", "eat", and "tea" are anagrams as they can be rearranged to form each other.
Example 2:

Input: strs = [""]

Output: [[""]]

Example 3:

Input: strs = ["a"]

Output: [["a"]]



Brute Force:
Two For Loops and check everytime if its a anagram and use visited array to not check the already visited one
Use 2 List one for result and another for the group anagram

Optimal :


*/



using System.Text;

public class Solution
{


    //Brute Force
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {

        List<List<string>> result = new List<List<string>>();
        bool[] vis = new bool[strs.Length];

        for (int i = 0; i < strs.Length; i++)
        {
            if (vis[i]) continue;

            List<string> group = new List<string>();
            group.Add(strs[i]);
            vis[i] = true;


            for (int j = i + 1; j < strs.Length; j++)
            {

                if (!vis[i] && isAnagram(strs[i], strs[j]))
                {
                    group.Add(strs[j]);
                    vis[j] = true;
                }

            }


            result.Add(group);

        }

        return result.ToList<IList<string>>();

    }

    public static isAnagram(string s, string t)
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


    //Optimal Approach

    /*
    Use Hashing 
    Input: strs = ["eat","tea","tan","ate","nat","bat"]

    Logic : The no of character count is same in anagrams, so we use generate key using the frequency count
    and that will be used a key and values will be anagram groups


    */
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {

        Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

        int[] count = new int[26];

        foreach (string s in strs)
        {

            foreach (char ch in s.ToCharArray())
            {
                count[ch - 'a']++;
            }

            StringBuilder sb = new StringBuilder("");

            //Generate a Unique key based on the frequency (eat and ate will have same key)
            for (int i = 0; i < 26; i++)
            {
                sb.Append("#");
                sb.Append(count[i]);
            }

            string key = sb.ToString();

            //Check if hashmap contains that key

            if (!map.ContainsKey(key))
            {
                map[key] = new List<string>();
            }

            map[key].Add(s);  // To insert value for exisitng key

        }


        return map.Values.ToList<IList<string>>();


    }



}

