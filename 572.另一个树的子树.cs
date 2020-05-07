/*
 * @lc app=leetcode.cn id=572 lang=csharp
 *
 * [572] 另一个树的子树
 */

// @lc code=start

using System;
using System.Collections.Generic;
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    // public bool IsSubtree (TreeNode s, TreeNode t) {
    //     Queue<TreeNode> q = new Queue<TreeNode> ();
    //     q.Enqueue (s);
    //     TreeNode n = null;
    //     while (q.Count > 0) {
    //         n = q.Dequeue ();
    //         if (n.val == t.val) break;
    //         if (n.left != null) q.Enqueue (n.left);
    //         if (n.right != null) q.Enqueue (n.right);
    //     }
    //     if (n == null || n.val != t.val) return false;

    //     Queue<TreeNode> sq = new Queue<TreeNode> ();
    //     bfs (n, sq);
    //     Queue<TreeNode> tq = new Queue<TreeNode> ();
    //     bfs (t, tq);
    //     if (sq.Count != tq.Count) return false;
    //     while (sq.Count > 0) {
    //         if (sq.Dequeue ().val != tq.Dequeue ().val) return false;
    //     }
    //     return true;
    // }

    // private void bfs (TreeNode n, Queue<TreeNode> q) {
    //     if (n == null) return;
    //     q.Enqueue (n);
    //     bfs (n.left, q);
    //     bfs (n.right, q);
    // }

    public bool IsSubtree (TreeNode s, TreeNode t) {
        return dfs (s, t);
    }

    private bool dfs (TreeNode s, TreeNode t) {
        if (s == null) return false;
        return check (s, t) || dfs (s.left, t) || dfs (s.right, t);
    }

    private bool check (TreeNode s, TreeNode t) {
        if (s == null && t == null) return true;
        if (s == null || t == null || s.val != t.val) return false;
        return check (s.left, t.left) && check (s.right, t.right);
    }
}
// @lc code=end