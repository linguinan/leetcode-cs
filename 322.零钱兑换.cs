/*
 * @lc app=leetcode.cn id=322 lang=csharp
 *
 * [322] 零钱兑换
 */

// @lc code=start
using System;

public class Solution {
    /// <summary>
    /// 贪心 + DFS
    /// 递归 + 回溯 + 剪枝 找出所有解
    /// </summary>
    /// <param name="coins"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public int CoinChange (int[] coins, int amount) {
        Array.Sort (coins);
        // System.Console.WriteLine(string.Join(",", coins));
        int ans = int.MaxValue;
        dfs (coins, amount, coins.Length - 1, 0, ref ans);
        return ans == int.MaxValue ? -1 : ans;
    }

    private void dfs (int[] coins, int amount, int index, int count, ref int ans) {
        // terminator
        if (amount == 0) {
            ans = Math.Min (ans, count);
            return;
        }
        if (index < 0) return;
        // process
        for (int i = amount / coins[index]; i >= 0 && (i + count) < ans; i--) {
            // drill down
            dfs (coins, amount - i * coins[index], index - 1, count + i, ref ans);
        }
    }

    // /// <summary>
    // /// 动态规划递推树 + BFS
    // /// 从总额起，减去可能的硬币，剩0时截止
    // /// </summary>
    // /// <param name="coins"></param>
    // /// <param name="amount"></param>
    // /// <returns></returns>
    // public int CoinChange(int[] coins, int amount) {
    // }
}
// @lc code=end