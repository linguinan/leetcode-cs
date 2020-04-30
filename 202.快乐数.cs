/*
 * @lc app=leetcode.cn id=202 lang=csharp
 *
 * [202] 快乐数
 */

// @lc code=start
public class Solution {
    /// <summary>
    /// 暴力硬解的，居然能过，还 beats 80.3 %
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public bool IsHappy (int n) {
        if (n == 1) return true;
        if (n == 0) return false;
        int num = n, sum = 0, cnt = 0;
        while (num != 1) {
            while (num > 0) {
                sum += (num % 10) * (num % 10);
                num /= 10;
            }
            num = sum;
            sum = 0;
            cnt++;
            if (cnt > 100) return false;
        }
        return true;
    }

    
}
// @lc code=end

static int Main (string[] args) {
    int m = 123;
    while (m > 0) {
        System.Console.WriteLine (m % 10);
        m /= 10;
    }
    Solution solution = new Solution ();
    System.Console.WriteLine (solution.IsHappy (19));
    return 0;
}
Main (null);

// System.Console.WriteLine(123 / 10);
// System.Console.WriteLine(123 % 10);
// System.Console.WriteLine((4 >> 2) & 1);