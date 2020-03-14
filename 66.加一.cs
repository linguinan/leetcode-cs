/*
 * @lc app=leetcode.cn id=66 lang=csharp
 *
 * [66] 加一
 */

// @lc code=start
public class Solution {
    public int[] PlusOne(int[] digits) {
        bool plus = true;
        int i = digits.Length - 1;
        while (i >= 0 && plus) {
            plus = digits[i] == 9;
            if (plus)
            {
                digits[i] = 0;
            } else {
                digits[i]++;
            }
            i--;
        }
        // 判断进位
        if (plus)
        {
            int[] newArr = new int[digits.Length + 1];
            newArr[0] = 1;
            for (int j = 1; j < newArr.Length; j++)
            {
                newArr[j] = digits[j - 1];
            }
            return newArr;
        } else {
            return digits;
        }
    }
}
// @lc code=end

