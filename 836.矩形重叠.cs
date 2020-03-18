/*
 * @lc app=leetcode.cn id=836 lang=csharp
 *
 * [836] 矩形重叠
 */

// @lc code=start
public class Solution {
    public bool IsRectangleOverlap(int[] rec1, int[] rec2) {
        bool x_overlap = rec1[2] <= rec2[0] || rec1[0] >= rec2[2];
        bool y_overlap = rec1[3] <= rec2[1] || rec1[1] >= rec2[3];
        return !(x_overlap || y_overlap);
    }
}
// @lc code=end

