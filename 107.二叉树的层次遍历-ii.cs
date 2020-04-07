/*
 * @lc app=leetcode.cn id=107 lang=csharp
 *
 * [107] 二叉树的层次遍历 II
 */

// @lc code=start

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
    /// BFS + Insert
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public IList<IList<int>> LevelOrderBottom (TreeNode root) {
        List<IList<int>> res = new List<IList<int>> ();
        if (root == null) {
            return res;
        }
        Queue<TreeNode> que = new Queue<TreeNode> ();
        que.Enqueue (root);
        while (que.Count > 0) {
            List<int> list = new List<int> ();
            int size = que.Count;
            for (int i = 0; i < size; i++) {
                TreeNode node = que.Dequeue ();
                list.Add (node.val);
                if (node.left != null) {
                    que.Enqueue (node.left);
                }
                if (node.right != null) {
                    que.Enqueue (node.right);
                }
            }
            res.Insert (0, list);
        }
        return res;
    }
}
// @lc code=end