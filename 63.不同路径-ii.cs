/*
 * @lc app=leetcode.cn id=63 lang=csharp
 *
 * [63] 不同路径 II
 */

// @lc code=start
public class Solution {
    /// <summary>
    /// 动态规划    O(MN)
    /// 自底向上
    /// 跟前一题比就是多了个障碍物节点路径为0
    /// </summary>
    /// <param name="obstacleGrid"></param>
    /// <returns></returns>
    public int UniquePathsWithObstacles2 (int[][] obstacleGrid) {
        int m = obstacleGrid.Length, n = obstacleGrid[0].Length;
        // init
        int[][] res = new int[m][];
        for (int i = 0; i < m; i++) {
            res[i] = new int[n];
        }
        // set bottom value
        int lastM = m - 1, lastN = n - 1;
        for (int i = lastM; i >= 0; i--) {
            if (obstacleGrid[i][lastN] == 1) break;
            res[i][lastN] = 1;
        }
        for (int i = lastN; i >= 0; i--) {
            if (obstacleGrid[lastM][i] == 1) break;
            res[lastM][i] = 1;
        }
        // dp
        for (int i = lastM - 1; i >= 0; i--) {
            for (int j = lastN - 1; j >= 0; j--) {
                if (obstacleGrid[i][j] == 1) continue;
                res[i][j] = res[i + 1][j] + res[i][j + 1];
            }
        }
        return res[0][0];
    }

    /// <summary>
    /// 利用原数组，自顶向下
    /// </summary>
    /// <param name="obstacleGrid"></param>
    /// <returns></returns>
    public int UniquePathsWithObstacles (int[][] obstacleGrid) {
        if (obstacleGrid[0][0] == 1) return 0;
        int m = obstacleGrid.Length, n = obstacleGrid[0].Length;
        obstacleGrid[0][0] = 1;
        for (int i = 1; i < n; i++) {
            obstacleGrid[0][i] = (obstacleGrid[0][i] == 0 && obstacleGrid[0][i - 1] == 1) ? 1 : 0;
        }
        for (int i = 1; i < m; i++) {
            obstacleGrid[i][0] = (obstacleGrid[i][0] == 0 && obstacleGrid[i - 1][0] == 1) ? 1 : 0;
        }
        for (int i = 1; i < m; i++) {
            for (int j = 1; j < n; j++) {
                if (obstacleGrid[i][j] == 0) {
                    obstacleGrid[i][j] = obstacleGrid[i - 1][j] + obstacleGrid[i][j - 1];
                } else {
                    obstacleGrid[i][j] = 0;
                }
            }
        }
        return obstacleGrid[m - 1][n - 1];
    }
}
// @lc code=end