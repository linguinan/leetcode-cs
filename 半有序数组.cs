public class Solution {
    /// <summary>
    /// 使用二分查找，寻找一个半有序数组 [4, 5, 6, 7, 0, 1, 2] 中间无序的地方
    /// 时间复杂度 O(logN) 空间复杂度 O(1)
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int findMin (int[] nums) {
        if (nums.Length <= 0) return -1;
        int left = 0, right = nums.Length - 1;
        if (nums[left] < nums[right]) return -1;
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (nums[mid] < nums[right]) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }
        return left;
    }
}
// @lc code=end

static int Main (string[] args) {
    System.Console.WriteLine (new Solution ().findMin (new int[] { 4, 5, 6, 7, 0, 1, 2 }));
    return 0;
}
Main (null);