/*
Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.
Example 1:

Input: nums = [1,1,1,2,2,3], k = 2

Output: [1,2]

Example 2:

Input: nums = [1], k = 1

Output: [1]

Example 3:

Input: nums = [1,2,1,2,1,2,3,1,3,2], k = 2

Output: [1,2]

*/

/*
Brute Force :
Calculate the frequency of the elements using HashMap
Sort the elements with frequency and return those.


Time Complexity : O(nlogn)
Space Complexity : O(n)
*/
public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {


        Dictionary<int, int> freqMap = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {

            if (freqMap.ContainsKey(nums[i]))
            {
                // freqMap[nums[i]] = freqMap[nums[i]] + 1;
                // freqMap[nums[i]] = freqMap.GetValueOrDefault(nums[i],0)+1;
                freqMap[nums[i]]++;
            }
            else
            {
                freqMap[nums[i]] = 1;
            }

        }

        /*
        Input: nums = [1,1,1,2,2,3], k = 2
        1 -> 3
        2 -> 2
        3 -> 1

        Output: [1,2]
        Multiple approaches for sorting the hashmaps     
        */
        List<KeyValuePair<int, int>> sortedList = freqMap.OrderByDescending(entry => entry.Value).ToList();

        //List<KeyValuePair<int, int>> sortedList = new List<KeyValuePair<int, int>>(freqMap);
        //sortedList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));  --> Descending
        //sortedList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));  --> Ascending

        //Return k elements
        int[] res = new int[k];

        for (int i = 0; i < k; i++)
        {
            res[i] = sortedList[i].Key;
        }

        return res;

    }


    /*
    Optimal Approach
    1)Store the Frequencies in HashMap
    2)Use Priority Queue to store the Top K elements
    Went from O(nlogn) to O(nlogk)
    Time Complexity -> O(nlogk)
    */
    public int[] TopKFrequent(int[] nums, int k)
    {

        Dictionary<int, int> freqMap = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {

            if (freqMap.ContainsKey(nums[i]))
            {
                freqMap[nums[i]]++;
            }
            else
            {
                freqMap[nums[i]] = 1;
            }
        }


        //Priority Queue by default has elements and its priority... It dequeues one with lowest priority first
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

        //Read Elements from HashMap

        foreach (KeyValuePair<int, int> entry in freqMap)
        {

            pq.Enqueue(entry.Key, entry.Value);  //Insert element and its frequency

            if (pq.Count > k)
            {
                pq.Dequeue();
            }

        }
        int[] res = new int[k];

        for (int i = 0; i < k; i++)
        {
            res[i] = pq.Dequeue();
        }

        return res;


    }

}