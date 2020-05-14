/*
 * @lc app=leetcode.cn id=136 lang=csharp
 *
 * [136] 只出现一次的数字
 */

// @lc code=start
public class Solution {
    /// <summary>
    /// 位运算
    /// 异或：相同为0，不同为1
    /// x ^ x = 0
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int SingleNumber2 (int[] nums) {
        int ret = 0;
        foreach (var num in nums)
            ret ^= num;
        return ret;
    }

    /// <summary>
    /// for 比 foreach 快很多
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int SingleNumber(int[] nums) {
        int ret = 0;
        for(int i = 0; i < nums.Length; i++) {
            ret ^= nums[i];
        }
        return ret;
    }
}
// @lc code=end