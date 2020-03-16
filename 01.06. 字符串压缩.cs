// 字符串压缩。
// 利用字符重复出现的次数，编写一种方法，实现基本的字符串压缩功能。
// 比如，字符串aabcccccaaa会变为a2b1c5a3。
// 若“压缩”后的字符串没有变短，则返回原先的字符串。
// 你可以假设字符串中只包含大小写英文字母（a至z）。

using System.Text;

public class Solution {
    // 暴力法
    // 100 ms	24.5 MB	    string
    // 456 ms	45.1 MB     StringBuilder
    // 两厢比较StringBuilder速度和内存都大大优于string
    public string CompressString2(string S) {
        int count = S.Length;
        if (count <= 2) return S;
        
        char[] chars = S.ToCharArray();
        char ch = chars[0];
        int cnt = 1;
        // string newStr = "";
        StringBuilder newStr = new StringBuilder();
        for (int i = 1; i < count; i++)
        {
            if (chars[i] != ch)
            {
                // newStr += ch + cnt.ToString();
                newStr.Append(ch);
                newStr.Append(cnt);
                ch = chars[i];
                cnt = 1;
            } else {
                cnt++;
            }
        }
        // newStr += ch + cnt.ToString();
        // return newStr.Length >= count ? S : newStr;
        newStr.Append(ch);
        newStr.Append(cnt);
        return newStr.Length >= count ? S : newStr.ToString();
    }

    // 双指针法
    public string CompressString(string S) {
        int count = S.Length;
        if (count <= 2) return S;

        StringBuilder newStr = new StringBuilder();
        char[] chars = S.ToCharArray();
        int i = 0;
        int j = 0;
        while (i < count)
        {
            char ch = chars[i];
            while (j < count && ch == chars[j])
            {
                j++;
            }
            newStr.Append(ch);
            newStr.Append(j - i);
            i = j;
        }
        return newStr.Length >= count ? S : newStr.ToString();
    }

}