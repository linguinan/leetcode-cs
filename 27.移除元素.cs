/*
 * @lc app=leetcode.cn id=27 lang=csharp
 *
 * [27] 移除元素
 */

// @lc code=start
public class Solution {
    public int RemoveElement(int[] nums, int val) {
        int count = nums.Length;
        int i = 0;
        int j = 0;
        while (i < count) {
            if (nums[i] != val) {
                nums[j] = nums[i];
                j++;
            }
            i++;
        }
        return j;
    }
}
// @lc code=end

