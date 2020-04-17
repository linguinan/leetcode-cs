/*
 * @lc app=leetcode.cn id=55 lang=csharp
 *
 * [55] 跳跃游戏
 */

// @lc code=start
using System;

public class Solution {
    /// <summary>
    /// 贪心算法
    /// 每一步都算能达到都最远距离
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public bool CanJump (int[] nums) {
        int jumpMax = 0, lastIndex = nums.Length - 1;
        for (int i = 0; i < nums.Length; i++) {
            if (i <= jumpMax) {
                jumpMax = Math.Max (jumpMax, i + nums[i]);
                if (jumpMax >= lastIndex) return true;
            }
        }
        return false;
    }
}
// @lc code=end