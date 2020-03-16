/*
 * @lc app=leetcode.cn id=155 lang=csharp
 *
 * [155] 最小栈
 */

// @lc code=start
using System.Collections.Generic;

public class MinStack {

    private Stack<int> dataStack;
    private Stack<int> helperStack;

    /** initialize your data structure here. */
    public MinStack() {
        dataStack = new Stack<int>();
        helperStack = new Stack<int>();
    }
    
    public void Push(int x) {
        dataStack.Push(x);
        if (helperStack.Count == 0 || helperStack.Peek() > x)
        {
            helperStack.Push(x);
        } else {
            helperStack.Push(helperStack.Peek());
        }
    }
    
    public void Pop() {
        dataStack.Pop();
        helperStack.Pop();
    }
    
    public int Top() {
        return dataStack.Peek();
    }
    
    public int GetMin() {
        return helperStack.Peek();
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(x);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */
// @lc code=end

