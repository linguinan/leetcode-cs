/*
 * @lc app=leetcode.cn id=887 lang=csharp
 *
 * [887] 鸡蛋掉落
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution {
    /// <summary>
    /// 鸡蛋没摔坏的话可以继续用
    /// key中n✖️100是因k最大100
    /// </summary>
    /// <param name="K"></param>
    /// <param name="N"></param>
    /// <returns></returns>
    public int SuperEggDrop2 (int K, int N) {
        Dictionary<int, int> dic = new Dictionary<int, int> ();
        return dp (K, N, dic);
    }

    /// <summary>
    /// 动态规划
    /// </summary>
    /// <param name="k"></param>
    /// <param name="n"></param>
    /// <param name="dic"></param>
    /// <returns></returns>
    private int dp (int k, int n, Dictionary<int, int> dic) {
        int key = n * 100 + k;
        if (!dic.ContainsKey (key)) {
            int ans;
            // 特殊情况
            if (n == 0) {
                ans = 0;
            } else if (k == 1) {
                ans = n;
            } else {
                // 二分法
                int low = 1, high = n;
                while ((low + 1) < high) {
                    int x = low + (high - low) / 2;
                    // 如果鸡蛋碎了，则缩小为如下子问题
                    int t1 = dp (k - 1, x - 1, dic);
                    // 如果鸡蛋没碎，则缩小为如下子问题
                    int t2 = dp (k, n - x, dic);

                    if (t1 < t2) {
                        low = x;
                    } else if (t1 > t2) {
                        high = x;
                    } else {
                        low = high = x;
                    }
                }
                // 取两个最大值中的较小值
                ans = 1 + Math.Min (Math.Max (dp (k - 1, low - 1, dic), dp (k, n - low, dic)),
                    Math.Max (dp (k - 1, high - 1, dic), dp (k, n - high, dic)));
            }
            dic.Add (key, ans);
        }
        return dic[key];
    }

    /// <summary>
    /// 逆向解法
    /// 从求扔几次变为求有多少层楼
    /// 直到递归结果大于需确定的楼层时
    /// </summary>
    /// <param name="K"></param>
    /// <param name="N"></param>
    /// <returns></returns>
    public int SuperEggDrop (int K, int N) {
        int T = 1;
        while (calc (K, T) < N + 1) T++;
        return T;
    }

    /// <summary>
    /// 蛋碎能确定的楼层 + 蛋没碎时能确定的楼层
    /// </summary>
    /// <param name="K"></param>
    /// <param name="T"></param>
    /// <returns></returns>
    private int calc (int K, int T) {
        if (K == 1 || T == 1) return T + 1;
        return calc (K - 1, T - 1) + calc (K, T - 1);
    }
}
// @lc code=end