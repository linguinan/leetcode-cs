using System;
/// <summary>
/// 一个有名的按摩师会收到源源不断的预约请求，每个预约都可以选择接或不接。
/// 在每次预约服务之间要有休息时间，因此她不能接受相邻的预约。
/// 给定一个预约请求序列，替按摩师找到最优的预约集合（总预约时间最长），返回总的分钟数。
/// </summary>
public class Solution {
    /// <summary>
    /// 动态规划，分当前i接或不接的方程式计算
    /// 0表示不接 1表示接的情况
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int Massage (int[] nums) {
        if (nums.Length == 0) {
            return 0;
        }
        if (nums.Length == 1) {
            return nums[0];
        }
        if (nums.Length == 2) {
            return Math.Max(nums[0], nums[1]);
        }
        int dp0 = 0;
        int dp1 = nums[0];
        for (int i = 1; i < nums.Length; i++) {
            int tdp0 = Math.Max (dp0, dp1);
            int tdp1 = dp0 + nums[i];
            dp0 = tdp0;
            dp1 = tdp1;
        }
        return Math.Max (dp0, dp1);
    }
}