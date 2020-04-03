/*
 * @lc app=leetcode.cn id=8 lang=csharp
 *
 * [8] 字符串转换整数 (atoi)
 */

// @lc code=start
public class Solution {
    /// <summary>
    /// 按规则判断即可
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public int MyAtoi (string str) {
        int count = str.Length;
        int idx = 0;
        if (count == idx) return 0;

        while (idx < count && str[idx] == ' ')
            idx++;
        if (count == idx) return 0;

        char zero = '0';
        bool negative = false;
        int atoi = 0;
        char ch = str[idx];
        if (ch == '-' || ch == '+') {
            negative = ch == '-';
        } else {
            if (!char.IsDigit (ch)) return 0;
            atoi = ch - zero;
        }

        for (int i = idx + 1; i < count; i++) {
            if (!char.IsDigit (str[i])) break;
            int num = str[i] - zero;
            if (((int.MaxValue - num) * 0.1) < atoi) {
                return negative ? int.MinValue : int.MaxValue;
            }
            atoi = atoi * 10 + num;
        }

        return negative ? atoi * -1 : atoi;
    }
}
// @lc code=end