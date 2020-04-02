/*
 * @lc app=leetcode.cn id=289 lang=csharp
 *
 * [289] 生命游戏
 */

// @lc code=start
public class Solution {
    public void GameOfLife (int[][] board) {
        int m = board.Length;
        if (m == 0) return;
        int n = board[0].Length;

        // 记录状态
        int[] state = new int[9] { 0, 0, 1, 1, 0, 0, 0, 0, 0 };
        int[][] dirs = {
            new int[] {-1, -1 },
            new int[] { 0, -1 },
            new int[] { 1, -1 },
            new int[] {-1, 0 },
            new int[] { 1, 0 },
            new int[] {-1, 1 },
            new int[] { 0, 1 },
            new int[] { 1, 1 }
        };

        int[][] result = new int[m][];
        int ti;
        int tj;
        for (int i = 0; i < m; i++) {
            result[i] = new int[n];
            for (int j = 0; j < n; j++) {
                // 统计周围活细胞数量
                int liveRounds = 0;
                foreach (var dir in dirs) {
                    ti = i + dir[0];
                    tj = j + dir[1];
                    if (ti >= 0 && ti < m && tj >= 0 && tj < n) {
                        liveRounds += board[ti][tj];
                    }
                }
                // 判断更新状态
                if (board[i][j] == 1) {
                    result[i][j] = state[liveRounds];
                } else {
                    result[i][j] = liveRounds == 3 ? 1 : 0;
                }
            }
        }
        // 更新到原数组
        for (int i = 0; i < m; i++) {
            board[i] = result[i];
        }
    }
}
// @lc code=end

int[][] dir = { new int[] {-1, 0 } };
System.Console.WriteLine (dir[0][0]);
System.Console.WriteLine (dir[0][1]);