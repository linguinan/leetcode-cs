using System;
/*
 * @lc app=leetcode.cn id=49 lang=csharp
 *
 * [49] 字母异位词分组
 */

// @lc code=start
using System.Collections.Generic;

public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        if (strs == null || strs.Length == 0)
        {
            return new List<IList<string>>();
        }
        Dictionary<string, IList<string>> dic = new Dictionary<string, IList<string>>();
        foreach (string str in strs)
        {
            // int[] arr = new int[26];
            // foreach (char ch in str.ToCharArray())
            // {
            //     arr[ch - 'a']++;
            // }
            // string key = string.Join("#", arr);
            char[] arr = str.ToCharArray();
            Array.Sort(arr);
            string key = string.Join("", arr);
            if (!dic.ContainsKey(key))
                dic[key] = new List<string>();
            dic[key].Add(str);
        }
        // IList<IList<string>> list = new List<IList<string>>();
        // foreach (var item in dic.Values)
        // {
        //     list.Add(item);
        // }
        // return list;
        return new List<IList<string>>(dic.Values);
    }
}
// @lc code=end

