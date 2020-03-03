using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=169 lang=csharp
 *
 * [169] 多数元素
 */

// @lc code=start
public class Solution {
    public int MajorityElement(int[] nums) {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        foreach (int num in nums)
        {
            if (dic.ContainsKey(num))
            {
                dic[num] += 1;
            }else
            {
                dic[num] = 1;
            }
        }
        int half = nums.Length / 2;
        foreach (var key in dic.Keys)
        {
            if (dic[key] > half)
            {
                return key;
            }
        }
        return 0;
    }
}
// @lc code=end

