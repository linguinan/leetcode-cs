/*
 * @lc app=leetcode.cn id=127 lang=csharp
 *
 * [127] 单词接龙
 */

// @lc code=start
using System.Collections.Generic;

public class Solution {
    /// <summary>
    /// BFS 
    /// 先对字典做预处理，实现树结构
    /// 用 visited 表实现剪枝，避免重复访问
    /// </summary>
    /// <param name="beginWord"></param>
    /// <param name="endWord"></param>
    /// <param name="wordList"></param>
    /// <returns></returns>
    public int LadderLength2 (string beginWord, string endWord, IList<string> wordList) {
        if (!wordList.Contains (endWord)) return 0;

        int len = beginWord.Length;
        Dictionary<string, List<string>> dic = new Dictionary<string, List<string>> ();
        // 预处理
        foreach (string word in wordList) {
            for (int i = 0; i < len; i++) {
                char[] arr = word.ToCharArray ();
                arr[i] = '*';
                string key = new string (arr);
                if (!dic.ContainsKey (key)) {
                    dic.Add (key, new List<string> ());
                }
                dic[key].Add (word);
            }
        }
        Queue<KeyValuePair<string, int>> queue = new Queue<KeyValuePair<string, int>> ();
        queue.Enqueue (new KeyValuePair<string, int> (beginWord, 1));

        HashSet<string> visited = new HashSet<string> ();
        visited.Add (beginWord);

        while (queue.Count > 0) {
            int size = queue.Count;
            for (int i = 0; i < size; i++) {
                var cur = queue.Dequeue ();
                string word = cur.Key;
                for (int j = 0; j < len; j++) {
                    char[] arr = word.ToCharArray ();
                    arr[j] = '*';
                    string key = new string (arr);
                    if (dic.ContainsKey (key)) {
                        foreach (var item in dic[key]) {
                            if (item == endWord) {
                                return cur.Value + 1;
                            }
                            if (!visited.Contains (item)) {
                                visited.Add (item);
                                queue.Enqueue (new KeyValuePair<string, int> (item, cur.Value + 1));
                            }
                        }
                    }
                }
            }
        }

        return 0;
    }

    private int wordLen;
    private Dictionary<string, List<string>> preDic;

    /// <summary>
    /// 实现双向 BFS
    /// 从beginWord和endWord同时BFS，相交即结束
    /// </summary>
    /// <param name="beginWord"></param>
    /// <param name="endWord"></param>
    /// <param name="wordList"></param>
    /// <returns></returns>
    public int LadderLength (string beginWord, string endWord, IList<string> wordList) {
        if (!wordList.Contains (endWord)) return 0;

        wordLen = beginWord.Length;
        preDic = new Dictionary<string, List<string>> ();
        // 预处理
        foreach (string word in wordList) {
            for (int i = 0; i < wordLen; i++) {
                char[] arr = word.ToCharArray ();
                arr[i] = '*';
                string key = new string (arr);
                if (!preDic.ContainsKey (key)) {
                    preDic.Add (key, new List<string> ());
                }
                preDic[key].Add (word);
            }
        }

        Queue<KeyValuePair<string, int>> beginQueue = new Queue<KeyValuePair<string, int>> ();
        Queue<KeyValuePair<string, int>> endQueue = new Queue<KeyValuePair<string, int>> ();
        beginQueue.Enqueue (new KeyValuePair<string, int> (beginWord, 1));
        endQueue.Enqueue (new KeyValuePair<string, int> (endWord, 1));

        Dictionary<string, int> beginVisited = new Dictionary<string, int> ();
        Dictionary<string, int> endVisited = new Dictionary<string, int> ();
        beginVisited.Add (beginWord, 1);
        endVisited.Add (endWord, 1);

        while (beginQueue.Count > 0 && endQueue.Count > 0) {
            int ans = visitWordNode (beginQueue, beginVisited, endVisited);
            if (ans > -1) return ans;
            ans = visitWordNode (endQueue, endVisited, beginVisited);
            if (ans > -1) return ans;
        }
        return 0;
    }

    private int visitWordNode (Queue<KeyValuePair<string, int>> queue, Dictionary<string, int> visited, Dictionary<string, int> otherVisited) {
        int size = queue.Count;
        for (int i = 0; i < size; i++) {
            var cur = queue.Dequeue ();
            string word = cur.Key;
            for (int j = 0; j < wordLen; j++) {
                char[] arr = word.ToCharArray ();
                arr[j] = '*';
                string key = new string (arr);
                if (preDic.ContainsKey (key)) {
                    foreach (var item in preDic[key]) {
                        if (otherVisited.ContainsKey (item)) {
                            return cur.Value + otherVisited[item];
                        }
                        if (!visited.ContainsKey (item)) {
                            int level = cur.Value + 1;
                            visited.Add (item, level);
                            queue.Enqueue (new KeyValuePair<string, int> (item, level));
                        }
                    }
                }
            }
        }
        return -1;
    }
}
// @lc code=end