/*
 * @lc app=leetcode.cn id=860 lang=csharp
 *
 * [860] 柠檬水找零
 */

// @lc code=start
public class Solution {
    public bool LemonadeChange2 (int[] bills) {
        if (bills.Length == 0)
            return true;
        if (bills[0] != 5)
            return false;

        int[] own = new int[21];
        for (int i = 0; i < bills.Length; i++) {
            switch (bills[i]) {
                case 5:
                    own[5]++;
                    break;
                case 10:
                    own[10]++;
                    own[5]--;
                    if (own[5] < 0) {
                        return false;
                    }
                    break;
                case 20:
                    own[20]++;
                    if (own[10] > 0) {
                        own[10]--;
                        own[5]--;
                    } else {
                        own[5] -= 3;
                    }
                    if (own[5] < 0) {
                        return false;
                    }
                    break;
            }
        }
        return true;
    }

    /// <summary>
    /// 改进下
    /// </summary>
    /// <param name="bills"></param>
    /// <returns></returns>
    public bool LemonadeChange (int[] bills) {
        if (bills.Length == 0) return true;
        if (bills[0] != 5) return false;

        int five = 0;
        int ten = 0;
        for (int i = 0; i < bills.Length; i++) {
            switch (bills[i]) {
                case 5:
                    five++;
                    break;
                case 10:
                    ten++;
                    five--;
                    if (five < 0) return false;
                    break;
                case 20:
                    if (ten > 0) {
                        ten--;
                        five--;
                    } else {
                        five -= 3;
                    }
                    if (five < 0) return false;
                    break;
            }
        }
        return true;
    }
}
// @lc code=end