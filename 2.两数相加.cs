/*
 * @lc app=leetcode.cn id=2 lang=csharp
 *
 * [2] 两数相加
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    /// <summary>
    /// head先行实例化，用head.next来指代起始节点
    /// 循环给next赋值来递进链表
    /// </summary>
    /// <param name="l1"></param>
    /// <param name="l2"></param>
    /// <returns></returns>
    public ListNode AddTwoNumbers (ListNode l1, ListNode l2) {
        int carry = 0;
        ListNode head = new ListNode (0);
        ListNode curr = head;
        while (l1 != null || l2 != null) {
            int num = carry;
            if (l1 != null) {
                num += l1.val;
                l1 = l1.next;
            }
            if (l2 != null) {
                num += l2.val;
                l2 = l2.next;
            }
            curr.next = new ListNode (num % 10);
            curr = curr.next;
            carry = num / 10;
        }
        if (carry > 0) {
            curr.next = new ListNode (carry);
        }
        return head.next;
    }
}
// @lc code=end