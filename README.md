# leetcode
 leetcode刷题

记：不要在代码行里写注释，太小白了...把必要都注释写在函数头里

重新回顾做过的题，把解法思路写在函数头里，并整理每题的优选解法及思路，并开源到github

自顶向下的解题

把每周的作业写完后一次提交，把提交的commit拷贝到issue里，不要拷贝目录链接！！


# 需熟记的代码模版

## DFS
````python
def dfs(node):
    if node in visited:
        # already visited
        return
    visited.add(node)

    # process current Node
    # ... # logic here
    dfs(node.left)
    dfs(node.right)

    for next_node in node.children():
        if not next_node in visited:
            dfs(next_node)
````

## BFS
````python
def bfs(graph, start, end):
    queue = []
    queue.append([start])
    visited.add(start)
    while queue:
        node = queue.pop()
        visited.add(node)

        process(node)
        nodes = generate_related_nodes(node)
        queue.push(nodes)
    # other processing work
````

迭代法用队列实现
分两种：
1.入列后，依次出列
2.入列后，每次都取出当前列中所有

## 递归

## 分治回溯

## 动态规划

## 二分查找
前提：
- 1.目标函数单调性（单调递增或者递减）
- 2.存在上下界（bounded）
- 3.能够通过索引访问（index accessible）
````python
left, right = 0, len(array) - 1
while left <= right:
    mid = (left + right) / 2
    if array[mid] == target:
        # find the target!!
        break or return result
    elif array[mid] < target:
        left = mid + 1
    else:
        right = mid - 1
````
````c#
int left = 0, right = arr.Length - 1;
while (left <= right) {
    int mid = left + (right - left) / 2;
    if (arr[mid] == target) {
        // break;
        return mid;
    } else {
        if (arr[mid] < target) {
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }
}
return left;
````

欧几里得算法，又名辗转相除法
````c#
// 求最大公约数的算法
// 递归
public int gcd (int x, int y) {
    return (x == 0) ? y : gcd (y % x, x);
}
// 迭代
public int gcd (int x, int y) {
    while (y != 0) {
        int r = y;
        y = x % y;
        x = r;
    }
    return x;
}
````

````c#
// 位运算 与 & 二进制 1&1 = 1 其他情况都为 0
3 & 1 -> 11 & 01 = 1
4 & 1 -> 100 & 001 = 0
5 & 1 -> 101 & 001 = 1
6 & 1 -> 110 & 001 = 0
// 也就区分了奇偶数 
System.Console.WriteLine (3 & 1);
System.Console.WriteLine (4 & 1);
````

````c#
// 二维数组周围8个邻居
int[][] dirs = {
    new int[] {-1, -1 },
    new int[] { 0, -1 },
    new int[] { 1, -1 },
    new int[] {-1, 0 },
    new int[] { 1, 0 },
    new int[] {-1, 1 },
    new int[] { 0, 1 },
    new int[] { 1, 1 }
};
// 也可写出如下，用两层循环实现上面到二维数组
int neighbors[3] = {0, 1, -1};
for (int i = 0; i < 3; i++) {
    for (int j = 0; j < 3; j++) {
        // 0 -> neighbors[i] 
        // 1 -> neighbors[j]
    }
}
````