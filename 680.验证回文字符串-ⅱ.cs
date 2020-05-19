/*
 * @lc app=leetcode.cn id=680 lang=csharp
 *
 * [680] 验证回文字符串 Ⅱ
 */

// @lc code=start
public class Solution {
    /// <summary>
    /// 贪心算法
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public bool ValidPalindrome (string s) {
        int i = 0, j = s.Length - 1;
        // if (isPalindrome (s, i, j)) return true;
        while (i < j) {
            if (s[i] != s[j]) {
                // 删除左边或右边一个,如果内部是回文则为true
                return isPalindrome (s, i + 1, j) || isPalindrome (s, i, j - 1);
            }
            i++;
            j--;
        }
        return true;
    }

    private bool isPalindrome (string s, int i, int j) {
        while (i < j) {
            if (s[i++] != s[j--]) return false;
        }
        return true;
    }
}
// @lc code=end