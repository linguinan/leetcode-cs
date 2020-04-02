/*
 * @lc app=leetcode.cn id=118 lang=csharp
 *
 * [118] 杨辉三角
 */

// @lc code=start
using System.Collections.Generic;

public class Solution {
    /// <summary>
    /// 每个元素都是其前一行的前一个下标值和当前下标值之和
    /// </summary>
    /// <param name="numRows"></param>
    /// <returns></returns>
    public IList<IList<int>> Generate (int numRows) {
        List<IList<int>> res = new List<IList<int>> ();
        if (numRows == 0) {
            return res;
        }
        res.Add (new List<int> () { 1 });
        for (int num = 1; num < numRows; num++) {
            IList<int> pre = res[num - 1];
            List<int> row = new List<int> (num + 1);
            row.Add (1);
            for (int i = 1; i < num; i++) {
                row.Add (pre[i - 1] + pre[i]);
            }
            row.Add (1);
            res.Add (row);
        }
        return res;
    }
}
// @lc code=end