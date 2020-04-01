/*
 * @lc app=leetcode.cn id=1111 lang=csharp
 *
 * [1111] 有效括号的嵌套深度
 */

// @lc code=start
public class Solution {
    public int[] MaxDepthAfterSplit (string seq) {
        int[] arr = new int[seq.Length];
        int idx = 0;
        foreach (char c in seq.ToCharArray ()) {
            arr[idx++] = c == '(' ? idx & 1 : (idx + 1) & 1;
        }
        return arr;
    }
}
// @lc code=end

System.Console.WriteLine (1 & 1);
System.Console.WriteLine (2 & 1);

System.Console.WriteLine (3 & 1);
System.Console.WriteLine (4 & 1);