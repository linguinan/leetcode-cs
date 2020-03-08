/*
 * @lc app=leetcode.cn id=15 lang=csharp
 *
 * [15] 三数之和
 */

// @lc code=start
using System.Collections.Generic;

public class Solution {

    // 快速排序
    private void quickSort(int[] nums, int L, int R) {
        if (L >= R) return;
        int left = L; 
        int right = R;
        int pivot = nums[left];
        int tmp;
        while (left < right)
        {
            // 先把右侧大于pivot的都判断了，直到小于pivot的
            // 从右向左找第一个小于x的数
            tmp = nums[right];
            while (left < right && tmp >= pivot) {
                right--;
                tmp = nums[right];
            }
            // 此时如果还符合条件则移动
            if (left < right) {
                nums[left] = tmp;
            }

            // 反之
            // 从左向右找第一个大于等于x的数
            tmp = nums[left];
            while (left < right && tmp <= pivot) {
                left++;
                tmp = nums[left];
            }
            if (left < right) {
                nums[right] = tmp;
            }

            // 终止条件
            if (left >= right) {
                nums[left] = pivot;
            }
        }
        // 递归调用 
        quickSort(nums, L, left - 1);
        quickSort(nums, right + 1, R);
    }

    public IList<IList<int>> ThreeSum(int[] nums) {
        IList<IList<int>> list = new List<IList<int>>();
        if (nums.Length < 3)
            return list;

        int count = nums.Length;
        // 数组排序
        quickSort(nums, 0, count - 1);

        Dictionary<int, int> dic = new Dictionary<int, int>();
        int item;
        for (int i = 0; i < count; i++)
        {
            item = nums[i];
            if (dic.ContainsKey(item))
            {
                dic[item]++;
            }else {
                dic[item] = 1;
            }
        }

        // 判断都是0的情况
        if (dic.Count == 1 && nums[0] == 0)
        {
            list.Add(new List<int>(){0, 0, 0});
            return list;
        }

        Dictionary<string, bool> checkDic = new Dictionary<string, bool>();
        for (int i = 0; i < count - 1; i++)
        {
            int a = nums[i];
            for (int j = i + 1; j < count; j++)
            {
                int b = nums[j];
                int c = -(a + b);
                // 数组是有序的，如果c小于b，则可忽略了
                if (c < b) continue;

                dic[a]--;
                dic[b]--;
                // 避免a/b被重复使用了
                if (dic.ContainsKey(c) && dic[c] > 0)
                {
                    IList<int> resList = new List<int>();
                    resList.Add(a);
                    resList.Add(b);
                    resList.Add(c);
                    string tmp = a + "-" + b;//resList[0] + "-" + resList[1];
                    if (!checkDic.ContainsKey(tmp))
                    {
                        checkDic.Add(tmp, true);
                        list.Add(resList);
                    }
                }
                dic[a]++;
                dic[b]++;
            }
        }

        return list;
    }
}
// @lc code=end

