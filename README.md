# leetcode
 leetcode刷题

记：不要在代码行里写注释，太小白了...把必要都注释写在函数头里

重新回顾做过的题，把解法思路写在函数头里，并整理每题的优选解法及思路，并开源到github

自顶向下的解题

把每周的作业写完后一次提交，把提交的commit拷贝到issue里，不要拷贝目录链接！！  

好的算法往往要有数据结构的支撑，而数据结构本身的实现，比如散列表，红黑树，又包含了算法优化的精髓。  

面试官通过观察面试者对于算法和数据结构的了解程度，就能比较准确地判断面试者的水平。
比如初级面试者听说过散列表，
中级面试者知道关于散列表的一些算法，
而高级面试者就可能知道散列表算法的实现方式，并且可以对 Java 或者 C++ 自带的散列表实现发表看法，指出它们的优势和不足，并且权衡什么时候应该使用语言自带的散列表，什么时候应该使用第三方开源库的解决方案。
这些细节都会影响最后的定级和 Offer。因此，面试者需要十分重视算法能力的提升。


# 需熟记的代码模版

1.BFS是用来搜索最短径路的解是比较合适的，比如求最少步数的解，最少交换次数的解，因为BFS搜索过程中遇到的解一定是离根最近的，所以遇到一个解，一定就是最优解，此时搜索算法可以终止。这个时候不适宜使用DFS，因为DFS搜索到的解不一定是离根最近的，只有全局搜索完毕，才能从所有解中找出离根的最近的解。（当然这个DFS的不足，可以使用迭代加深搜索ID-DFS去弥补）
2.空间优劣上，DFS是有优势的，DFS不需要保存搜索过程中的状态，而BFS在搜索过程中需要保存搜索过的状态，而且一般情况需要一个队列来记录。
3.DFS适合搜索全部的解，因为要搜索全部的解，那么BFS搜索过程中，遇到离根最近的解，并没有什么用，也必须遍历完整棵搜索树，DFS搜索也会搜索全部，但是相比DFS不用记录过多信息，所以搜素全部解的问题，DFS显然更加合适。 

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

## 双向 BFS 
````python
def bfs(graph, start, end):
    queue_s = []
    queue_e = []
    queue_s.append([start])
    queue_e.append([end])

    visited_s.add(start)
    visited_e.add(end)

    while queue_s && queue_e:
        res = visit(queue_s, visited_s, visited_e)
        if res: return res
        res = visit(queue_e, visited_e, visited_s)
        if res: return res

def visit(queue, visited, otherVisited):
    node = queue.pop()
    if node in otherVisited: return visited[node] + otherVisited[node]
    visited.add(node)
    process(node)
    nodes = generate_related_nodes(node)
    queue.push(nodes)
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
````c#
// 在循环体中查找元素
public int search(int[] nums, int left, int right, int target) {
    // 在[left, right]里查找target
    while (left <= right) {
        // 为了防止left+right整型溢出，写成如下形式
        int mid = left + (right - left) / 2;
        if (nums[mid] == target) {
            return mid;
        } else if (nums[mid] > target) {
            // 下一轮搜索区间：[left, mid - 1]
            right = mid - 1;
        } else {
            // 此时：nums[mid] < target
            // 下一轮搜索区间：[mid + 1, right]
            left = mid + 1;
        }
    }
    return -1;
}
````

欧几里得算法，又名辗转相除法  
能够同时整除x和y的自然数中最大的一个

例如，计算a = 1071和b = 462的最大公约数的过程如下：  
从1071中不断减去462直到小于462（可以减2次，即商q0 = 2），余数是147： 1071 = 2 × 462 + 147.   
然后从462中不断减去147直到小于147（可以减3次，即q1 = 3），余数是21： 462 = 3 × 147 + 21.   
再从147中不断减去21直到小于21（可以减7次，即q2 = 7），没有余数： 147 = 7 × 21 + 0.   
此时，余数是0，所以1071和462的最大公约数是21。
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

// 相邻元素
int[][] dirs = { 
    new int[] {-1, 0 }, 
    new int[] { 0, -1 }, 
    new int[] { 1, 0 }, 
    new int[] { 0, 1 } 
};
// 或
int[] dx = {-1, 1, 0, 0};
int[] dy = {0, 0, -1, 1};
````

待研究：
n皇后最坏情况下的时间复杂度

单向哈希表  
单向散列函数，又称单向Hash函数、杂凑函数，就是把任意长的输入消息串变化成固定长的输出串且由输出串难以得到输入串的一种函数。这个输出串称为该消息的散列值。

顺序表  
顺序表是在计算机内存中以数组的形式保存的线性表，线性表的顺序存储是指用一组地址连续的存储单元依次存储线性表中的各个元素、使得线性表中在逻辑结构上相邻的数据元素存储在相邻的物理存储单元中，即通过数据元素物理存储的相邻关系来反映数据元素之间逻辑上的相邻关系，采用顺序存储结构的线性表通常称为顺序表。

线性表  
线性表是最基本、最简单、也是最常用的一种数据结构。线性表（linear list）是数据结构的一种，一个线性表是n个具有相同特性的数据元素的有限序列。