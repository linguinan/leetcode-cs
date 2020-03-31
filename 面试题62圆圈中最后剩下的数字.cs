using System.Collections.Generic;

public class Solution {
    /// <summary>
    /// 纯暴力
    /// 直接找到下一个要删除的位置
    /// 由于把当前位置的数字删除了，后面的数字会前移一位，所以实际的下一个位置要-1
    /// O(n^2)
    /// </summary>
    /// <param name="n"></param>
    /// <param name="m"></param>
    /// <returns></returns>
    public int LastRemaining2 (int n, int m) {
        List<int> list = new List<int> (n);
        for (int i = 0; i < n; i++) {
            list.Add (i);
        }
        int idx = 0;
        while (n > 1) {
            idx = (idx + m - 1) % n;
            list.RemoveAt (idx);
            n--;
        }
        return list[0];
    }

    /// <summary>
    /// 数学解法：O(n)
    /// </summary>
    /// <param name="n"></param>
    /// <param name="m"></param>
    /// <returns></returns>
    public int LastRemaining (int n, int m) {
        int ans = 0;
        for (int i = 2; i <= n; i++)
        {
            ans = (ans + m) % i;
        }
        return ans;
    }
}

static int Main (string[] args) {
    System.Console.WriteLine("res: " + new Solution().LastRemaining(5, 3));//3
    System.Console.WriteLine ("res: " + new Solution ().LastRemaining (10, 17)); //2
    return 0;
}
Main (null);