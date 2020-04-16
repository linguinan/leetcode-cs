/*
 * @lc app=leetcode.cn id=56 lang=csharp
 *
 * [56] 合并区间
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution {
    /// <summary>
    /// 先排序，后判断是否重叠
    /// </summary>
    /// <param name="intervals"></param>
    /// <returns></returns>
    public int[][] Merge2 (int[][] intervals) {
        if (intervals.Length < 2) return intervals;
        Array.Sort (intervals, (x1, x2) => { return x1[0] < x2[0] ? -1 : 1; });
        int[][] arr = new int[intervals.Length][];
        int idx = -1;
        foreach (int[] interval in intervals) {
            if (idx == -1 || arr[idx][1] < interval[0]) {
                arr[++idx] = interval;
            } else {
                arr[idx][1] = Math.Max (arr[idx][1], interval[1]);
            }
        }
        if ((idx + 1) < arr.Length) {
            int[][] res = new int[idx + 1][];
            Array.Copy (arr, res, idx + 1);
            return res;
        }
        return arr;
    }

    public int[][] Merge (int[][] intervals) {
        if (intervals.Length < 2) return intervals;
        Array.Sort (intervals, (x1, x2) => { return x1[0] < x2[0] ? -1 : 1; });
        List<int[]> list = new List<int[]> ();
        int[] current = intervals[0];
        for (int i = 1; i < intervals.Length; i++)
        {
            if (current[1] < intervals[i][0]) {
                list.Add(current);
                current = intervals[i];
            } else {
                current[1] = Math.Max (current[1], intervals[i][1]);
            }
        }
        list.Add(current);
        return list.ToArray();
    }
}
// @lc code=end