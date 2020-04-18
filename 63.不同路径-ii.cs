/*
 * @lc app=leetcode.cn id=63 lang=csharp
 *
 * [63] 不同路径 II
 */

// @lc code=start
public class Solution {
    /// <summary>
    /// 动态规划
    /// 根前一题比就是多了个障碍物节点路径为0
    /// </summary>
    /// <param name="obstacleGrid"></param>
    /// <returns></returns>
    public int UniquePathsWithObstacles (int[][] obstacleGrid) {
        int m = obstacleGrid.Length, n = obstacleGrid[0].Length;
        int[][] res = new int[m][];
        for (int i = 0; i < m; i++) {
            res[i] = new int[n];
        }
        int lastM = m - 1, lastN = n - 1;
        for (int i = lastM; i >= 0; i--) {
            if (obstacleGrid[i][lastN] == 1) break;
            res[i][lastN] = 1;
        }
        for (int i = lastN; i >= 0; i--) {
            if (obstacleGrid[lastM][i] == 1) break;
            res[lastM][i] = 1;
        }
        for (int i = lastM - 1; i >= 0; i--) {
            for (int j = lastN - 1; j >= 0; j--) {
                if (obstacleGrid[i][j] != 1) {
                    res[i][j] = res[i + 1][j] + res[i][j + 1];
                }
            }
        }
        return res[0][0];
    }
}
// @lc code=end