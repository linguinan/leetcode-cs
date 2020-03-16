/*
 * @lc app=leetcode.cn id=20 lang=csharp
 *
 * [20] 有效的括号
 */

// @lc code=start
using System.Collections.Generic;

public class Solution {
    public bool IsValid(string s) {
        if (string.IsNullOrEmpty(s)) return true;

        Dictionary<char, char> dic = new Dictionary<char, char>();
        dic['('] = ')';
        dic['{'] = '}';
        dic['['] = ']';

        char[] chars = s.ToCharArray();
        Stack<char> stack = new Stack<char>();
        foreach (char ch in chars)
        {
            if (dic.ContainsKey(ch))
            {
                stack.Push(ch);
            } else {
                if (stack.Count > 0)
                {
                    // 取栈顶，判断是否匹配
                    char top = stack.Pop();
                    if (dic[top] != ch)
                        return false;
                } else {
                    return false;
                }
            }
        }
        return stack.Count == 0;
    }
}
// @lc code=end

