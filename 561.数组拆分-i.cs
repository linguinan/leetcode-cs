/*
 * @lc app=leetcode.cn id=561 lang=csharp
 *
 * [561] 数组拆分 I
 */

// @lc code=start
using System;

public class Solution {
    /// <summary>
    /// 排序，间隔累加
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int ArrayPairSum2 (int[] nums) {
        Array.Sort (nums);
        int ans = 0;
        int n = nums.Length;
        for (int i = 0; i < n - 1; i += 2) {
            ans += nums[i];
        }
        return ans;
    }

    /// <summary>
    /// 空间换时间
    /// 执行用时 :160 ms, 在所有 C# 提交中击败了100.00%的用户
    /// 根据奇偶数累加，2倍数的直接乘积
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int ArrayPairSum (int[] nums) {
        int[] map = new int[20001];
        int sep = 10000;
        foreach (int num in nums) {
            map[num + sep]++;
        }
        int ans = 0;
        int idx = 0;
        for (int i = -10000; i <= 10000; i++) {
            int cnt = map[i + sep];
            if (cnt > 0) {
                if (idx % 2 == 0) {
                    ans += i;
                    cnt--;
                    idx++;
                }
                if (cnt > 0) {
                    ans += (cnt / 2) * i;
                    if (cnt % 2 == 1) {
                        idx++;
                    }
                }
            }
        }
        return ans;
    }
}
// @lc code=end

static int Main(string[] args)
{
    System.Console.WriteLine(new Solution().ArrayPairSum(new int[]{1,4,3,2}));//4
    System.Console.WriteLine(new Solution().ArrayPairSum(new int[]{1,2,3,2}));//3
    System.Console.WriteLine(new Solution().ArrayPairSum(new int[]{1,1,1,1}));//2
    return 0;
}
Main (null);