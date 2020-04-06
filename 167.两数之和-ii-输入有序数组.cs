/*
 * @lc app=leetcode.cn id=167 lang=csharp
 *
 * [167] 两数之和 II - 输入有序数组
 */

// @lc code=start
public class Solution {
    /// <summary>
    /// 二分查找
    /// 时间复制度 O(nlogn)
    /// </summary>
    /// <param name="numbers"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int[] TwoSum2 (int[] numbers, int target) {
        int count = numbers.Length;
        for (int i = 0; i < count; i++) {
            if (numbers[i] > target) break;
            int left = i + 1, right = count - 1, other = target - numbers[i];
            while (left <= right) {
                int mid = left + (right - left) / 2;
                if (numbers[mid] == other) {
                    return new int[2] { i + 1, mid + 1 };
                } else if (numbers[mid] < other) {
                    left = mid + 1;
                } else {
                    right = mid - 1;
                }
            }
        }
        return new int[2];
    }

    /// <summary>
    /// 双指针
    /// 时间复杂度 O(n)
    /// </summary>
    /// <param name="numbers"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int[] TwoSum (int[] numbers, int target) {
        int low = 0, high = numbers.Length - 1;
        while (low < high) {
            int sum = numbers[low] + numbers[high];
            if (sum == target) {
                return new int[2] { low + 1, high + 1 };
            } else if (sum < target) {
                low++;
            } else {
                high--;
            }
        }
        return new int[2];
    }
}
// @lc code=end