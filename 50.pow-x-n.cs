/*
 * @lc app=leetcode.cn id=50 lang=csharp
 *
 * [50] Pow(x, n)
 */

// @lc code=start
public class Solution {
    /// <summary>
    /// 分治法，拆分子问题，实现计算量减半
    /// 复杂度 O(logN)
    /// </summary>
    /// <param name="x"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public double MyPow2 (double x, int n) {
        if (n == 0 || x == 1)
            return 1;

        // n 为负
        if (n < 0) {
            // n如果是int的最小值，则-n的值会超出最大值1
            // 所以此处要减去1，以保证值不溢出
            return 1 / (x * MyPow (x, -n - 1));
        }

        // n 为奇数
        if (n % 2 == 1)
            return x * MyPow (x, n - 1);

        // n 为偶数 n / 2 递归次数就减半了
        return MyPow (x * x, n / 2);
    }

    /// <summary>
    /// 暴力解法(超时，复杂度O(n))
    /// </summary>
    /// <param name="x"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public double MyPow3 (double x, int n) {
        if (n == 0 || x == 1)
            return 1;
        if (n < 0) {
            x = 1 / x;
            n = -n;
        }
        double ans = x;
        for (int i = 1; i < n; i++) {
            ans *= x;
        }
        return ans;
    }

    public double MyPow (double x, int n) {
        if (n == 0 || x == 1) return 1;
        if (n < 0) return 1 / (x * MyPow(x, -n - 1));
        return (n % 2 == 0) ? MyPow (x * x, n / 2) : x * MyPow (x, n - 1);
    }


}
// @lc code=end

// int max 2147483647.

static int Main(string[] args)
{
    Solution solution = new Solution();
    System.Console.WriteLine(solution.MyPow(2.0, -2147483648));//0
    return 0;
}
Main (null);