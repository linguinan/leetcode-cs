/*
 * @lc app=leetcode.cn id=62 lang=csharp
 *
 * [62] 不同路径
 */

// @lc code=start
using System;

public class Solution {
    /// <summary>
    /// 动态规划 时空复杂度都为O(m*n)
    /// 关键在于分析出，最后一行一列的路径是固定的1
    /// </summary>
    /// <param name="m"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public int UniquePaths (int m, int n) {
        int[][] res = new int[m][];
        for (int i = 0; i < m; i++) {
            res[i] = new int[n];
        }
        int lastM = m - 1, lastN = n - 1;
        for (int i = 0; i < m; i++) {
            res[i][lastN] = 1;
        }
        for (int i = 0; i < n; i++) {
            res[lastM][i] = 1;
        }
        for (int i = lastM - 1; i >= 0; i--) {
            for (int j = lastN - 1; j >= 0; j--) {
                res[i][j] = res[i + 1][j] + res[i][j + 1];
            }
        }
        return res[0][0];
    }
}
// @lc code=end