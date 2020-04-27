/*
 * @lc app=leetcode.cn id=33 lang=csharp
 *
 * [33] 搜索旋转排序数组
 */

// @lc code=start
public class Solution {
    /// <summary>
    /// 二分搜索
    /// 判断有序部分，及target是否在其区间内
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int Search (int[] nums, int target) {
        int left = 0, right = nums.Length - 1;
        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (nums[mid] == target) return mid;
            if (nums[left] == target) return left;
            if (nums[right] == target) return right;
            // 左侧有序
            if (nums[left] < nums[mid]) {
                // 判断target是否在此区间
                if (nums[left] < target && nums[mid] > target) {
                    right = mid - 1;
                } else {
                    left = mid + 1;
                }
            } else {// 右侧有序
                if (nums[right] > target && nums[mid] < target) {
                    left = mid + 1;
                } else {
                    right = mid - 1;
                }
            }
        }
        return -1;
    }
}
// @lc code=end