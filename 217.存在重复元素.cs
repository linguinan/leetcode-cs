/*
 * @lc app=leetcode.cn id=217 lang=csharp
 *
 * [217] 存在重复元素
 */

// @lc code=start
using System.Collections.Generic;

public class Solution {
    public bool ContainsDuplicate2 (int[] nums) {
        HashSet<int> set = new HashSet<int> ();
        foreach (var item in nums) {
            if (!set.Add (item)) {
                return true;
            }
        }
        return false;
    }

    public bool ContainsDuplicate (int[] nums) {
        HashSet<int> set = new HashSet<int> (nums);
        return set.Count != nums.Length;
    }
}
// @lc code=end