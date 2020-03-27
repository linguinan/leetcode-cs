/*
 * @lc app=leetcode.cn id=914 lang=csharp
 *
 * [914] 卡牌分组
 */

// @lc code=start
using System.Collections.Generic;

public class Solution {
    public bool HasGroupsSizeX (int[] deck) {
        if (deck.Length < 2) {
            return false;
        }
        Dictionary<int, int> groups = new Dictionary<int, int> ();
        foreach (var item in deck) {
            if (groups.ContainsKey (item)) {
                groups[item]++;
            } else {
                groups.Add (item, 1);
            }
        }
        int X = groups[deck[0]];
        foreach (var item in groups) {
            if (item.Value != X) {
                X = gcd (item.Value, X);
            }
        }
        return X >= 2;
    }

    /// <summary>
    /// 获取最大公约数
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public int gcd (int x, int y) {
        return (x == 0) ? y : gcd (y % x, x);
    }
}
// @lc code=end

System.Console.WriteLine (2 % 4);
System.Console.WriteLine (4 % 2);
System.Console.WriteLine (5 % 4);