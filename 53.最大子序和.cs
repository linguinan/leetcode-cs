/*
 * @lc app=leetcode.cn id=53 lang=csharp
 *
 * [53] 最大子序和
 */

// @lc code=start
using System;

public class Solution {
    /// <summary>
    /// 动态规划
    /// 当前元素自身最大 或者 包含之前元素后最大
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int MaxSubArray2 (int[] nums) {
        int[] dp = nums;
        int max = dp[0];
        for (int i = 1; i < nums.Length; i++) {
            dp[i] = Math.Max (nums[i], nums[i] + dp[i - 1]);
            max = Math.Max (max, dp[i]);
        }
        return max;
    }

    public int MaxSubArray3 (int[] nums) {
        int max = nums[0];
        for (int i = 1; i < nums.Length; i++) {
            nums[i] = Math.Max (nums[i], nums[i] + nums[i - 1]);
            max = Math.Max (max, nums[i]);
        }
        return max;
    }

    public int MaxSubArray (int[] nums) {
        for (int i = 1; i < nums.Length; i++) {
            nums[i] = Math.Max (nums[i], nums[i] + nums[i - 1]);
        }
        Array.Sort(nums);
        return nums[nums.Length - 1];
    }
}
// @lc code=end