/*
 * @lc app=leetcode.cn id=917 lang=csharp
 *
 * [917] 仅仅反转字母
 */

// @lc code=start
using System.Collections.Generic;
using System.Text;

public class Solution {
    /// <summary>
    /// 双指针向中间逼近
    /// </summary>
    /// <param name="S"></param>
    /// <returns></returns>
    public string ReverseOnlyLetters2 (string S) {
        char[] res = new char[S.Length];
        int i = 0, j = S.Length - 1;
        while (i < j) {
            while (i < j && !char.IsLetter (S[i])) {
                res[i] = S[i++];
            }
            while (i < j && !char.IsLetter (S[j])) {
                res[j] = S[j--];
            }
            if (i < j) {
                res[i] = S[j];
                res[j--] = S[i++];
            }
        }
        if (i == j) res[i] = S[i];
        return new string (res);
    }

    /// <summary>
    /// 反转指针
    /// </summary>
    /// <param name="S"></param>
    /// <returns></returns>
    public string ReverseOnlyLetters3 (string S) {
        StringBuilder sb = new StringBuilder ();
        int j = S.Length - 1;
        for (int i = 0; i < S.Length; i++) {
            if (char.IsLetter (S[i])) {
                while (!char.IsLetter (S[j])) j--;
                sb.Append (S[j--]);
            } else {
                sb.Append (S[i]);
            }
        }
        return sb.ToString ();
    }

    /// <summary>
    /// 字母栈  先进后出
    /// </summary>
    /// <param name="S"></param>
    /// <returns></returns>
    public string ReverseOnlyLetters (string S) {
        Stack<char> stack = new Stack<char> ();
        for (int i = 0; i < S.Length; i++) {
            if (char.IsLetter (S[i])) {
                stack.Push (S[i]);
            }
        }
        StringBuilder sb = new StringBuilder ();
        for (int j = 0; j < S.Length; j++) {
            if (char.IsLetter (S[j])) {
                sb.Append (stack.Pop ());
            } else {
                sb.Append (S[j]);
            }
        }
        return sb.ToString ();
    }

}
// @lc code=end