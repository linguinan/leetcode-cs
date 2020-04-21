/*
 * @lc app=leetcode.cn id=1248 lang=csharp
 *
 * [1248] 统计「优美子数组」
 */

// @lc code=start
public class Solution {
    /// <summary>
    /// 滑动窗口
    /// 通过双指针，在恰好有k个奇数的窗口内，统计两边的偶数数字的个数，两者的乘积即为此时的“子数组”个数
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public int NumberOfSubarrays2 (int[] nums, int k) {
        int left = 0, right = 0, oddCnt = 0, res = 0, count = nums.Length;
        while (right < count) {
            if ((nums[right++] & 1) == 1) {
                oddCnt++;
            }
            if (oddCnt == k) {
                int tmpLeft = left, tmpRight = right;
                while (right < count && (nums[right] & 1) == 0) {
                    right++;
                }
                while ((nums[left] & 1) == 0) {
                    left++;
                }
                res += (left - tmpLeft + 1) * (right - tmpRight + 1);
                // 进入下个窗口，此时left指向的是第一个奇数，需移位
                left++;
                oddCnt--;
            }
        }
        return res;
    }

    /// <summary>
    /// 前缀和（即到当前元素为止，数组中有多少个奇数）
    /// 遍历数组，统计到每个元素时前面出现过的奇数的个数
    /// key:前缀和 value:个数
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public int NumberOfSubarrays (int[] nums, int k) {
        int res = 0, cnt = 0;
        // +1 是因为可能都是奇数，此时的下标超出了
        int[] prefixCnts = new int[nums.Length + 1];
        prefixCnts[0] = 1; //起始就算一个
        foreach (int num in nums) {
            cnt += num & 1;
            prefixCnts[cnt]++;
            if (cnt >= k) {
                res += prefixCnts[cnt - k];//k之前的都是可累加的数
            }
        }
        return res;
    }
}
// @lc code=end