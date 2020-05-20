/*
 * @lc app=leetcode.cn id=205 lang=csharp
 *
 * [205] 同构字符串
 */

// @lc code=start
using System.Collections.Generic;
using System.Text;

public class Solution {
    /// <summary>
    /// 字典映射
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public bool IsIsomorphic2 (string s, string t) {
        StringBuilder sb = new StringBuilder ();
        Dictionary<char, char> dic = new Dictionary<char, char> ();
        for (int i = 0; i < s.Length; i++) {
            if (!dic.ContainsKey (s[i])) {
                if (dic.ContainsValue (t[i])) return false;
                dic[s[i]] = t[i];
                sb.Append (t[i]);
            } else {
                sb.Append (dic[s[i]]);
            }
        }
        return sb.Equals (t);
    }

    /// <summary>
    /// 题解：判断字母首次出现的下标
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public bool IsIsomorphic (string s, string t) {
        for (int i = 0; i < s.Length; i++) {
            if (s.IndexOf (s[i]) != t.IndexOf (t[i])) return false;
        }
        return true;
    }
}
// @lc code=end