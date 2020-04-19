/*
 * @lc app=leetcode.cn id=120 lang=csharp
 *
 * [120] 三角形最小路径和
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution {
    /// <summary>
    /// 动态规划
    /// 自底向上，最底层的值已定
    /// </summary>
    /// <param name="triangle"></param>
    /// <returns></returns>
    public int MinimumTotal2 (IList<IList<int>> triangle) {
        List<IList<int>> resList = new List<IList<int>> (triangle.Count);
        int lastIndex = triangle.Count - 1;
        for (int i = 0; i < triangle.Count; i++) {
            resList.Add (new List<int> (triangle[i].Count));
        }
        resList[lastIndex] = triangle[lastIndex];
        for (int i = lastIndex - 1; i >= 0; i--) {
            resList[i] = new List<int> (triangle[i].Count);
            for (int j = 0; j < triangle[i].Count; j++) {
                resList[i].Add (Math.Min (resList[i + 1][j], resList[i + 1][j + 1]) + triangle[i][j]);
            }
        }
        return resList[0][0];
    }

    /// <summary>
    /// 改用一层数组缓存结果
    /// </summary>
    /// <param name="triangle"></param>
    /// <returns></returns>
    public int MinimumTotal (IList<IList<int>> triangle) {
        if (triangle == null || triangle.Count == 0) return 0;
        int lastIndex = triangle.Count - 1;
        int[] res = new int[triangle[lastIndex].Count];
        for (int i = 0; i < triangle[lastIndex].Count; i++) {
            res[i] = triangle[lastIndex][i];
        }
        for (int i = lastIndex - 1; i >= 0; i--) {
            for (int j = 0; j < triangle[i].Count; j++) {
                res[j] = Math.Min (res[j], res[j + 1]) + triangle[i][j];
            }
        }
        return res[0];
    }
}
// @lc code=end