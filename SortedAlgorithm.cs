using System;

public class SortedAlgorithm {

    /// <summary>
    /// 冒泡排序    O(n^2)
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int[] BubbleSort (int[] nums) {
        int len = nums.Length, tmp;
        bool flag = false;
        for (int i = 0; i < len; i++) {
            for (int j = 0; j < len - 1; j++) {
                if (nums[j] > nums[j + 1]) {
                    tmp = nums[j];
                    nums[j] = nums[j + 1];
                    nums[j + 1] = tmp;
                    flag = true;
                }
            }
            if (!flag) break;
        }
        return nums;
    }

    /// <summary>
    /// 选择排序    O(n^2)
    /// 每次找最小值排到前面
    /// </summary>
    /// <param name="nums"></param>
    public int[] SelectionSort (int[] nums) {
        int len = nums.Length, minIndex, tmp;
        for (int i = 0; i < len; i++) {
            minIndex = i;
            for (int j = i + 1; j < len; j++) {
                if (nums[minIndex] > nums[j]) {
                    minIndex = j;
                }
            }
            tmp = nums[i];
            nums[i] = nums[minIndex];
            nums[minIndex] = tmp;
        }
        return nums;
    }

    /// <summary>
    /// 插入排序    
    /// 每次循环把后一个元素插入前面已排好的队列中
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int[] InsertionSort (int[] nums) {
        int tmp;
        for (int i = 1; i < nums.Length; i++) {
            for (int j = i; j > 0; j--) {
                if (nums[j] < nums[j - 1]) {
                    tmp = nums[j];
                    nums[j] = nums[j - 1];
                    nums[j - 1] = tmp;
                } else {
                    break;
                }
            }
        }
        return nums;
    }

    /// <summary>
    /// 快速排序
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int[] QuickSort (int[] nums) {
        quickSort (nums, 0, nums.Length - 1);
        return nums;
    }

    private void quickSort (int[] nums, int L, int R) {
        if (L >= R) return;
        int left = L, right = R;
        partition (nums, ref left, ref right);
        // 递归调用 
        quickSort (nums, L, left - 1);
        quickSort (nums, right + 1, R);
    }

    private static void partition (int[] nums, ref int left, ref int right) {
        int pivot = nums[left], tmp;
        while (left < right) {
            // 先把右侧大于pivot的都判断了，直到小于pivot的
            // 从右向左找第一个小于x的数
            tmp = nums[right];
            while (left < right && tmp >= pivot) {
                right--;
                tmp = nums[right];
            }
            // 此时如果还符合条件则移动
            if (left < right) nums[left] = tmp;

            // 反之
            // 从左向右找第一个大于等于x的数
            tmp = nums[left];
            while (left < right && tmp <= pivot) {
                left++;
                tmp = nums[left];
            }
            if (left < right) nums[right] = tmp;
            // 终止条件
            if (left >= right) nums[left] = pivot;
        }
    }

    /// <summary>
    /// 归并排序
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int[] MergeSort (int[] nums) {
        int[] tmp = new int[nums.Length];
        mergeSort (nums, 0, nums.Length - 1, tmp);
        return nums;
    }

    private void mergeSort (int[] nums, int left, int right, int[] tmp) {
        if (left >= right) return;
        int mid = (left + right) >> 1;
        mergeSort (nums, left, mid, tmp);
        mergeSort (nums, mid + 1, right, tmp);
        merge (nums, left, mid, right, tmp);
    }

    private void merge (int[] nums, int left, int mid, int right, int[] tmp) {
        int i = left, j = mid + 1, t = 0;
        while (i <= mid && j <= right) {
            tmp[t++] = (nums[i] <= nums[j]) ? nums[i++] : nums[j++];
        }
        while (i <= mid) tmp[t++] = nums[i++];
        while (j <= right) tmp[t++] = nums[j++];
        t = 0;
        while (left <= right) nums[left++] = tmp[t++];
    }

    /// <summary>
    /// 桶排序
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int[] BucketSort (int[] nums) {
        return nums;
    }

    /// <summary>
    /// 计数排序
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int[] CountSort (int[] nums) {
        return nums;
    }

    /// <summary>
    /// 希尔排序    又叫缩小增量排序    插入排序的改进版    非稳定排序
    /// 基本思想：
    /// 先将整个待排序的记录序列分割成为若干子序列分别进行直接插入排序，
    /// 待整个序列中待记录“基本有序”时，再对全体记录进行一次直接插入排序
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int[] ShellSort (int[] nums) {
        int len = nums.Length;
        // / 2 拆分两半，后半部分和前半部分进行比较，把大的替换到后面来
        int gap = len / 2;
        while (gap >= 1) {
            for (int i = 0; i < len; i++) {
                int j = i;
                // j 大于 gap 且 前面的数大于后面的，则调换
                while (j >= gap && nums[j - gap] > nums[j]) {
                    System.Console.WriteLine(j + " - " + nums[j] + " | " + (j - gap) + " - " + nums[j - gap]);
                    int tmp = nums[j];
                    nums[j] = nums[j - gap];
                    nums[j - gap] = tmp;
                    j -= gap;
                }
            }
            System.Console.WriteLine("for : " + gap + " - " + string.Join (",", nums));
            gap = gap / 2;
        }
        return nums;
    }

    /// <summary>
    /// 堆排序
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int[] HeapSort (int[] nums) {
        return nums;
    }

    /// <summary>
    /// 基数排序
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int[] RadixSort (int[] nums) {
        return nums;
    }

}

static int Main (string[] args) {
    int[] nums = new int[10] { 10, 2, 13, 24, 95, 36, 87, 80, 19, 20 };
    SortedAlgorithm ins = new SortedAlgorithm ();
    System.Console.WriteLine (string.Join (",", ins.BubbleSort ((int[]) nums.Clone ())));
    System.Console.WriteLine (string.Join (",", ins.SelectionSort ((int[]) nums.Clone ())));
    System.Console.WriteLine (string.Join (",", ins.InsertionSort ((int[]) nums.Clone ())));
    System.Console.WriteLine (string.Join (",", ins.QuickSort ((int[]) nums.Clone ())));
    System.Console.WriteLine (string.Join (",", ins.MergeSort ((int[]) nums.Clone ())));
    System.Console.WriteLine (string.Join (",", ins.ShellSort ((int[]) nums.Clone ())));

    // System.Console.WriteLine (string.Join (",", nums));
    return 0;
}
Main (null);