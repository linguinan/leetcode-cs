/*
 * @lc app=leetcode.cn id=98 lang=csharp
 *
 * [98] 验证二叉搜索树
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
    public bool IsValidBST(TreeNode root) {
        // 递归实现
        return validate(root, null, null);
    }

    // 注意，此处min和max需用引用对象来表示，以此判断是否有可比较值
    private bool validate(TreeNode root, TreeNode min, TreeNode max)
    {
        if (root == null)
            return true;

        int val = root.val;
        if (min != null && val <= min.val)
            return false;
        if (max != null && val >= max.val)
            return false;

        return validate(root.left, min, root) && validate(root.right, root, max);
    }
}
// @lc code=end

