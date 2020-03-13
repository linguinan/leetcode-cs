/*
 * @lc app=leetcode.cn id=1071 lang=csharp
 *
 * [1071] 字符串的最大公因子
 */

// @lc code=start
using System;

public class Solution {
    public string GcdOfStrings(string str1, string str2) {
        // 枚举法
        int len1 = str1.Length;
        int len2 = str2.Length;
        int min = Math.Min(len1, len2);
        // 从最大的开始枚举
        for (int i = min; i >= 1; --i)
        {
            if (len1 % i == 0 && len2 % i == 0)
            {
                string x = str1.Substring(0, i);
                if (check(x, str1) && check(x, str2))
                {
                    return x;
                }
            }
        }
        return "";
    }

    private bool check(string x, string str)
    {
        int count = str.Length / x.Length;
        string tmp = "";
        for (int i = 0; i < count; i++)
        {
            tmp += x;
        }
        return tmp == str;
    }
}
// @lc code=end

