
public static string MinWindow(string s, string t)
{
    if (s.Length == 0 || t.Length == 0) return "";

    // Step 1: Build need map
    Dictionary<char, int> need = new Dictionary<char, int>();
    foreach (char c in t)
    {
        if (!need.ContainsKey(c)) need[c] = 0;
        need[c]++;
    }

    Dictionary<char, int> window = new Dictionary<char, int>();
    int have = 0, needCount = need.Count;
    int resLen = int.MaxValue;
    int resStart = 0;

    int l = 0;
    for (int r = 0; r < s.Length; r++)
    {
        char c = s[r];
        if (!window.ContainsKey(c)) window[c] = 0;
        window[c]++;

        if (need.ContainsKey(c) && window[c] == need[c])
            have++;

        // Step 2: Try to shrink window
        while (have == needCount)
        {
            if (r - l + 1 < resLen)
            {
                resLen = r - l + 1;
                resStart = l;
            }

            char leftChar = s[l];
            window[leftChar]--;
            if (need.ContainsKey(leftChar) && window[leftChar] < need[leftChar])
                have--;

            l++;
        }
    }

    return resLen == int.MaxValue ? "" : s.Substring(resStart, resLen);
}
