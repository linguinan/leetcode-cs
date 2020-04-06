/*
 * @lc app=leetcode.cn id=72 lang=csharp
 *
 * [72] 编辑距离
 */

// @lc code=start
using System;

public class Solution {
    /// <summary>
    /// 动态规划
    /// 当前字母距离等于少一个字符时的最小距离+1
    /// i，j位置的字符相同时，无距离增加
    /// dp[i-1][j-1] 表示替换操作，dp[i-1][j] 表示删除操作，dp[i][j-1] 表示插入操作
    /// </summary>
    /// <param name="word1"></param>
    /// <param name="word2"></param>
    /// <returns></returns>
    public int MinDistance (string word1, string word2) {
        int len1 = word1.Length, len2 = word2.Length;
        int[][] dp = new int[len1 + 1][];
        // word2为空时的删除操作次数
        for (int i = 0; i <= len1; i++) {
            dp[i] = new int[len2 + 1];
            dp[i][0] = i;
        }
        // word1为空时的插入操作次数
        for (int j = 0; j <= len2; j++) {
            dp[0][j] = j;
        }
        for (int i = 1; i <= len1; i++) {
            for (int j = 1; j <= len2; j++) {
                if (word1[i - 1] == word2[j - 1]) {
                    dp[i][j] = dp[i - 1][j - 1];
                } else {
                    int mid = Math.Min(dp[i - 1][j], dp[i][j - 1]);
                    dp[i][j] = 1 + Math.Min(mid, dp[i - 1][j - 1]);
                }
            }
        }
        return dp[len1][len2];
    }
}
// @lc code=end