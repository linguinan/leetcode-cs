/*
 * @lc app=leetcode.cn id=365 lang=csharp
 *
 * [365] 水壶问题
 */

// @lc code=start
using System.Collections.Generic;

public class Solution {
    public bool CanMeasureWater (int x, int y, int z) {
        if (z < 0 || z > (x + y)) {
            return false;
        }
        HashSet<int> set = new HashSet<int> ();
        List<int> que = new List<int> ();
        que.Add (0);
        while (que.Count > 0) {
            int n = que[0];
            que.RemoveAt (0);

            int tmp = n + x;
            if (tmp <= (x + y) && set.Add (tmp)) {
                que.Add (tmp);
            }
            tmp = n + y;
            if (tmp <= (x + y) && set.Add (tmp)) {
                que.Add (tmp);
            }
            tmp = n - x;
            if (tmp >= 0 && set.Add (tmp)) {
                que.Add (tmp);
            }
            tmp = n - y;
            if (tmp >= 0 && set.Add (tmp)) {
                que.Add (tmp);
            }
            if (set.Contains (z)) {
                return true;
            }
        }
        return false;
    }
}
// @lc code=end