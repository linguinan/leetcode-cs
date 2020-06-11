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
    public string LongestPalindrome5 (string s) {
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

    /// <summary>
    /// 动态规划    O(n2)
    /// 状态 dp[i][j] 表示子串 s[i..j] 是否为回文子串
    /// 状态转移方程：dp[i][j] = s[i] == s[j] and dp[i + 1][j - 1]
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public string LongestPalindrome (string s) {
        if (s.Length < 2) return s;
        int startIndex = 0, maxLen = 1, sLen = s.Length;
        // init
        bool[][] dp = new bool[sLen][];
        for (int i = 0; i < sLen; i++) {
            dp[i] = new bool[sLen];
            dp[i][i] = true;
        }
        // for col
        for (int j = 1; j < sLen; j++) {
            for (int i = 0; i < j; i++) {
                if (s[i] != s[j]) {
                    dp[i][j] = false;
                } else {
                    if (j - i < 3) {
                        dp[i][j] = true;
                    } else {
                        dp[i][j] = dp[i + 1][j - 1];
                    }
                }
                if (dp[i][j]) {
                    if (j - i + 1 > maxLen) {
                        maxLen = j - i + 1;
                        startIndex = i;
                    }
                }
            }
        }
        return s.Substring (startIndex, maxLen);
    }
}
// @lc code=end