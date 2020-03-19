/*
 * @lc app=leetcode.cn id=242 lang=csharp
 *
 * [242] 有效的字母异位词
 */

// @lc code=start
public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length)
            return false;

        int[] arr = new int[26];
        foreach (var ch in s.ToCharArray())
        {
            arr[ch - 'a']++;
        }
        foreach (var ch in t.ToCharArray())
        {
            if (--arr[ch - 'a'] < 0)
                return false;
        }
        return true;
    }
}
// @lc code=end

