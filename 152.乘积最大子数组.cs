/*
 * @lc app=leetcode.cn id=152 lang=csharp
 *
 * [152] 乘积最大子数组
 */

// @lc code=start
using System;

public class Solution {
    /// <summary>
    /// 记录每次遍历的最大和最小值，负数要记录，因为可能负负得正
    /// 当前位置的最优解未必是由前一个位置的最优解转移得到的
    /// 动态规划：iMax为到前一位累积的最大值，iMin为到前一位累积的最小值
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int MaxProduct (int[] nums) {
        int max = int.MinValue, iMax = 1, iMin = 1;
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] < 0) {
                // 遇到负数，大小倒转
                int tmp = iMax;
                iMax = iMin;
                iMin = tmp;
            }
            iMax = Math.Max (iMax * nums[i], nums[i]);
            iMin = Math.Min (iMin * nums[i], nums[i]);
            max = Math.Max (max, iMax);
        }
        return max;
    }
}
// @lc code=end