/*
 * @lc app=leetcode.cn id=151 lang=csharp
 *
 * [151] 翻转字符串里的单词
 */

// @lc code=start
using System.Text;

public class Solution {
    public string ReverseWords (string s) {
        if (string.IsNullOrEmpty (s)) {
            return string.Empty;
        }
        s = s.Trim ();
        string[] arr = s.Split (' ');
        StringBuilder sb = new StringBuilder ();
        for (int i = arr.Length - 1; i >= 0; i--) {
            if (!string.IsNullOrEmpty (arr[i])) {
                sb.Append (arr[i]);
                if (i != 0) {
                    sb.Append (" ");
                }
            }
        }
        return sb.ToString ();
    }
}
// @lc code=end

static int Main (string[] args) {
    System.Console.WriteLine (new Solution ().ReverseWords ("a good   example"));
    return 0;
}
Main (null);