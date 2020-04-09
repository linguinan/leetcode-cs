/*
 * @lc app=leetcode.cn id=529 lang=csharp
 *
 * [529] 扫雷游戏
 */

// @lc code=start
using System.Collections.Generic;

public class Solution {
    public char[][] UpdateBoard (char[][] board, int[] click) {
        int i = click[0], j = click[1];
        char c = board[i][j];
        if (c == 'M') {
            board[i][j] = 'X';
        } else if (c == 'E') {
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
            HashSet<string> visited = new HashSet<string> ();
            visited.Add (i + "_" + j);
            board[i][j] = checkNum (board, dirs, visited, i, j);
        }
        return board;
    }

    private char checkNum (char[][] board, int[][] dirs, HashSet<string> visited, int row, int col) {
        int i, j, ball = 0;
        List<int[]> list = new List<int[]> ();
        foreach (int[] dir in dirs) {
            i = row + dir[0];
            j = col + dir[1];
            if (i < 0 || i >= board.Length || j < 0 || j >= board[0].Length) continue;
            char c = board[i][j];
            if (c == 'M') {
                ball++;
            } else if (c == 'E') {
                if (visited.Contains (i + "_" + j)) continue;
                list.Add (new int[] { i, j });
            }
        }
        if (ball == 0) {
            foreach (int[] item in list) {
                i = item[0];
                j = item[1];
                visited.Add (i + "_" + j);
                board[i][j] = checkNum (board, dirs, visited, i, j);
            }
            return 'B';
        } else {
            return (char)(ball + '0');//char.Parse (ball.ToString ());
        }
    }
}
// @lc code=end