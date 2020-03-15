// 字符串轮转。给定两个字符串s1和s2，请编写代码检查s2是否为s1旋转而成（比如，waterbottle是erbottlewat旋转后的字符串）。
using System.Collections.Generic;

public class Solution {
    public bool IsFlipedString2(string s1, string s2) {
        if (s1.Length != s2.Length) return false;

        Dictionary<char, int> dic = new Dictionary<char, int>();
        char[] chars = s1.ToCharArray();
        foreach (char c in chars)
        {
            if (dic.ContainsKey(c)) {
                dic[c]++;
            } else {
                dic[c] = 1;
            }
        }
        chars = s2.ToCharArray();
        foreach (char c in chars)
        {
            if (!dic.ContainsKey(c) || dic[c] <= 0) return false;
            dic[c]--;
        }
        return true;
    }

    public bool IsFlipedString(string s1, string s2) {
        if (s1.Length != s2.Length) return false;
        if (s1.Equals(s2)) return true;
        // 依提议是旋转，那其实字符之间的顺序还是不变的
        // 那在加一遍s1则肯定包含s2
        s1 += s1;
        return s1.Contains(s2);
    }
}