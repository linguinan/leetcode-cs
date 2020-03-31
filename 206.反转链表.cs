/*
 * @lc app=leetcode.cn id=206 lang=csharp
 *
 * [206] 反转链表
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
    /// 迭代法
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public ListNode ReverseList2 (ListNode head) {
        ListNode prev = null;
        ListNode cur = head;
        while (cur != null) {
            ListNode tmp = cur.next;
            cur.next = prev;
            prev = cur;
            cur = tmp;
        }
        return prev;
    }

    /// <summary>
    /// 递归
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public ListNode ReverseList (ListNode head) {
        if (head == null || head.next == null) {
            return head;
        }
        ListNode res = ReverseList(head.next);
        head.next.next = head;
        head.next = null;
        return res;
    }

}
// @lc code=end