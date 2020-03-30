/*
 * @lc app=leetcode.cn id=820 lang=csharp
 *
 * [820] 单词的压缩编码
 */

// @lc code=start
using System.Collections.Generic;

public class Solution {
    /// <summary>
    /// 由数据范围可知一个单词最多含有 7 个后缀，所以我们可以枚举单词所有的后缀
    /// </summary>
    /// <param name="words"></param>
    /// <returns></returns>
    public int MinimumLengthEncoding (string[] words) {
        HashSet<string> set = new HashSet<string> (words);
        foreach (var word in words) {
            for (int i = 1; i < word.Length; i++) {
                set.Remove (word.Substring (i));
            }
        }
        int ans = 0;
        foreach (var word in set) {
            ans += word.Length + 1;
        }
        return ans;
    }
}
// @lc code=end