/*
 * @lc app=leetcode.cn id=145 lang=csharp
 *
 * [145] 二叉树的后序遍历
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
    public IList<int> PostorderTraversal(TreeNode root) {
        List<int> res = new List<int>();
        if (root != null)
        {
            res.AddRange(PostorderTraversal(root.left));
            res.AddRange(PostorderTraversal(root.right));
            res.Add(root.val);
        }
        return res;
    }
}
// @lc code=end

