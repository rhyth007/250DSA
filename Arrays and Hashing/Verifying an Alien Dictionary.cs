/*
In an alien language, surprisingly, they also use English lowercase letters, but possibly in a different order. The order of the alphabet is some permutation of lowercase letters.
Given a sequence of words written in the alien language, and the order of the alphabet, return true if and only if the given words are sorted lexicographically in this alien language.

Example 1:
Input: words = ["hello","leetcode"], order = "hlabcdefgijkmnopqrstuvwxyz"
Output: true
Explanation: As 'h' comes before 'l' in this language, then the sequence is sorted.
Example 2:

Input: words = ["word","world","row"], order = "worldabcefghijkmnpqstuvxyz"
Output: false
Explanation: As 'd' comes after 'l' in this language, then words[0] > words[1], hence the sequence is unsorted.
Example 3:

Input: words = ["apple","app"], order = "abcdefghijklmnopqrstuvwxyz"
Output: false
Explanation: The first three characters "app" match, and the second string is shorter (in size.) According to lexicographical rules "apple" > "app", because 'l' > '∅', where '∅' is defined as the blank character which is less than any other character (More info).
 

Constraints:

1 <= words.length <= 100
1 <= words[i].length <= 20
order.length == 26
All characters in words[i] and order are English lowercase letters.



Intuition : 
Store the order in hashmap for comparision
If prefix+word appears before prefix then return false
Compare current word with next word in the loop and if you see current is having order greater then next then return false 
otherwise break the current loop


*/

public class Solution
{
    public bool IsAlienSorted(string[] words, string order)
    {

        Dictionary<char, int> map = new Dictionary<char, int>();

        for (int i = 0; i < order.Length; i++)
        {
            map[order[i]] = i;
        }

        for (int i = 0; i < words.Length - 1; i++)
        {

            for (int j = 0; j < words[i].Length; j++)
            {

                //Check for prefix and prefix+character condition
                if (j >= words[i + 1].Length)
                    return false;

                if (words[i][j] != words[i + 1][j])
                {
                    int currL = map[words[i][j]];
                    int nextL = map[words[i + 1][j]];

                    if (currL > nextL) return false;
                    else break;

                }



            }



        }

        return true;




    }
}