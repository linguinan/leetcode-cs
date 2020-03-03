/*
 * @lc app=leetcode.cn id=121 lang=csharp
 *
 * [121] 买卖股票的最佳时机
 */

// @lc code=start
public class Solution {
    // 暴力法:两层循环遍历，O(n平方)
    // public int MaxProfit(int[] prices) {
    //     int profit = 0;
    //     int count = prices.Length;
    //     int tmpProfit;
    //     for (int i = 0; i < count - 1; i++)
    //     {
    //         for (int j = i + 1; j < count; j++)
    //         {
    //             tmpProfit = prices[j] - prices[i];
    //             if (tmpProfit > profit)
    //             {
    //                 profit = tmpProfit;
    //             }
    //         }
    //     }
    //     return profit;
    // }

    // 查找谷->峰
    // public int MaxProfit(int[] prices) {
    //     if (prices.Length < 2)
    //         return 0;

    //     int minPrice = prices[0];
    //     int maxProfit = 0;
    //     int tmpProfit;
    //     for (int i = 0; i < prices.Length - 1; i++)
    //     {
    //         if (minPrice > prices[i])
    //         {
    //             minPrice = prices[i];
    //         }
    //         tmpProfit = prices[i + 1] - minPrice;
    //         if (tmpProfit > maxProfit)
    //         {
    //             maxProfit = tmpProfit;
    //         }
    //     }
    //     return maxProfit;
    // }

    public int MaxProfit(int[] prices) {
        int minPrice = int.MaxValue;
        int maxProfit = 0;
        int tmpProfit;

        for (int i = 0; i < prices.Length; i++)
        {
            if (prices[i] < minPrice)
            {
                minPrice = prices[i];
            }else
            {
                tmpProfit = prices[i] - minPrice;
                if (tmpProfit > maxProfit)
                {
                    maxProfit = tmpProfit;
                }
            }
        }

        return maxProfit;
    }

    
}
// @lc code=end

