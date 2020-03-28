/*
 * @lc app=leetcode.cn id=219 lang=csharp
 *
 * [219] 存在重复元素 II
 */

// @lc code=start
using System.Collections.Generic;

public class Solution {
    public bool ContainsNearbyDuplicate (int[] nums, int k) {
        if (nums.Length < 2) {
            return false;
        }
        Dictionary<int, int> dic = new Dictionary<int, int> ();
        for (int i = 0; i < nums.Length; i++) {
            int num = nums[i];
            if (!dic.ContainsKey (num)) {
                dic.Add (num, i);
            } else {
                if ((i - dic[num]) <= k) {
                    return true;
                }
                dic[num] = i;
            }
        }
        return false;
    }
}
// @lc code=end