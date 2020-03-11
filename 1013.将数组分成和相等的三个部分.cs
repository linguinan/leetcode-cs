/*
 * @lc app=leetcode.cn id=1013 lang=csharp
 *
 * [1013] 将数组分成和相等的三个部分
 */

// @lc code=start
public class Solution {
    public bool CanThreePartsEqualSum(int[] A) {
        int count = A.Length;
        int sum = 0;
        for (int x = 0; x < count; x++) {
            sum += A[x];   
        }
        if (sum % 3 != 0)
            return false;

        int target = sum / 3;
        int i = 0;
        int current = 0;
        while (i < count) {
            current += A[i++];
            if (current == target)
                break;;
        }
        if (current != target)
            return false;

        // 中间判断
        int j = i;
        current = 0;
        while (j < count) {
            current += A[j++];
            if (current == target)
                break;
        }
        // 到末尾了
        if (j >= count)
            return false;

        return current == target;
    }
}
// @lc code=end

