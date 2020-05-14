public class UnionFind {
    // 集合数
    private int count;
    // 头目数组，值表示头目id
    private int[] parent;
    // 层级，值越高的层级越高
    private int[] rank;
    public UnionFind (char[][] grid) {
        System.Console.WriteLine (grid[0]);
        int row = grid.Length, col = grid[0].Length;
        count = 0;
        parent = new int[row * col];
        rank = new int[row * col];
        for (int i = 0; i < row; i++) {
            for (int j = 0; j < col; j++) {
                if (grid[i][j] == '1') {
                    parent[i * row + j] = i * row + j;
                    count++;
                }
            }
        }
    }

    /// <summary>
    /// 把同个集合的加入来
    /// </summary>
    public void Union (int x, int y) {
        int px = Find (x), py = Find (y);
        if (px != py) {
            if (rank[px] > rank[py]) {
                parent[py] = px;
            } else if (rank[px] < rank[py]) {
                parent[px] = py;
            } else {
                parent[py] = px;
                rank[px]++;
            }
            count--;
            // System.Console.WriteLine(count);
        }
    }

    // 往上追溯头目
    public int Find (int i) {
        if (parent[i] != i) parent[i] = Find (parent[i]);
        return parent[i];
    }

    public int GetCount () {
        return count;
    }
}


static int Main(string[] args)
{
    // char[][] grid = new char[2][]{["1"],["1"]};
    // UnionFind uf = new UnionFind(grid);
    // System.Console.WriteLine(uf);
    return 0;
}
Main (null);