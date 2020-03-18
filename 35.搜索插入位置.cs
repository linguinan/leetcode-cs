/*
 * @lc app=leetcode.cn id=35 lang=csharp
 *
 * [35] 搜索插入位置
 */

// @lc code=start
using System;

public class Solution {

    public int SearchInsert(int[] nums, int target) {
        int left = 0;
        int right = nums.Length - 1;
        while (left <= right) {
            int mid = (left + right) / 2;
            if (nums[mid] == target) 
                return mid;
            if (nums[mid] < target) {
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        return left;
    }

    public int SearchInsert2(int[] nums, int target) {
        if (nums[0] > target)
            return 0;
        if (nums[nums.Length - 1] < target)
            return nums.Length;
        // 二分查找
        return search(nums, target, 0, nums.Length - 1);
    }

    private int search(int[] nums, int target, int left, int right)
    {
        if (left >= right)
            return left;

        int half = (left + right) / 2;
        if (nums[half] == target)
            return half;

        if (nums[half] > target)
        {
            return search(nums, target, left, half);
        } else {
            return search(nums, target, half + 1, right);
        }
    }
}
// @lc code=end

