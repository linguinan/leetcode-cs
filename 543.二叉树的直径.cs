/*
 * @lc app=leetcode.cn id=543 lang=csharp
 *
 * [543] 二叉树的直径
 */

// @lc code=start

using System;
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

    private int maxDepth = 0;
    public int DiameterOfBinaryTree(TreeNode root) {
        if (root == null)
            return 0;

        int len = maxLen(root.left) + maxLen(root.right);
        return len > maxDepth ? len : maxDepth;
    }

    private int maxLen(TreeNode root)
    {
        if (root == null)
            return 0;

        int left = maxLen(root.left);
        int right = maxLen(root.right);
        if ((left + right) > maxDepth)
        {
            maxDepth = left + right;
        }
        return left > right ? 1 + left : 1 + right;
    }
}
// @lc code=end

