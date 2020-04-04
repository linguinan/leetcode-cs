/*
 * @lc app=leetcode.cn id=268 lang=csharp
 *
 * [268] 缺失数字
 */

// @lc code=start
public class Solution {
    /// <summary>
    /// 完全自己思考实现的，耗时6分钟
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int MissingNumber (int[] nums) {
        int[] tmps = new int[nums.Length + 1];
        for (int i = 0; i < nums.Length; i++) {
            tmps[nums[i]] = 1;
        }
        for (int j = 0; j < tmps.Length; j++) {
            if (tmps[j] == 0) {
                return j;
            }
        }
        return 0;
    }
}
// @lc code=end