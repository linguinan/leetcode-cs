/*
 * @lc app=leetcode.cn id=69 lang=csharp
 *
 * [69] x 的平方根
 */

// @lc code=start
public class Solution {
    public int MySqrt(int x) {
        // ????
        if (x == 0 || x == 1)
            return x;

        int left = 1;
        int right = x;
        int res = 0;

        while (left <= right)
        {
            int min = (left + right) / 2;
            if (min == x / min)
                return min;
            if (min < x / min)
            {
                left = min + 1;
                // int ?????
                res = min;
            }else
            {
                right = min - 1;
            }
        }

        return res;
    }
}
// @lc code=end

