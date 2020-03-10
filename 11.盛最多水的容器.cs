/*
 * @lc app=leetcode.cn id=11 lang=csharp
 *
 * [11] 盛最多水的容器
 */

// @lc code=start
using System;

public class Solution {
    public int MaxArea(int[] height) {
        int max = 0;
        for (int i = 0; i < height.Length; i++)
        {
            for (int j = i + 1; j < height.Length; j++)
            {
                int area = (j - i) * Math.Min(height[i], height[j]);
                max = Math.Max(max, area);
            }
        }
        return max;
    }
}
// @lc code=end

