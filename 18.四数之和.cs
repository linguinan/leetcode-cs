/*
 * @lc app=leetcode.cn id=18 lang=csharp
 *
 * [18] 四数之和
 */

// @lc code=start
using System.Collections.Generic;

public class Solution {
    public IList<IList<int>> FourSum (int[] nums, int target) {
        List<IList<int>> list = new List<IList<int>> ();
        if (nums.Length < 4) return list;

        int count = nums.Length;
        // 数组排序
        quickSort (nums, 0, count - 1);

        Dictionary<int, int> dic = new Dictionary<int, int> ();
        foreach (int num in nums)
            dic[num] = dic.ContainsKey (num) ? dic[num] + 1 : 1;

        Dictionary<string, bool> checkDic = new Dictionary<string, bool> ();
        int a, b, c, d;
        for (int i = 0; i < count - 2; i++) {
            a = nums[i];
            for (int j = i + 1; j < count - 1; j++) {
                b = nums[j];
                for (int k = j + 1; k < count; k++) {
                    c = nums[k];
                    d = target - (a + b + c);
                    if (d < c) continue;
                    if (!dic.ContainsKey (d)) continue;

                    dic[a]--;
                    dic[b]--;
                    dic[c]--;

                    if (dic[d] > 0) {
                        string key = string.Join ("_", a, b, c, d);
                        if (!checkDic.ContainsKey (key)) {
                            list.Add (new List<int> () { a, b, c, d });
                            checkDic.Add (key, true);
                        }
                    }

                    dic[a]++;
                    dic[b]++;
                    dic[c]++;
                }
            }
        }
        return list;
    }

    private void quickSort (int[] nums, int L, int R) {
        if (L >= R) return;
        int left = L;
        int right = R;
        int pivot = nums[left];
        int tmp;
        while (left < right) {
            tmp = nums[right];
            while (left < right && tmp >= pivot) {
                right--;
                tmp = nums[right];
            }
            if (left < right) nums[left] = tmp;

            tmp = nums[left];
            while (left < right && tmp <= pivot) {
                left++;
                tmp = nums[left];
            }
            if (left < right) nums[right] = tmp;

            if (left >= right) {
                nums[left] = pivot;
            }
        }
        quickSort (nums, L, left - 1);
        quickSort (nums, right + 1, R);
    }
}
// @lc code=end

