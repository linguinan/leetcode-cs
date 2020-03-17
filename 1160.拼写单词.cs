/*
 * @lc app=leetcode.cn id=1160 lang=csharp
 *
 * [1160] 拼写单词
 */

// @lc code=start
using System.Collections.Generic;

public class Solution {
    public int CountCharacters(string[] words, string chars) {
        int charsCount = chars.Length;
        // 统计字符及出现的此时
        Dictionary<char, int> dic = new Dictionary<char, int>();
        foreach (char ch in chars.ToCharArray()) {
            if (dic.ContainsKey(ch)) {
                dic[ch]++;
            } else {
                dic[ch] = 1;
            }
        }
        // 统计已掌握的单词
        int count = 0;
        // 判断出能掌握的单词
        for (int i = 0; i < words.Length; i++) {
            // 超出限制了
            if (words[i].Length > charsCount)
                continue;

            int j = -1;
            char[] wordChars = words[i].ToCharArray();
            foreach (char ch in wordChars) {
                if (!dic.ContainsKey(ch) || dic[ch] <= 0) {
                    words[i] = null;
                    break;
                }
                dic[ch]--;
                j++;
            }
            // 回滚数据
            for (int k = j; k >= 0; k--) {
                dic[wordChars[k]]++;
            }
            if (words[i] != null) {
                count += words[i].Length;
            }
        }
        return count;
    }
}
// @lc code=end

