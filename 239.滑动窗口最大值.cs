/*
 * @lc app=leetcode.cn id=239 lang=csharp
 *
 * [239] 滑动窗口最大值
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        if (nums.Length == 0) return new int[0];
        if (nums.Length < k) {
            int max = nums[0];
            for (int i = 1; i < nums.Length; i++)
                max = Math.Max(max, nums[i]);
            return new int[1]{max};
        }

        int count = nums.Length - k + 1;
        int[] res = new int[count];
        // 暴力法
        // for (int i = 0; i < count; i++)
        // {
        //     int max = nums[i];
        //     for (int j = i + 1; j < i + k; j++)
        //         max = Math.Max(max, nums[j]);
        //     res[i] = max;
        // }

        // 双端队列
        List<int> list = new List<int>();
        // init
        int maxIndex = 0;
        for (int i = 1; i < k; i++)
        {
            if (nums[i] >= nums[maxIndex])
            {
                list.Clear();
                maxIndex = i;
            }
            list.Add(i);
        }
        res[0] = nums[maxIndex];
        // 前k已算出max了，算后面的
        for (int i = k; i < nums.Length; i++)
        {
            
        }
        return res;
    }
}
// @lc code=end

