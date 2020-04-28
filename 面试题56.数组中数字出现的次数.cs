/// <summary>
/// 一个整型数组 nums 里除两个数字之外，其他数字都出现了两次。
/// 请写程序找出这两个只出现一次的数字。要求时间复杂度是O(n)，空间复杂度是O(1)。
/// </summary>
public class Solution {
    /// <summary>
    /// 关键理解：
    /// 如果除了一个数字以外，其他数字都出现了两次，那么如何找到出现一次的数字？
    /// 答案很简单：全员进行异或操作即可
    /// 异或    相同为0，不同为1
    /// 出现两次的数，在异或后肯定抵消掉了
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int[] SingleNumbers (int[] nums) {
        int ret = 0;
        // 先对所有数字进行一次异或，得到两个出现一次的数字的异或值
        foreach (int num in nums)
            ret ^= num;
        // 注：ret 是所求的两个只出现一次的数的异或 所以其中的1所在位必是两者间的不同位
        // 1 = 00001    
        // 跟1的与运算想当于判断每个数的个位数是0或1，其余位都位0了
        System.Console.WriteLine("ret " + ret);
        int div = 1;
        System.Console.WriteLine("div & ret " + (div & ret));
        // 在异或结果中找到任意为 1 的位
        while ((div & ret) == 0)
        {
            div <<= 1;
            System.Console.WriteLine("while div " + div);
        }
        System.Console.WriteLine("div " + div);
        int a = 0, b = 0;
        // 分组异或
        foreach (int num in nums)
            if ((div & num) == 0)
                a ^= num;
            else
                b ^= num;
        return new int[] { a, b };
    }
}

static int Main(string[] args)
{
    Solution solution = new Solution();
    // int[] res = solution.SingleNumbers(new int[] {4,1,4,6});
    int[] res = solution.SingleNumbers(new int[] {1,2,10,4,1,4,3,3});
    System.Console.WriteLine("[" + res[0] + "," + res[1] + "]");
    return 0;
}
Main (null);