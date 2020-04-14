/*
 * @lc app=leetcode.cn id=445 lang=csharp
 *
 * [445] 两数相加 II
 */

// @lc code=start

using System.Collections.Generic;
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode AddTwoNumbers (ListNode l1, ListNode l2) {
        Stack<int> stack1 = new Stack<int> ();
        Stack<int> stack2 = new Stack<int> ();
        while (l1 != null) {
            stack1.Push (l1.val);
            l1 = l1.next;
        }
        while (l2 != null) {
            stack2.Push (l2.val);
            l2 = l2.next;
        }
        int carry = 0;
        ListNode head = null;
        while (stack1.Count > 0 || stack2.Count > 0 || carry > 0) {
            int num = carry;
            num += stack1.Count > 0 ? stack1.Pop () : 0;
            num += stack2.Count > 0 ? stack2.Pop () : 0;
            ListNode node = new ListNode (num % 10);
            node.next = head;
            carry = num / 10;
            head = node;
        }
        return head;
    }
}
// @lc code=end