/*
📌 Problem: Encode and Decode Strings (LeetCode #271)
Description:  
Design an algorithm to encode a list of strings into a single string. The encoded string is then sent over the network and must be decoded back to the original list of strings.

You need to implement two functions:

encode(List<String> strs) → converts a list of strings into one encoded string.

decode(String s) → converts the encoded string back into the original list of strings.

Constraints:

Strings may contain any characters (including spaces, special characters, or delimiters).

Your encoding scheme must ensure that decoding always reconstructs the exact original list.

You cannot use built-in serialization methods (like eval or JSON libraries).

*/
public class Codec
{
    // Encodes a list of strings to a single string.
    public string Encode(IList<string> strs)
    {


        //Send some special ASCII char
        if (strs.Count == 0)
        {
            return ((char)258).ToString();
        }

        string separator = ((char)257).ToString();
        StringBuilder sb = new StringBuilder();

        foreach (string s in strs)
        {
            sb.Append(s);
            sb.Append(separator);
        }

        // Remove the last separator
        sb.Length -= 1;

        return sb.ToString();
    }

    public IList<string> Decode(string s)
    {
        if (s.Equals(((char)258).ToString()))
            return new List<string>();

        string separator = ((char)257).ToString();
        List<string> result = new List<string>();

        int start = 0;
        while (true)
        {

            //abc^abcd
            int idx = s.IndexOf(separator, start);
            if (idx == -1)
            {
                // last piece
                result.Add(s.Substring(start));
                break;
            }
            result.Add(s.Substring(start, idx - start));
            start = idx + separator.Length;
        }

        return result;
    }



}

public class Codec
{
    // Encodes a list of strings to a single string.
    public string Encode(IList<string> strs)
    {
        StringBuilder sb = new StringBuilder();
        foreach (string str in strs)
        {
            // Store length + delimiter + string
            sb.Append(str.Length).Append('#').Append(str);
        }
        return sb.ToString();
    }

    // Decodes a single string to a list of strings.
    public IList<string> Decode(string s)
    {
        List<string> result = new List<string>();
        int i = 0;

        while (i < s.Length)
        {
            // Find the delimiter '#'
            int j = i;
            while (s[j] != '#') j++;

            // Extract length    4#abcd3#abc  Substring(index, length)
            int length = int.Parse(s.Substring(i, j - i));

            // Extract the string of that length
            string str = s.Substring(j + 1, length);
            result.Add(str);

            // Move pointer forward
            i = j + 1 + length;
        }

        return result;
    }
}

