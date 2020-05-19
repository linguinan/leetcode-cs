using System.Text;
/*
 * @lc app=leetcode.cn id=125 lang=csharp
 *
 * [125] 验证回文串
 */

// @lc code=start
using System;

public class Solution {
    public bool IsPalindrome2 (string s) {
        // 自顶向下
        string filterStr = filterNonLetterAndNumber (s);
        // System.Console.WriteLine (filterStr);
        filterStr = filterStr.ToLower ();
        string reverseStr = reverseString (filterStr);
        return filterStr.Equals (reverseStr);
    }

    private string reverseString (string filterStr) {
        var arr = filterStr.ToCharArray ();
        Array.Reverse (arr);
        return new string (arr);
    }

    private string filterNonLetterAndNumber (string s) {
        StringBuilder sb = new StringBuilder ();
        for (int i = 0; i < s.Length; i++) {
            if (char.IsLetterOrDigit (s[i])) {
                sb.Append (s[i]);
            }
        }
        return sb.ToString ();
    }

    public bool IsPalindrome3 (string s) {
        int i = 0, j = s.Length - 1;
        while (i < j) {
            while (i < j && !char.IsLetterOrDigit(s[i])) {
                i++;
            }
            while (i < j && !char.IsLetterOrDigit(s[j])) {
                j--;
            }
            if (i < j && char.ToLower(s[i]) != char.ToLower(s[j])) {
                return false;
            } 
            i++;
            j--;
        }
        return true;
    }

    /// <summary>
    /// 双指针  时间复杂度 O(N)
    /// 剔除非字母和数字，比较小写是否相等
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public bool IsPalindrome (string s) {
        int i = 0, j = s.Length - 1;
        while (i < j) {
            while (i < j && !char.IsLetterOrDigit(s[i])) i++;
            while (i < j && !char.IsLetterOrDigit(s[j])) j--;
            if (i < j && char.ToLower(s[i++]) != char.ToLower(s[j--])) return false;
        }
        return true;
    }

}
// @lc code=end