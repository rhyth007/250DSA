/*
Product except self =
(product of all elements to the LEFT of i) ×
(product of all elements to the RIGHT of i)
*/
class Solution
{
    public int[] ProductExceptSelf(int[] nums)
    {

        int[] res = new int[nums.Length];

        int pre = 1, post = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            res[i] = pre;
            pre = pre * nums[i];
        }
        // 1 2 3 4 --> 1 1 2 6 Prefix             1 2 3 4 --> 24 12 4 1 Postfix
        // 1 1 2 6 --> 24 12 8 6      
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            res[i] = res[i] * post;
            post = post * nums[i];

        }
        return res;
    }
}