/*


*/

public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {


        if (strs == null | strs.Length == 0)
            return "";

        //Start with first element as initial prefix
        string prefix = strs[0];

        for (int i = 1; i < strs.Length; i++)
        {

            //Keep checking prefix with current element and narrow it down
            //Prefix flower comparison with flow becomes flow


            // If new element does not start with existing prefix then go into loop to reduce
            while (!strs[i].StartsWith(prefix))
            {

                prefix = prefix.Substring(0, prefix.Length - 1);  //Reduce Prefix by one character

                if (prefix == "")
                    return "";

            }


        }

        return prefix;

    }
}