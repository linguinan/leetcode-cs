/*
 * @lc app=leetcode.cn id=50 lang=csharp
 *
 * [50] Pow(x, n)
 */

// @lc code=start
public class Solution {
    /// <summary>
    /// 分治法，拆分子问题
    /// </summary>
    /// <param name="x"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public double MyPow2(double x, int n) {
        // 递归的解法
        if (n == 0 || x == 1)
            return 1;
        // if (n == 1)
        //     return x;
        
        // n 为负
        if (n < 0)
        {
            // n如果是int的最小值，则-n的值回超出最大值1
            // 所以此处要减去1，以保证值不溢出
            return 1 / (x * MyPow(x, -n - 1));
        }

        // n 为奇数
        if (n % 2 == 1)
            return x * MyPow(x, n - 1);

        // n 为偶数 n / 2 递归次数就减半了
        return MyPow(x * x, n / 2);
    }

    public double MyPow(double x, int n) {
        // 循环的解法
        
    }
}
// @lc code=end

// int max 2147483647.