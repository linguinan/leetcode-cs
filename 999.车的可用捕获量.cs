/*
 * @lc app=leetcode.cn id=999 lang=csharp
 *
 * [999] 车的可用捕获量
 */

// @lc code=start
public class Solution {
    public int NumRookCaptures (char[][] board) {
        int ans = 0;
        int n = board.Length;
        int ri = 0;
        int rj = 0;
        findR (board, ref ri, ref rj);

        // int[] dx = {-1, 0, 1, 0};
        // int[] dy = {0, -1, 0, 1};
        // for (int k = 0; k < 4; k++)
        // {
            
        //     dx[k]
        //     dy[k]
        // }

        for (int i = ri - 1; i >= 0; i--) {
            if (board[i][rj] == 'B')
                break;
            if (board[i][rj] == 'p') {
                ans++;
                break;
            }
        }
        for (int i = ri + 1; i < n; i++) {
            if (board[i][rj] == 'B')
                break;
            if (board[i][rj] == 'p') {
                ans++;
                break;
            }
        }
        for (int j = rj - 1; j >= 0; j--) {
            if (board[ri][j] == 'B')
                break;
            if (board[ri][j] == 'p') {
                ans++;
                break;
            }
        }
        for (int j = rj + 1; j < n; j++) {
            if (board[ri][j] == 'B')
                break;
            if (board[ri][j] == 'p') {
                ans++;
                break;
            }
        }

        return ans;
    }

    private static void findR (char[][] board, ref int ri, ref int rj) {
        int n = board.Length;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (board[i][j] == 'R') {
                    ri = i;
                    rj = j;
                    return;
                }
            }
        }
    }
}
// @lc code=end