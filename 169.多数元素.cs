using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=169 lang=csharp
 *
 * [169] 多数元素
 */

// @lc code=start
public class Solution {
    // 这个时间和空间复杂度都是O(n)
    // public int MajorityElement(int[] nums) {
    //     Dictionary<int, int> dic = new Dictionary<int, int>();
    //     foreach (int num in nums)
    //     {
    //         if (dic.ContainsKey(num))
    //         {
    //             dic[num] += 1;
    //         }else
    //         {
    //             dic[num] = 1;
    //         }
    //     }
    //     int half = nums.Length / 2;
    //     foreach (var key in dic.Keys)
    //     {
    //         if (dic[key] > half)
    //         {
    //             return key;
    //         }
    //     }
    //     return 0;
    // }

    // 更优的投票算法，多数的最后肯定还在
    // 时间复杂度为O(n)，但空间复杂度是O(1)
    public int MajorityElement(int[] nums) {
        int count = 1;
        int target = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            if (count == 0)
            {
                target = nums[i];
            }
            count += (target == nums[i]) ? 1 : -1;
        }
        return target;
    }
}
// @lc code=end

