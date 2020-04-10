/*
 * @lc app=leetcode.cn id=160 lang=csharp
 *
 * [160] 相交链表
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
    /// <summary>
    /// 哈希法，空间复杂度O(n)
    /// </summary>
    /// <param name="headA"></param>
    /// <param name="headB"></param>
    /// <returns></returns>
    public ListNode GetIntersectionNode2 (ListNode headA, ListNode headB) {
        HashSet<ListNode> hash = new HashSet<ListNode> ();
        ListNode node = headA;
        while (node != null) {
            hash.Add (node);
            node = node.next;
        }
        node = headB;
        while (node != null) {
            if (hash.Contains (node)) {
                return node;
            }
            node = node.next;
        }
        return null;
    }

    /// <summary>
    /// 双指针，空间复杂度O(1)
    /// 链表循环总相遇
    /// </summary>
    /// <param name="headA"></param>
    /// <param name="headB"></param>
    /// <returns></returns>
    public ListNode GetIntersectionNode (ListNode headA, ListNode headB) {
        if (headA == null && headB == null) return null;
        ListNode pA = headA;
        ListNode pB = headB;
        while (pA != pB) {
            pA = pA == null ? headB : pA.next;
            pB = pB == null ? headA : pB.next;
        }
        return pA;
    }
}
// @lc code=end