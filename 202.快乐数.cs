/*
 * @lc app=leetcode.cn id=202 lang=csharp
 *
 * [202] 快乐数
 */

// @lc code=start
using System.Collections.Generic;

public class Solution {
    /// <summary>
    /// 暴力硬解的，居然能过，还 beats 80.3 %
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public bool IsHappy2 (int n) {
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

    /// <summary>
    /// 用hash保存出现过的数字，如有重复即进入无限循环
    /// 时间复杂度 O(x) 空间复杂度 O(x)
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public bool IsHappy3 (int n) {
        if (n == 1) return true;
        if (n == 0) return false;
        HashSet<int> set = new HashSet<int> ();
        set.Add (n);
        int num = n, sum = 0, cur;
        while (num != 1) {
            while (num > 0) {
                cur = num % 10;
                sum += cur * cur;
                num /= 10;
            }
            if (!set.Add (sum)) return false;
            num = sum;
            sum = 0;
        }
        return true;
    }

    /// <summary>
    /// 快慢指针
    /// 时间复杂度 O(x) 空间复杂度 O(1)
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public bool IsHappy (int n) {
        int slow = n, fast = n;
        do {
            slow = getNext (slow);
            fast = getNext (getNext (fast));
        } while (slow != fast);
        return slow == 1;
    }

    private int getNext (int n) {
        int num = n, sum = 0, cur;
        while (num > 0) {
            cur = num % 10;
            sum += cur * cur;
            num /= 10;
        }
        return sum;
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