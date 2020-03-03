/*
 * @lc app=leetcode.cn id=235 lang=csharp
 *
 * [235] 二叉搜索树的最近公共祖先
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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if (root == null)
            return root;

        int val = root.val;
        // 如都小与root，则都在左子树中
        if (p.val < val && q.val < val)
            return LowestCommonAncestor(root.left, p, q);
        
        // 如都大与root，则都在左子树中
        if (p.val > val && q.val > val)
            return LowestCommonAncestor(root.right, p, q);

        // 否则
        return root;
    }
}
// @lc code=end

