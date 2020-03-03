using System;
using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=102 lang=csharp
 *
 * [102] 二叉树的层次遍历
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
    // BFS
    // public IList<IList<int>> LevelOrder(TreeNode root) {
    //     IList<IList<int>> list = new List<IList<int>>();
    //     if (root == null)
    //         return list;

    //     Queue<TreeNode> queue = new Queue<TreeNode>();
    //     queue.Enqueue(root);

    //     int size = queue.Count;
    //     while (size > 0)
    //     {
    //         IList<int> res = new List<int>();
    //         // 只遍历当前队列中的，后加的下次循环再遍历
    //         for (int i = 0; i < size; i++)
    //         {
    //             TreeNode tn = queue.Dequeue();
    //             res.Add(tn.val);
    //             if (tn.left != null)
    //             {
    //                 queue.Enqueue(tn.left);
    //             }
    //             if (tn.right != null)
    //             {
    //                 queue.Enqueue(tn.right);
    //             }
    //         }
    //         list.Add(res);
    //         size = queue.Count;
    //     }

    //     return list;
    // }

    // DFS
    public IList<IList<int>> LevelOrder(TreeNode root) {
        IList<IList<int>> list = new List<IList<int>>();
        if (root == null)
            return list;

        toDfs(list, root, 0);
        return list;
    }

    private void toDfs(IList<IList<int>> list, TreeNode root, int level)
    {
        // 终止条件，到根底
        if (root == null)
            return;

        // 此层级没初始化过
        if (list.Count < level + 1)
        {
            list.Add(new List<int>());
        }
        list[level].Add(root.val);

        // 遍历左右子树
        toDfs(list, root.left, level + 1);
        toDfs(list, root.right, level + 1);
    }
}
// @lc code=end

