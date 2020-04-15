/*
 * @lc app=leetcode.cn id=355 lang=csharp
 *
 * [355] 设计推特
 */

// @lc code=start
using System;
using System.Collections.Generic;

/// <summary>
/// 实现的关键点：
/// 1.用hash保存follow
/// 2.获取最近10条时，从后判断，时间更早的才入列，从每个follow中最多取前10条判断
/// </summary>
public class Twitter {
    private Dictionary<int, Node> userDic;
    private int recentMax = 10;
    private int time = 0;

    struct Node {
        /// <summary>
        /// 关注者
        /// </summary>
        public HashSet<int> follows;
        /// <summary>
        /// 自己发的推文
        /// </summary>
        public List<Tweet> tweets;
    }

    struct Tweet {
        public int tweetId;
        public int timestamp;
    }

    /** Initialize your data structure here. */
    public Twitter () {
        userDic = new Dictionary<int, Node> ();
    }

    /** Compose a new tweet. */
    public void PostTweet (int userId, int tweetId) {
        init (userId);
        Node node = userDic[userId];
        Tweet tweet = new Tweet ();
        tweet.tweetId = tweetId;
        tweet.timestamp = ++time;
        node.tweets.Insert (0, tweet);
    }

    /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
    public IList<int> GetNewsFeed (int userId) {
        List<int> recentTweets = new List<int> ();
        if (!userDic.ContainsKey (userId)) return recentTweets;

        List<Tweet> tmpList = new List<Tweet> ();
        Node node = userDic[userId];
        int count = Math.Min (node.tweets.Count, recentMax);
        if (count > 0) {
            tmpList.AddRange (node.tweets.GetRange (0, count));
        }
        // 只取前10条
        foreach (int followeeId in node.follows) {
            List<Tweet> tweets = userDic[followeeId].tweets;
            count = Math.Min (tweets.Count, recentMax);
            for (int i = 0; i < count; i++) {
                int time = tweets[i].timestamp;
                if (tmpList.Count >= recentMax && tmpList[tmpList.Count - 1].timestamp > time) break;
                int idx = 0;
                for (int j = tmpList.Count - 1; j >= 0; j--) {
                    if (tmpList[j].timestamp > time) {
                        idx = j + 1;
                        break;
                    }
                }
                tmpList.Insert (idx, tweets[i]);
                // if (tmpList.Count > recentMax) {
                //     tmpList.RemoveRange (recentMax - 1, tmpList.Count - recentMax);
                // }
            }
        }

        for (int i = 0; i < Math.Min (tmpList.Count, recentMax); i++) {
            recentTweets.Add (tmpList[i].tweetId);
        }
        return recentTweets;
    }

    /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
    public void Follow (int followerId, int followeeId) {
        if (followerId == followeeId) return;
        init (followerId);
        init (followeeId);
        userDic[followerId].follows.Add (followeeId);
    }

    /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
    public void Unfollow (int followerId, int followeeId) {
        if (followerId == followeeId) return;
        if (!userDic.ContainsKey (followerId)) return;
        userDic[followerId].follows.Remove (followeeId);
    }

    private void init (int userId) {
        if (userDic.ContainsKey (userId)) return;
        Node node = new Node ();
        node.follows = new HashSet<int> ();
        node.tweets = new List<Tweet> ();
        userDic.Add (userId, node);
    }
}

/**
 * Your Twitter object will be instantiated and called as such:
 * Twitter obj = new Twitter();
 * obj.PostTweet(userId,tweetId);
 * IList<int> param_2 = obj.GetNewsFeed(userId);
 * obj.Follow(followerId,followeeId);
 * obj.Unfollow(followerId,followeeId);
 */
// @lc code=end