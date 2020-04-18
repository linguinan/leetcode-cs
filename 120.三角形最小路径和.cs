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
    public int MinimumTotal (IList<IList<int>> triangle) {
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
}
// @lc code=end