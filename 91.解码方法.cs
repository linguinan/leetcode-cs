/*
 * @lc app=leetcode.cn id=91 lang=csharp
 *
 * [91] 解码方法
 */

// @lc code=start
public class Solution {
    public int NumDecodings2 (string s) {
        int[] dp = new int[s.Length + 1];
        dp[0] = 1;
        dp[1] = s[0] == '0' ? 0 : 1;
        if (s.Length <= 1) return dp[1];
        for (int i = 2; i <= s.Length; i++) {
            int n = (s[i - 2] - '0') * 10 + (s[i - 1] - '0');
            if (s[i - 1] == '0' && s[i - 2] == '0') {
                return 0;
            } else if (s[i - 2] == '0') {
                dp[i] = dp[i - 1];
            } else if (s[i - 1] == '0') {
                if (n > 26) return 0;
                dp[i] = dp[i - 2];
            } else if (n > 26) {
                dp[i] = dp[i - 1];
            } else {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
        }
        return dp[dp.Length - 1];
    }

    public int NumDecodings (string s) {
        // if (s == null || s.Length == 0) return 0;
        int[] dp = new int[s.Length + 1];
        dp[0] = 1;
        dp[1] = s[0] == '0' ? 0 : 1;
        if (s.Length <= 1) return dp[1];
        for (int i = 2; i <= s.Length; i++) {
            int p1 = s[i - 1] - '0';
            int p2 = s[i - 2] - '0';
            if (p1 == 0 && p2 == 0) return 0;
            int n = p2 * 10 + p1;
            // 为0则无法单独成字母，所以铁定包含在一次解法中
            if (p2 == 0) {
                dp[i] = dp[i - 1];
            } else if (p1 == 0) {
                if (n > 26) return 0;
                dp[i] = dp[i - 2];
            } else if (n > 26) {
                dp[i] = dp[i - 1];
            } else {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
        }
        return dp[dp.Length - 1];
    }
}
// @lc code=end