/*
 * @lc app=leetcode.cn id=64 lang=csharp
 *
 * [64] 最小路径和
 */

// @lc code=start
using System;

public class Solution {
    /// <summary>
    /// 动态规划
    /// 逆推，自底向上
    /// </summary>
    /// <param name="grid"></param>
    /// <returns></returns>
    public int MinPathSum2 (int[][] grid) {
        int m = grid.Length, n = grid[0].Length, lastM = m - 1, lastN = n - 1;
        for (int i = lastM; i >= 0; i--) {
            for (int j = lastN; j >= 0; j--) {
                if (i == lastM && j != lastN)
                    grid[i][j] = grid[i][j] + grid[i][j + 1];
                else if (j == lastN && i != lastM)
                    grid[i][j] = grid[i][j] + grid[i + 1][j];
                else if (j != lastN && i != lastM)
                    grid[i][j] = grid[i][j] + Math.Min (grid[i + 1][j], grid[i][j + 1]);
            }
        }
        return grid[0][0];
    }

    public int MinPathSum (int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        for (int i = m - 1; i >= 0; i--) {
            for (int j = n - 1; j >= 0; j--) {
                if (i < m - 1 && j < n - 1) {
                     grid[i][j] += Math.Min(grid[i + 1][j], grid[i][j + 1]);
                }else if (i < m - 1) {
                    grid[i][j] += grid[i + 1][j];
                }else if (j < n - 1) {
                    grid[i][j] += grid[i][j + 1];
                }
            }
        }
        return grid[0][0];
    }
}
// @lc code=end