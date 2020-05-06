/*
 * @lc app=leetcode.cn id=983 lang=csharp
 *
 * [983] 最低票价
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution {
    private int[] memo;
    private HashSet<int> daySet;
    private int[] costs;

    /// <summary>
    /// 动态规划
    /// 倒着计算，记录最小花费
    /// </summary>
    /// <param name="days"></param>
    /// <param name="costs"></param>
    /// <returns></returns>
    public int MincostTickets2 (int[] days, int[] costs) {
        this.costs = costs;
        this.memo = new int[366];
        this.daySet = new HashSet<int> ();
        foreach (int day in days)
            daySet.Add (day);
        return dp2 (1);
    }

    private int dp2 (int i) {
        if (i > 365) return 0;
        if (memo[i] > 0) return memo[i];
        if (daySet.Contains (i)) {
            memo[i] = Math.Min (Math.Min (dp2 (i + 1) + costs[0], dp2 (i + 7) + costs[1]), dp2 (i + 30) + costs[2]);
        } else {
            memo[i] = dp2 (i + 1);
        }
        return memo[i];
    }

    private int[] days;
    private int[] durs = new int[3] { 1, 7, 30 };

    /// <summary>
    /// 动态规划 + 剪枝
    /// </summary>
    /// <param name="days"></param>
    /// <param name="costs"></param>
    /// <returns></returns>
    public int MincostTickets (int[] days, int[] costs) {
        this.days = days;
        this.costs = costs;
        this.memo = new int[days.Length];
        return dp (0);
    }

    private int dp (int i) {
        if (i >= days.Length) return 0;
        if (memo[i] > 0) return memo[i];
        int j = i;
        memo[i] = int.MaxValue;
        for (int k = 0; k < 3; k++) {
            while (j < days.Length && days[j] < days[i] + durs[k]) j++;
            memo[i] = Math.Min (memo[i], dp (j) + costs[k]);
        }
        return memo[i];
    }
}
// @lc code=end