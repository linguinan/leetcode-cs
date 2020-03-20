using System;
public class Solution {
    /// <code>
    /// 快速排序法
    /// </code>
    public int[] GetLeastNumbers(int[] arr, int k) {
        if (arr.Length <= k)
            return arr;

        Array.Sort(arr);
        int[] resArr = new int[k];
        for (int i = 0; i < k; i++)
        {
            resArr[i] = arr[i];
        }
        return resArr;
    }
}