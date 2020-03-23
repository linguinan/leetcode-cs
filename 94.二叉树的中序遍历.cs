/*
 * @lc app=leetcode.cn id=94 lang=csharp
 *
 * [94] 二叉树的中序遍历
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
    public IList<int> InorderTraversal(TreeNode root) {
        IList<int> res = new List<int>();
        inorder(root, res);
        return res;
    }

    private void inorder(TreeNode root, IList<int> list)
    {
        if (root != null)
        {
            inorder(root.left, list);
            list.Add(root.val);
            inorder(root.right, list);
        }
    }

    public IList<int> InorderTraversal2(TreeNode root) {
        List<int> res = new List<int>();
        if (root != null)
        {
            res.AddRange(InorderTraversal(root.left));
            res.Add(root.val);
            res.AddRange(InorderTraversal(root.right));
        }
        return res;
    }
}
// @lc code=end

