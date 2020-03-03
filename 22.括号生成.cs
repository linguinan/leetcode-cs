using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=22 lang=csharp
 *
 * [22] 括号生成
 */

// @lc code=start
public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        IList<string> list = new List<string>();
        if (n <= 0)
            return list;
        gen(list, n, n);
        return list;
    }

    void gen(IList<string> list, int left, int right) {
        
    }
}
// @lc code=end

