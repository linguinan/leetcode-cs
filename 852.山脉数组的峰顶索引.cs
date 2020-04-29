/*
 * @lc app=leetcode.cn id=852 lang=csharp
 *
 * [852] 山脉数组的峰顶索引
 */

// @lc code=start
public class Solution {
    /// <summary>
    /// 二分查找
    /// 根据中间元素与其相邻元素的比较得出下一次循环的区间
    /// </summary>
    /// <param name="A"></param>
    /// <returns></returns>
    public int PeakIndexInMountainArray (int[] A) {
        int left = 0, right = A.Length - 1;
        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (A[mid] < A[mid + 1]) {
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        return left;
    }
}
// @lc code=end