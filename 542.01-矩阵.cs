/*
 * @lc app=leetcode.cn id=542 lang=csharp
 *
 * [542] 01 矩阵
 */

// @lc code=start
using System.Collections.Generic;

public class Solution {
    /// <summary>
    /// BFS 从所有0元素出发遍历累加
    /// 把visited改为用值判断，耗时由560->436ms，beats 88%
    /// </summary>
    /// <param name="matrix"></param>
    /// <returns></returns>
    public int[][] UpdateMatrix (int[][] matrix) {
        int m = matrix.Length, n = matrix[0].Length;
        int[][] arr = new int[m][];
        // bool[][] visited = new bool[m][];
        Queue<KeyValuePair<int, int>> queue = new Queue<KeyValuePair<int, int>> ();
        for (int i = 0; i < m; i++) {
            arr[i] = new int[n];
            // visited[i] = new bool[n];
            for (int j = 0; j < n; j++) {
                if (matrix[i][j] == 0) {
                    queue.Enqueue (new KeyValuePair<int, int> (i, j));
                    // visited[i][j] = true;
                } else {
                    arr[i][j] = int.MaxValue;
                }
            }
        }
        int[][] dirs = { new int[] {-1, 0 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { 0, 1 } };
        int di, dj;
        while (queue.Count > 0) {
            KeyValuePair<int, int> item = queue.Dequeue ();
            for (int i = 0; i < 4; i++) {
                di = item.Key + dirs[i][0];
                dj = item.Value + dirs[i][1];
                if (di < 0 || di >= m || dj < 0 || dj >= n) continue;
                // if (visited[di][dj]) continue;
                if (arr[di][dj] > 1 + arr[item.Key][item.Value]) {
                    arr[di][dj] = 1 + arr[item.Key][item.Value];
                    // visited[di][dj] = true;
                    queue.Enqueue (new KeyValuePair<int, int> (di, dj));
                }
            }
        }
        return arr;
    }
}
// @lc code=end