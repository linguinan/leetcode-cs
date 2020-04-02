/*
 * @lc app=leetcode.cn id=119 lang=csharp
 *
 * [119] 杨辉三角 II
 */

// @lc code=start
using System.Collections.Generic;

public class Solution {
    public IList<int> GetRow (int rowIndex) {
        int count = rowIndex + 1;
        List<int> res = new List<int> (count);
        res.Add (1);
        List<int> tmp = new List<int> (count);
        for (int i = 1; i < count; i++) {
            tmp.Add (1);
            for (int j = 1; j < i; j++) {
                tmp.Add (res[j - 1] + res[j]);
            }
            tmp.Add (1);
            res.RemoveRange (0, res.Count);
            res.AddRange (tmp);
            tmp.RemoveRange (0, tmp.Count);
        }
        return res;
    }
}
// @lc code=end