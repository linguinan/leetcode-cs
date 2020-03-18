/*
 * @lc app=leetcode.cn id=84 lang=csharp
 *
 * [84] 柱状图中最大的矩形
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution {
    public int LargestRectangleArea(int[] heights) {
        // 使用栈来解，把数组下标入栈
        Stack<int> stack = new Stack<int>();
        // -1标示栈底
        stack.Push(-1);
        int maxArea = 0;
        for (int i = 0; i < heights.Length; i++)
        {
            // 找右边界
            while (stack.Peek() != -1 && heights[stack.Peek()] >= heights[i])
            {
                maxArea = Math.Max(maxArea, heights[stack.Pop()] * (i - stack.Peek() - 1));
            }
            stack.Push(i);
        }
        // 剩下还留在栈里的，其右边界就是数组的长度了
        int r = heights.Length;
        while (stack.Count > 1)
        {
            maxArea = Math.Max(maxArea, heights[stack.Pop()] * (r - stack.Peek() - 1));
        }
        return maxArea;
    }
}
// @lc code=end

