# leetcode
 leetcode刷题

记：不要在代码行里写注释，太小白了...把必要都注释写在函数头里

重新回顾做过的题，把解法思路写在函数头里，并整理每题的优选解法及思路，并开源到github

自顶向下的解题

把每周的作业写完后一次提交，把提交的commit拷贝到issue里，不要拷贝目录链接！！


# 需熟记的代码模版

## DFS（Depth-First-Search） 多用stack（先进后出）实现
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

## BFS（Breadth First Search）多用queue（先进先出）实现
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
递归指由一种（或多种）简单的基本情况定义的一类对象或方法，并规定其他所有情况都能被还原为其基本情况  
思维要点：  
- 1. 不要人肉递归（最大误区）
- 2. 找到最近最简方法，将其拆解成可重复解决的问题（重复子问题）
- 3. 数学归纳法思维
````c#
public void recursion(int level, int param) {
    // terminator
    if (level > MAX_LEVEL) {
        // process result
        return;
    }

    // process current logic
    process(level, param);

    // drill down
    recursion(level + 1, newParam);

    // restore current status
}
````

## 分治回溯
分治和回溯本质上都是递归  
“分而治之”，就是把一个复杂的问题分成两个或更多的相同或相似的子问题，直到最后子问题可以简单的直接求解，原问题的解即子问题的解的合并。
````python
def divide_conquer(problem, param1, param2, ...):
    # recursion terminator
    if problem is None:
        print_result
        return
    # prepare data
    data = prepare_data(problem)
    subproblems = split_problem(problem, data)
    # conquer subproblems
    subresult1 = self.divide_conquer(subproblems[0], p1, ...)
    subresult2 = self.divide_conquer(subproblems[1], p1, ...)
    subresult3 = self.divide_conquer(subproblems[2], p1, ...)
    ...
    # process and generate the final result
    result = process_result(subresult1, subresult2, subresult3, ...)
    # revert the current level states
````

回溯法是一种可以找出所有（或一部分）解的一般性算法，
尤其适用于约束满足问题（在解决约束满足问题时，我们逐步构造更多的候选解，并且在确定某一部分候选解不可能补全成正确解之后放弃继续搜索这个部分候选解本身及其可以拓展出的子候选解，转而测试其他的部分候选解）  

回溯法采用试错的思想，它尝试分步的去解决一个问题。在分步解决问题的过程中，当它通过尝试，发现现有的分步答案不能得到有效的正确的解答的时候，它将取消上一步甚至是上几步的计算，再通过其它的可能的分步解答再次尝试寻找问题的答案。  
回溯法通常用最简单的递归方法来实现，在反复重复上述的步骤后可能出现两种情况:  
- 找到一个可能存在的正确的答案;
- 在尝试了所有可能的分步方法后宣告该问题没有答案。 
在最坏的情况下，回溯法会导致一次复杂度为指数时间的计算。

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
// 
for (int di = -1; di <= 1; di++) {
    for (int dj = -1; dj <= 1; dj++) {
        if (di == 0 && dj == 0) continue;
        //...
    }
}
````