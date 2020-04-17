/*
 * @lc app=leetcode.cn id=1143 lang=csharp
 *
 * [1143] 最长公共子序列
 */

// @lc code=start
using System;

public class Solution {
    /// <summary>
    /// 动态规划
    /// 两个字符串，当作一个二维数组
    /// 当前坐标的最长公共子序列等于前一个+1或者较大值
    /// 关键在于从后往前看，找出重复性，拆分子问题
    /// </summary>
    /// <param name="text1"></param>
    /// <param name="text2"></param>
    /// <returns></returns>
    public int LongestCommonSubsequence (string text1, string text2) {
        if (string.IsNullOrEmpty (text1) || string.IsNullOrEmpty (text2)) return 0;
        int m = text1.Length, n = text2.Length;
        int[][] dp = new int[m + 1][];
        dp[0] = new int[n + 1];
        for (int i = 1; i < m + 1; i++) {
            dp[i] = new int[n + 1];
            for (int j = 1; j < n + 1; j++) {
                if (text1[i - 1] == text2[j - 1]) {
                    dp[i][j] = 1 + dp[i - 1][j - 1];
                } else {
                    dp[i][j] = Math.Max (dp[i - 1][j], dp[i][j - 1]);
                }
            }
        }
        return dp[m][n];
    }
}
// @lc code=end