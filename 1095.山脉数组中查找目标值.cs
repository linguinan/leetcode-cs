/*
 * @lc app=leetcode.cn id=1095 lang=csharp
 *
 * [1095] 山脉数组中查找目标值
 */

// @lc code=start

using System;
/**
 * // This is MountainArray's API interface.
 * // You should not implement it, or speculate about its implementation
 * class MountainArray {
 *     public int Get(int index) {}
 *     public int Length() {}
 * }
 */
class Solution {
    /// <summary>
    /// 二分查找
    /// 1.先确定山顶
    /// 2.先从左侧找
    /// 3.如无再从右侧找
    /// 双百实现！！!
    /// </summary>
    /// <param name="target"></param>
    /// <param name="mountainArr"></param>
    /// <returns></returns>
    public int FindInMountainArray (int target, MountainArray mountainArr) {
        int len = mountainArr.Length ();
        int peakIndex = findMountainTop (mountainArr, 0, len - 1);
        if (mountainArr.Get (peakIndex) == target) {
            return peakIndex;
        }
        int ret = findInSort (mountainArr, 0, peakIndex - 1, target);
        if (ret != -1) {
            return ret;
        }
        return findInReverse (mountainArr, peakIndex + 1, len - 1, target);
    }

    private int findInReverse(MountainArray mountainArr, int left, int right, int target)
    {
        while (left < right) {
            int mid = left + (right - left) / 2;
            int val = mountainArr.Get (mid);
            if (val == target) {
                return mid;
            }
            if (val < target) {
                right = mid - 1;
            }else{
                left = mid + 1;
            }
        }
        return mountainArr.Get (left) == target ? left : -1;
    }

    private int findInSort(MountainArray mountainArr, int left, int right, int target)
    {
        while (left < right) {
            int mid = left + (right - left) / 2;
            int val = mountainArr.Get (mid);
            if (val == target) {
                return mid;
            }
            if (val < target) {
                left = mid + 1;
            }else{
                right = mid - 1;
            }
        }
        return mountainArr.Get (left) == target ? left : -1;
    }

    private int findMountainTop (MountainArray mountainArr, int left, int right) {
        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (mountainArr.Get (mid) < mountainArr.Get (mid + 1)) {
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        return left;
    }
}
// @lc code=end