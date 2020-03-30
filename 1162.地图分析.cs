/*
 * @lc app=leetcode.cn id=1162 lang=csharp
 *
 * [1162] 地图分析
 */

// @lc code=start
using System.Collections.Generic;

public class Solution {
    public int MaxDistance (int[][] grid) {
        int[] dx = { 0, 0, 1, -1 };
        int[] dy = { 1, -1, 0, 0 };

        Queue<int[]> que = new Queue<int[]> ();
        int m = grid.Length;
        int n = grid[0].Length;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 1) {
                    que.Enqueue (new int[] { i, j });
                }
            }
        }

        bool hasOcean = false;
        int[] pot = null;
        while (que.Count > 0) {
            pot = que.Dequeue ();
            int x = pot[0];
            int y = pot[1];
            for (int i = 0; i < 4; i++) {
                int newX = x + dx[i];
                int newY = y + dy[i];
                if (newX < 0 || newX >= m || newY < 0 || newY >= n || grid[newX][newY] != 0) {
                    continue;
                }
                grid[newX][newY] = grid[x][y] + 1;
                hasOcean = true;
                que.Enqueue (new int[] { newX, newY });
            }
        }

        if (pot == null || !hasOcean) {
            return -1;
        }
        return grid[pot[0]][pot[1]] - 1;
    }
}
// @lc code=end