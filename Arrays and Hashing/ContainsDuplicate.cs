/*
217. Contains Duplicate
*/

public class ContainsDuplicateSolution
{

    //Using Dictionary
    public bool ContainsDuplicate(int[] nums)
    {

        Dictionary<int, int> map = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (map.ContainsKey(nums[i])) return true;
            map[nums[i]] = map.GetValueOrDefault(nums[i], 0) + 1;
        }



        return false;

    }


    //Using HashSet
    public bool ContainsDuplicate(int[] nums)
    {

        HashSet<int> set = new HashSet<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (set.Contains(nums[i])) return true;
            set.Add(nums[i]);
        }



        return false;

    }
}