/*
 * @lc app=leetcode.cn id=5 lang=csharp
 *
 * [5] 最长回文子串
 */

// @lc code=start
using System;

public class Solution {
    /// <summary>
    /// 暴力解  O(n3)
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public string LongestPalindrome4 (string s) {
        if (s.Length < 2) return s;
        int maxLen = 1, startIndex = 0;
        for (int i = 0; i < s.Length - 1; i++) {
            for (int j = i + 1; j < s.Length; j++) {
                if (j - i + 1 > maxLen && checkIsPalindrome (s, i, j)) {
                    maxLen = j - i + 1;
                    startIndex = i;
                }
            }
        }
        return s.Substring (startIndex, maxLen);
    }

    private bool checkIsPalindrome (string s, int i, int j) {
        while (i < j) {
            if (s[i++] != s[j--]) return false;
        }
        return true;
    }

    /// <summary>
    /// 中心扩散法  O(n2)
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public string LongestPalindrome (string s) {
        if (s.Length < 2) return s;
        int maxLen = 1, startIndex = 0;
        for (int i = 0; i < s.Length - 1; i++) {
            int oddLen = expandCenter (s, i, i);
            int evenLen = expandCenter (s, i, i + 1);
            int len = Math.Max (oddLen, evenLen);
            if (len > maxLen) {
                maxLen = len;
                startIndex = i - ((len - 1) >> 1);
            }
        }
        return s.Substring (startIndex, maxLen);
    }

    private int expandCenter (string s, int left, int right) {
        int len = s.Length;
        while (left >= 0 && right < len) {
            if (s[left] != s[right]) break;
            left--;
            right++;
        }
        return right - left - 1;
    }

    // /// <summary>
    // /// 动态规划
    // /// 状态转移方程：dp[i][j] = s[i] == s[j] and dp[i + 1][j - 1]
    // /// </summary>
    // /// <param name="s"></param>
    // /// <returns></returns>
    // public string LongestPalindrome (string s) {

    // }
}
// @lc code=end