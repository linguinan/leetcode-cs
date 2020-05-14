/*
 * @lc app=leetcode.cn id=200 lang=csharp
 *
 * [200] 岛屿数量
 */

// @lc code=start
using System.Collections.Generic;

public class Solution {
    /// <summary>
    /// BFS 把相邻的‘1’都转为‘0’,用来标记已访问过
    /// </summary>
    /// <param name="grid"></param>
    /// <returns></returns>
    public int NumIslands2 (char[][] grid) {
        if (grid.Length == 0) return 0;

        int[][] dirs = {
            new int[] { 0, -1 },
            new int[] { 0, 1 },
            new int[] {-1, 0 },
            new int[] { 1, 0 },
        };

        Queue<KeyValuePair<int, int>> queue = new Queue<KeyValuePair<int, int>> ();
        int ans = 0;
        int m = grid.Length, n = grid[0].Length;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == '1') {
                    ans++;
                    grid[i][j] = '0';
                    queue.Enqueue (new KeyValuePair<int, int> (i, j));
                    while (queue.Count > 0) {
                        var pair = queue.Dequeue ();
                        int pi = pair.Key;
                        int pj = pair.Value;
                        foreach (int[] dir in dirs) {
                            int ti = pi + dir[0];
                            int tj = pj + dir[1];
                            if (ti >= 0 && ti < m && tj >= 0 && tj < n && grid[ti][tj] == '1') {
                                grid[ti][tj] = '0';
                                queue.Enqueue (new KeyValuePair<int, int> (ti, tj));
                            }
                        }
                    }
                }
            }
        }
        return ans;
    }

    public int NumIslands3 (char[][] grid) {
        if (grid.Length == 0) return 0;
        int[] dx = {-1, 1, 0, 0 }, dy = { 0, 0, -1, 1 };
        Queue<KeyValuePair<int, int>> queue = new Queue<KeyValuePair<int, int>> ();
        int ans = 0, m = grid.Length, n = grid[0].Length;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == '1') {
                    ans++;
                    grid[i][j] = '0';
                    queue.Enqueue (new KeyValuePair<int, int> (i, j));
                    while (queue.Count > 0) {
                        var kv = queue.Dequeue ();
                        for (int k = 0; k < 4; k++) {
                            int ti = kv.Key + dx[k], tj = kv.Value + dy[k];
                            if (ti < 0 || ti >= m || tj < 0 || tj >= n) continue;
                            if (grid[ti][tj] == '1') {
                                grid[ti][tj] = '0';
                                queue.Enqueue (new KeyValuePair<int, int> (ti, tj));
                            }
                        }
                    }
                }
            }
        }
        return ans;
    }

    /// <summary>
    /// 用并查集再实现一遍
    /// 注意下标是 i * col + j
    /// </summary>
    /// <param name="grid"></param>
    /// <returns></returns>
    public int NumIslands (char[][] grid) {
        if (grid == null || grid.Length == 0) return 0;
        int[] dx = {-1, 1, 0, 0 }, dy = { 0, 0, -1, 1 };
        int row = grid.Length, col = grid[0].Length;
        UnionFind uf = new UnionFind (grid);
        for (int i = 0; i < row; i++) {
            for (int j = 0; j < col; j++) {
                if (grid[i][j] == '1') {
                    grid[i][j] = '0';//不用再查
                    // join union round
                    for (int k = 0; k < 4; k++) {
                        int ti = i + dx[k], tj = j + dy[k];
                        if (ti < 0 || ti >= row || tj < 0 || tj >= col) continue;
                        if (grid[ti][tj] == '1') {
                            // grid[ti][tj] = '0';//需继续扩散出去
                            uf.Union (i * col + j, ti * col + tj);
                        }
                    }
                }
            }
        }
        return uf.GetCount ();
    }

    class UnionFind {
        // 集合数
        private int count;
        // 头目数组，值表示头目id
        private int[] parent;
        // 层级，值越高的层级越高
        private int[] rank;
        public UnionFind (char[][] grid) {
            int row = grid.Length, col = grid[0].Length;
            count = 0;
            parent = new int[row * col];
            rank = new int[row * col];
            for (int i = 0; i < row; i++) {
                for (int j = 0; j < col; j++) {
                    if (grid[i][j] == '1') {
                        parent[i * col + j] = i * col + j;
                        count++;
                    }
                }
            }
        }

        /// <summary>
        /// 把同个集合的加入来
        /// </summary>
        public void Union (int x, int y) {
            int px = Find (x), py = Find (y);
            if (px != py) {
                if (rank[px] > rank[py]) {
                    parent[py] = px;
                } else if (rank[px] < rank[py]) {
                    parent[px] = py;
                } else {
                    parent[py] = px;
                    rank[px]++;
                }
                count--;
            }
        }

        // 往上追溯头目
        public int Find (int i) {
            if (parent[i] != i) parent[i] = Find (parent[i]);
            return parent[i];
        }

        public int GetCount () {
            return count;
        }
    }
}
// @lc code=end