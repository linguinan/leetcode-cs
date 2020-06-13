using System;
using System.Collections.Generic;

public class Solution {
    private int m, n, k;
    private bool[][] visited;
    /// <summary>
    /// 深度优先搜索
    /// </summary>
    /// <param name="m"></param>
    /// <param name="n"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public int MovingCount2 (int m, int n, int k) {
        this.m = m;
        this.n = n;
        this.k = k;
        this.visited = new bool[m][];
        for (int i = 0; i < m; i++) {
            this.visited[i] = new bool[n];
        }
        return dfs (0, 0, 0, 0);
    }

    public int dfs (int i, int j, int si, int sj) {
        if (i >= m || j >= n || k < (si + sj) || visited[i][j]) return 0;
        visited[i][j] = true;
        return 1 + dfs (i + 1, j, (i + 1) % 10 != 0 ? si + 1 : si - 8, sj) + dfs (i, j + 1, si, (j + 1) % 10 != 0 ? sj + 1 : sj - 8);
    }

    /// <summary>
    /// 广度优先搜索
    /// </summary>
    /// <param name="m"></param>
    /// <param name="n"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public int MovingCount (int m, int n, int k) {
        bool[][] visited = new bool[m][];
        for (int i = 0; i < m; i++) {
            visited[i] = new bool[n];
        }
        int[][] dirs = { new int[] { 1, 0 }, new int[] { 0, 1 } };
        Queue<KeyValuePair<int, int>> queue = new Queue<KeyValuePair<int, int>> ();
        queue.Enqueue (new KeyValuePair<int, int> (0, 0));
        int ans = 1;
        while (queue.Count > 0) {
            int size = queue.Count;//每次都把queue清空会计算更快
            for (int i = 0; i < size; i++) {
                var node = queue.Dequeue ();
                for (int j = 0; j < 2; j++) {
                    int dx = dirs[j][0] + node.Key;
                    int dy = dirs[j][1] + node.Value;
                    if (dx >= m || dy >= n || visited[dx][dy] || sum (dx) + sum (dy) > k) continue;
                    queue.Enqueue (new KeyValuePair<int, int> (dx, dy));
                    visited[dx][dy] = true;
                    ans++;
                }
            }
        }
        return ans;
    }

    private int sum (int value) {
        // System.Console.Write ("value : " + value);
        int res = 0;
        // while (value > 0) {
        //     res += value % 10;
        //     value /= 10;
        // }
        for (int i = value; i > 0; i /= 10) {
            res += i % 10;
        }
        // System.Console.WriteLine (" | res : " + res);
        return res;
    }
}

static int Main (string[] args) {
    Solution solution = new Solution ();
    // int res = solution.MovingCount (7, 2, 3);//7
    int res = solution.MovingCount (38, 15, 9);//135
    System.Console.WriteLine (res);
    return 0;
}
Main (null);