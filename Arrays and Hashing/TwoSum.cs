/*
1.Two Sum
*/

public class TwoSum
{

    public int[] TwoSum(int[] nums, int target)
    {
        // Create a dictionary to store the numbers and their indices
        Dictionary<int, int> map = new Dictionary<int, int>();


        for (int i = 0; i < nums.Length; i++)
        {

            //Check if the complement (target - current number) exists in the dictionary
            int remainder = tatget - nums[i];

            if (map.ContainsKey(remainder))
            {

                //If exist, then return the index from the dictionary and the current index
                return new int[] { map[remainder], i };
            }

            //If not exist, add the current number and its index to the dictionary
            map[nums[i]] = i;
        }

        return new int[] { };


    }
}