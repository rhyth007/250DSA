public class Solution
{

    public string Encode(IList<string> strs)
    {
        string res = "";
        foreach (string s in strs)
        {
            res += s.Length + "#" + s;
        }
        return res;
    }
    // leet code  -- 4#leet4#code
    public List<string> Decode(string s)
    {
        List<string> res = new List<string>();

        int i = 0;
        int j = 0;

        while (i < s.Length)
        {
            j = i;
            while (s[j] != '#')
            {
                j++;
            }
            int len = int.Parse(s.Substring(i, j - i));
            i = j + 1;
            j = i + len;
            res.Add(s.Substring(i, len));
            i = j;
        }




        return res;

    }
}
