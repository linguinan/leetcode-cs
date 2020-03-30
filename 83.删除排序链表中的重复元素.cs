/*
 * @lc app=leetcode.cn id=83 lang=csharp
 *
 * [83] 删除排序链表中的重复元素
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
    public ListNode DeleteDuplicates (ListNode head) {
        if (head == null) {
            return head;
        }
        ListNode root = head;
        int cur = root.val;
        while (root.next != null) {
            if (root.next.val == cur) {
                root.next = root.next.next;
            } else {
                root = root.next;
                cur = root.val;
            }
        }
        return head;
    }
}
// @lc code=end