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
    public int MincostTickets (int[] days, int[] costs) {
        this.costs = costs;
        this.memo = new int[366];
        this.daySet = new HashSet<int> ();
        foreach (int day in days)
            daySet.Add (day);
        return dp (1);
    }

    private int dp (int i) {
        if (i > 365) return 0;
        if (memo[i] > 0) return memo[i];
        if (daySet.Contains (i)) {
            memo[i] = Math.Min (Math.Min (dp (i + 1) + costs[0], dp (i + 7) + costs[1]), dp (i + 30) + costs[2]);
        } else {
            memo[i] = dp (i + 1);
        }
        return memo[i];
    }
}
// @lc code=end