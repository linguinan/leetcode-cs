/*
 * @lc app=leetcode.cn id=746 lang=csharp
 *
 * [746] 使用最小花费爬楼梯
 */

// @lc code=start
using System;

public class Solution {
    /// <summary>
    /// 用当前阶梯和前两阶梯花费比较取最小值
    /// </summary>
    /// <param name="cost"></param>
    /// <returns></returns>
    public int MinCostClimbingStairs2 (int[] cost) {
        int p1 = 0, p2 = 0, tmp = 0;
        for (int i = 1; i < cost.Length; i++) {
            tmp = p2;
            p2 = Math.Min (p2 + cost[i], p1 + cost[i - 1]);
            p1 = tmp;
        }
        return p2;
    }

    /// <summary>
    /// 动态规划    O(N)
    /// 反向计算，当前花费取决于前两阶梯的最小值
    /// </summary>
    /// <param name="cost"></param>
    /// <returns></returns>
    public int MinCostClimbingStairs3 (int[] cost) {
        int f1 = 0, f2 = 0, tmp = 0;
        for (int i = cost.Length - 1; i >= 0; i--) {
            tmp = cost[i] + Math.Min (f1, f2);
            f1 = f2;
            f2 = tmp;
        }
        return Math.Min (f1, f2);
    }

    public int MinCostClimbingStairs4 (int[] cost) {
        int[] dp = new int[cost.Length + 1];
        dp[0] = 0;
        dp[1] = cost[0];
        for (int i = 1; i < cost.Length; i++) {
            dp[i + 1] = Math.Min (cost[i] + dp[i], cost[i] + dp[i - 1]);
        }
        return Math.Min (dp[cost.Length - 1], dp[cost.Length]);
    }

    /// <summary>
    /// 不用函数调用会快一点点
    /// </summary>
    /// <param name="cost"></param>
    /// <returns></returns>
    public int MinCostClimbingStairs (int[] cost) {
        int[] dp = new int[cost.Length + 1];
        dp[0] = 0;
        dp[1] = cost[0];
        for (int i = 1; i < cost.Length; i++) {
            dp[i + 1] = cost[i] + dp[i] > cost[i] + dp[i - 1] ? cost[i] + dp[i - 1] : cost[i] + dp[i];
        }
        return dp[cost.Length - 1] > dp[cost.Length] ? dp[cost.Length] : dp[cost.Length - 1];
    }
}
// @lc code=end