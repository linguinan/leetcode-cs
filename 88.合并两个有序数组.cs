/*
 * @lc app=leetcode.cn id=88 lang=csharp
 *
 * [88] 合并两个有序数组
 */

// @lc code=start
public class Solution {
    public void Merge2(int[] nums1, int m, int[] nums2, int n) {
        // 双指针
        int j = m - 1;
        int k = n - 1;
        // 从后往前，不用移动数组，空间复杂度O(1)
        // 只遍历一遍即完成，时间复杂度O(n)
        for (int i = (m + n - 1); i >= 0; i--) {
            if (j >= 0 && k >= 0)
            {
                if (nums1[j] > nums2[k])
                {
                    nums1[i] = nums1[j--];
                } else {
                    nums1[i] = nums2[k--];
                }
            } else {
                if (j >= 0)
                {
                    nums1[i] = nums1[j--];
                } else {
                    nums1[i] = nums2[k--];
                }
            }
        }
    }

    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        // 精简优化 代码是精简了，但效率并不高
        while (m > 0 && n > 0) {
            nums1[m + n - 1] = (nums1[m - 1] > nums2[n - 1]) ? nums1[--m] : nums2[--n];
        }
        while (n > 0) {
            nums1[n - 1] = nums2[--n];
        }
    }
}
// @lc code=end

