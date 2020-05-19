/*
 * @lc app=leetcode.cn id=557 lang=csharp
 *
 * [557] 反转字符串中的单词 III
 */

// @lc code=start
using System.Collections.Generic;
using System.Text;

public class Solution {
    public string ReverseWords (string s) {
        List<string> list = new List<string> ();
        int i = -1;
        for (int j = 1; j < s.Length; j++) {
            if (s[j] == ' ') {
                list.Add (reverse (s, i, j - 1));
                i = j;
            }
        }
        list.Add (reverse (s, i, s.Length - 1));
        return string.Join (" ", list);
    }

    private string reverse (string s, int i, int j) {
        StringBuilder sb = new StringBuilder ();
        while (i < j) {
            sb.Append (s[j--]);
        }
        return sb.ToString ();
    }
}
// @lc code=end