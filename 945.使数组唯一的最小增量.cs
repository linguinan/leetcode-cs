/*
 * @lc app=leetcode.cn id=945 lang=csharp
 *
 * [945] 使数组唯一的最小增量
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution {
    /// <code>
    /// 据题意分析出现元素的最大值80000
    /// 因为每个重复的数，都要累加到一个最近不重复的数，次数为n-x
    /// 则，先把遇到的重复数都减去，再在遇到不重复数时，直接加上值即可
    /// </code>
    public int MinIncrementForUnique(int[] A) {
        int[] count = new int[80000];
        foreach (var item in A)
        {
            count[item]++;
        }
        int ans = 0, taken = 0;
        for (int i = 0; i < count.Length; i++)
        {
            if (count[i] >= 2)
            {
                taken += count[i] - 1;
                ans -= i * (count[i] - 1);
            }
            else if (taken > 0 && count[i] == 0)
            {
                taken--;
                ans += i;
            }
        }
        return ans;
    }

    /// <code>
    /// 排序后只需要把后面的数变成比前一个数大一即可
    /// 对于重复的数，排序后直接累加
    /// </code>
    public int MinIncrementForUnique2(int[] A) {
        Array.Sort(A);
        int ans = 0;
        for (int i = 1; i < A.Length; i++)
        {
            if (A[i] <= A[i - 1])
            {
                ans += A[i - 1] - A[i] + 1;
                A[i] = A[i - 1] + 1;
            }
        }
        return ans;
    }
}
// @lc code=end

