/*
 * @lc app=leetcode.cn id=1290 lang=csharp
 *
 * [1290] 二进制链表转整数
 */

// @lc code=start

using System;
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public int GetDecimalValue2 (ListNode head) {
        int[] nums = new int[30];
        int pow = 0;
        nums[pow] = head.val;

        ListNode tail = head;
        while (tail.next != null) {
            tail = tail.next;
            nums[++pow] = tail.val;
        }

        int ans = 0;
        for (int i = pow; i >= 0; i--) {
            if (nums[i] != 0) {
                ans += (int) Math.Pow (2, pow - i);
            }
        }
        return ans;
    }

    public int GetDecimalValue (ListNode head) {
        int ans = 0;
        ListNode node = head;
        while (node != null) {
            ans = ans * 2 + node.val;
            node = node.next;
        }
        return ans;
    }
}
// @lc code=end