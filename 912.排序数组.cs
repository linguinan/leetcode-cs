/*
 * @lc app=leetcode.cn id=912 lang=csharp
 *
 * [912] 排序数组
 */

// @lc code=start
using System;
using System.Collections.Generic;
using System.Text;

public class Solution {
    /// <summary>
    /// 归并排序
    /// 分而治之
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int[] SortArray (int[] nums) {
        if (nums.Length == 1) return nums;
        int[] tmp = new int[nums.Length];
        sort (nums, 0, nums.Length - 1, tmp);
        return nums;
    }

    private void sort (int[] nums, int left, int right, int[] tmp) {
        if (left < right) {
            int mid = (left + right) / 2;
            sort (nums, left, mid, tmp);
            sort (nums, mid + 1, right, tmp);
            merge (nums, left, mid, right, tmp);
        }
    }

    private void merge (int[] nums, int left, int mid, int right, int[] tmp) {
        int i = left;
        int j = mid + 1;
        int t = 0;
        while (i <= mid && j <= right) {
            if (nums[i] < nums[j]) {
                tmp[t++] = nums[i++];
            } else {
                tmp[t++] = nums[j++];
            }
        }
        while (i <= mid) {
            tmp[t++] = nums[i++];
        }
        while (j <= right) {
            tmp[t++] = nums[j++];
        }
        // 
        t = 0;
        for (int k = left; k <= right; k++) {
            nums[k] = tmp[t++];
        }
    }

    // ----------------------------------------------------------------

    public int[] SortFast (int[] nums) {
        if (nums.Length == 1) return nums;
        quick (nums, 0, nums.Length - 1);
        return nums;
    }

    private void quick (int[] nums, int s, int e) {
        if (s < e) {
            int pivot = nums[s + (e - s) / 2];
            int i = s;
            int j = e;
            while (i < j)
            {
                while (i <= j && nums[i] < pivot) {
                    i++;
                }
                while (i <= j && nums[j] > pivot) {
                    j--;
                }
                if (i <= j)
                {
                    // 交换后索引需修改
                    int tmp = nums[i];
                    nums[i++] = nums[j];
                    nums[j--] = tmp;
                }
            }

            quick(nums, s, j);
            quick(nums, i, e);
        }
    }
}
// @lc code=end

static int Main (string[] args) {
    List<int[]> list = new List<int[]> () {
        new int[] { 5, 2, 3, 1 },
        new int[] { 5, 1, 1, 2, 0, 0 }
    };
    foreach (var arr in list) {
        int[] nums = new Solution ().SortFast (arr);
        System.Console.WriteLine (string.Join (",", nums));
    }
    return 0;
}
Main (null);