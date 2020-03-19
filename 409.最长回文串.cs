/*
 * @lc app=leetcode.cn id=409 lang=csharp
 *
 * [409] 最长回文串
 */

// @lc code=start
using System.Collections.Generic;

public class Solution {
    /// <summary>利用/2取整获取可重复的字符数量，取余判断是否有中间字符</summary>
    public int LongestPalindrome2(string s) {
        Dictionary<char, int> dic = new Dictionary<char, int>();
        foreach (char ch in s.ToCharArray()) {
            if (dic.ContainsKey(ch)) {
                dic[ch]++;
            } else {
                dic[ch] = 1;
            }
        }
        int cnt = 0;
        foreach (int num in dic.Values)
        {
            cnt += num / 2 * 2;
            if (num % 2 == 1 && cnt % 2 == 0)
                cnt++;
        }
        return cnt;
    }

    /// <summary>反其到而行，减去取余为1到数量</summary>
    public int LongestPalindrome(string s) {
        if (s.Length <= 1)
            return s.Length;

        int charA = 'A';
        int[] arr = new int['z' - charA + 1];
        foreach (char ch in s.ToCharArray()) {
            arr[ch - charA]++;
        }
        int cnt = 0;
        foreach (int num in arr)
        {
            if (num % 2 == 1) {
                cnt++;
            }
        }
        if (cnt <= 1)
            return s.Length;
        return s.Length - cnt + 1;
    }
}
// @lc code=end

