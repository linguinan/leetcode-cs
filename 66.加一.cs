/*
 * @lc app=leetcode.cn id=66 lang=csharp
 *
 * [66] 加一
 */

// @lc code=start
public class Solution {
    public int[] PlusOne2(int[] digits) {
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
        // // 判断进位
        // if (plus)
        // {
        //     int[] newArr = new int[digits.Length + 1];
        //     newArr[0] = 1;
        //     for (int j = 1; j < newArr.Length; j++)
        //     {
        //         newArr[j] = digits[j - 1];
        //     }
        //     return newArr;
        // } else {
        //     return digits;
        // }

        // 这样写耗时大大减少
        if (plus)
        {
            digits = new int[digits.Length + 1];
            digits[0] = 1;
        } 
        return digits;
    }

    public int[] PlusOne(int[] digits) {
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            digits[i]++;
            // 取余，判断是否进位
            digits[i] = digits[i] % 10;
            // 不为0则无进位，完成加1
            if (digits[i] != 0) return digits;
        }
        // 至此，则需进位，新数组元素默认0
        digits = new int[digits.Length + 1];
        // 进位1
        digits[0] = 1;
        return digits;
    }
}
// @lc code=end

