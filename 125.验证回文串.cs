using System.Text;
/*
 * @lc app=leetcode.cn id=125 lang=csharp
 *
 * [125] 验证回文串
 */

// @lc code=start
using System;

public class Solution {
    public bool IsPalindrome(string s) {
        // 自顶向下
        string filterStr = filterNonLetterAndNumber(s);
        System.Console.WriteLine(filterStr);
        filterStr = filterStr.ToLower();
        string reverseStr = reverseString(filterStr);
        return filterStr.Equals(reverseStr);
    }

    private string reverseString(string filterStr)
    {
        var arr = filterStr.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }

    private string filterNonLetterAndNumber(string s)
    {
        StringBuilder sb = new StringBuilder();
        var arr = s.ToCharArray();
        for (int i = 0; i < arr.Length; i++)
        {
            char c = arr[i];
            if (char.IsLetterOrDigit(c)) {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }
}
// @lc code=end

