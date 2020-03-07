/*
 * @lc app=leetcode.cn id=1 lang=csharp
 *
 * [1] 两数之和
 */

// @lc code=start
using System.Collections.Generic;

public class Solution {
    public int[] TwoSum2(int[] nums, int target) {
        // ???
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if ((nums[i] + nums[j]) == target)
                {
                    return new int[]{i, j};
                }
            }
        }
        return new int[0];
    }

    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        Dictionary<int, int> map = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            dic[nums[i]] = i;
            if (map.ContainsKey(i))
            {
                map[i]++;
            }else{
                map[i] = 1;
            }
        }
        for (int i = 0; i < nums.Length; i++)
        {
            int v = target - nums[i];
            map[i]--;
            if (dic.ContainsKey(v))
            {
                int j = dic[v];
                if (map[j] > 0)
                {
                    return new int[]{i, j};
                }
            }
            map[i]++;
        }
        return new int[0];
    }
}
// @lc code=end

