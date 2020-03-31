/*
 * @lc app=leetcode.cn id=515 lang=csharp
 *
 * [515] 在每个树行中找最大值
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
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    /// <summary>
    /// 递归
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public IList<int> LargestValues2 (TreeNode root) {
        List<int> res = new List<int> ();
        if (root == null)
            return res;
        recursive (root, res, 0);
        return res;
    }

    private void recursive (TreeNode root, List<int> res, int level) {
        if (root == null) return;
        if (res.Count == level) {
            res.Add (root.val);
        } else if (res[level] < root.val) {
            res[level] = root.val;
        }
        recursive (root.left, res, level + 1);
        recursive (root.right, res, level + 1);
    }

    /// <summary>
    /// 迭代
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public IList<int> LargestValues (TreeNode root) {
        List<int> res = new List<int> ();
        if (root == null)
            return res;
        int level = -1;
        Queue<TreeNode> queue = new Queue<TreeNode> ();
        queue.Enqueue (root);
        while (queue.Count > 0) {
            level++;
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                TreeNode node = queue.Dequeue ();
                if (res.Count == level) {
                    res.Add (node.val);
                } else if (res[level] < node.val) {
                    res[level] = node.val;
                }
                if (node.left != null) {
                    queue.Enqueue (node.left);
                }
                if (node.right != null) {
                    queue.Enqueue (node.right);
                }
            }
        }
        return res;
    }
}
// @lc code=end