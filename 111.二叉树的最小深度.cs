/*
 * @lc app=leetcode.cn id=111 lang=csharp
 *
 * [111] 二叉树的最小深度
 */

// @lc code=start
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
    public int MinDepth(TreeNode root) {
        if (root == null)
            return 0;

        // 如子节点不为空，则深度加1
        if (root.left == null)
            return 1 + MinDepth(root.right);
        if (root.right == null)
            return 1 + MinDepth(root.left);

        // 两子节点都不为空，判断那个深度小
        int left = MinDepth(root.left);
        int right = MinDepth(root.right);
        return 1 + ((left > right) ? right : left);
    }
}
// @lc code=end

