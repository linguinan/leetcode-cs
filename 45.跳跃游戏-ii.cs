/*
 * @lc app=leetcode.cn id=45 lang=csharp
 *
 * [45] 跳跃游戏 II
 */

// @lc code=start
using System;

public class Solution {
    public int Jump (int[] nums) {
        int ans = 0, end = 0, max = 0;
        for (int i = 0; i < nums.Length - 1; i++) {
            max = Math.Max (max, nums[i] + i);
            if (i == end) {
                end = max;
                ans++;
            }
        }
        return ans;
    }
}
// @lc code=end