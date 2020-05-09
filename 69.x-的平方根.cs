/*
 * @lc app=leetcode.cn id=69 lang=csharp
 *
 * [69] x 的平方根
 */

// @lc code=start
public class Solution {
    /// <summary>
    /// 二分查找
    /// res 的平方 小于等于 x
    /// 用二分法缩小res的范围直至结果
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public int MySqrt (int x) {
        if (x == 0 || x == 1) return x;

        int left = 1, right = x, res = 0;
        while (left <= right) {
            int min = (left + right) >> 1;
            if (min == x / min)
                return min;
            if (min < x / min) {
                left = min + 1;
                res = min;
            } else {
                right = min - 1;
            }
        }
        return res;
    }
}
// @lc code=end