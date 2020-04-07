/// <summary>
/// 给你一幅由 N × N 矩阵表示的图像，其中每个像素的大小为 4 字节。请你设计一种算法，将图像旋转 90 度。
/// </summary>
public class Solution {
    public void Rotate (int[][] matrix) {
        int n = matrix.Length;
        int[][] tmp = new int[n][];
        for (int i = 0; i < n; i++) {
            tmp[i] = new int[n];
        }
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                tmp[j][n - 1 - i] = matrix[i][j];
            }
        }
        // for (int i = 0; i < n; i++) {
        //     matrix[i] = tmp[i];
        // }
        tmp.CopyTo(matrix, 0);
    }
}