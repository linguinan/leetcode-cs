/*
 * @lc app=leetcode.cn id=704 lang=csharp
 *
 * [704] 二分查找
 */

// @lc code=start
public class Solution {
    /// <summary>
    /// 根据题意，注释的情况可以不做判断
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int Search (int[] nums, int target) {
        // if (nums.Length == 0) return -1;

        int left = 0, right = nums.Length - 1;
        // if (nums[left] > target || nums[right] < target)
        //     return -1;

        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (nums[mid] == target) {
                return mid;
            } else if (nums[mid] < target) {
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        return -1;
    }
}
// @lc code=end