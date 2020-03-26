/*
 * @lc app=leetcode.cn id=892 lang=csharp
 *
 * [892] 三维形体的表面积
 */

// @lc code=start
using System;

public class Solution {
    public int SurfaceArea(int[][] grid) {
        int n = grid.Length;
        int area = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int level = grid[i][j];
                if (level > 0)
                {
                    area += (level << 2) + 2;
                    area -= i > 0 ? Math.Min(level, grid[i - 1][j]) << 1 : 0;
                    area -= j > 0 ? Math.Min(level, grid[i][j - 1]) << 1 : 0;
                }
            }
        }
        return area;
    }
}
// @lc code=end

static int Main(string[] args)
{
    int[][] grid = {new int[]{1, 2}, new int[]{3, 4}};
    System.Console.WriteLine(new Solution().SurfaceArea(grid));
    return 0;
}
Main(null);