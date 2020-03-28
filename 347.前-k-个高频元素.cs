/*
 * @lc app=leetcode.cn id=347 lang=csharp
 *
 * [347] 前 K 个高频元素
 */

// @lc code=start
using System.Collections.Generic;

public class Solution {
    public IList<int> TopKFrequent (int[] nums, int k) {
        if (nums.Length <= k) {
            return new List<int> (nums);
        }
        Dictionary<int, int> dic = new Dictionary<int, int> ();
        foreach (var item in nums) {
            if (!dic.ContainsKey (item)) {
                dic.Add (item, 1);
            } else {
                dic[item]++;
            }
        }
        List<int> res = new List<int> ();
        foreach (var item in dic) {
            if (res.Count < k) {
                res.Add (item.Key);
            } else {
                int min = 0;
                for (int i = 1; i < k; i++)
                {
                    if (dic[res[i]] < dic[res[min]])
                    {
                        min = i;
                    }
                }
                if (item.Value > dic[res[min]])
                {
                    res[min] = item.Key;
                }
            }
        }
        return res;
    }
}
// @lc code=end