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
        int count = nums.Length;
        if (count == 0) return new int[0];
        if (count < k) {
            int max = nums[0];
            for (int i = 1; i < count; i++)
                max = Math.Max(max, nums[i]);
            return new int[1]{max};
        }

        int[] res = new int[count - k + 1];
        // 暴力法
        // for (int i = 0; i < res.Length; i++)
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
            if (nums[i] > nums[maxIndex])
                maxIndex = i;
        }
        // 从maxIndex到k，把小于k到都忽略
        for (int i = maxIndex; i < k; i++)
        {
            // 如果后面的比前面的大，则前面已加list的都不要了
            while (list.Count > 0 && nums[i] > nums[list[list.Count - 1]]) {
                list.RemoveAt(list.Count - 1);
            }
            list.Add(i);
        }
        int curIndex = 0;
        res[curIndex] = nums[maxIndex];
        // 前k已算出max了，算后面的
        for (int i = k; i < count; i++)
        {
            // 右移一位
            if ((i - list[0] + 1) > k)
            {
                list.RemoveAt(0);
            }
            // 如第i的值大于list中最后的值，则之前的都废弃
            while (list.Count > 0 && nums[i] > nums[list[list.Count - 1]])
            {
                list.RemoveAt(list.Count - 1);
            }
            // 始终保证list第一个元素最大
            list.Add(i);
            res[++curIndex] = nums[list[0]];
        }
        return res;
    }
}
// @lc code=end

