/*
 * @lc app=leetcode.cn id=127 lang=csharp
 *
 * [127] 单词接龙
 */

// @lc code=start
using System;
using System.Collections.Generic;

public class Solution {
    public int LadderLength (string beginWord, string endWord, IList<string> wordList) {
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
        // BFS
        Queue<KeyValuePair<string, int>> queue = new Queue<KeyValuePair<string, int>> ();
        queue.Enqueue (new KeyValuePair<string, int> (beginWord, 1));

        HashSet<string> visited = new HashSet<string> ();
        visited.Add (beginWord);

        while (queue.Count > 0) {
            int size = queue.Count;
            for (int i = 0; i < size; i++) {
                var cur = queue.Dequeue ();
                string word = cur.Key;
                if (word == endWord) {
                    return cur.Value;
                }

                for (int j = 0; j < len; j++) {
                    char[] arr = word.ToCharArray ();
                    arr[j] = '*';
                    string key = new string (arr);
                    if (dic.ContainsKey (key)) {
                        foreach (var item in dic[key]) {
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
}
// @lc code=end

// static int Main(string[] args)
// {
//     char[] arr = "abc".ToCharArray();
//     arr[0] = '*';
//     System.Console.WriteLine(arr);
//     string str = new string(arr);
//     System.Console.WriteLine(str);
//     return 0;
// }
// Main (null);