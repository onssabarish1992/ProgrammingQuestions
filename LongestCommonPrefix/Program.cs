/*
Write a function to find the longest common prefix string amongst an array of strings.

If there is no common prefix, return an empty string "".

 

Example 1:

Input: strs = ["flower","flow","flight"]
Output: "fl"
Example 2:

Input: strs = ["dog","racecar","car"]
Output: ""
Explanation: There is no common prefix among the input strings.

*/

string[] strs = { "Flowering","Flower","Flora" };

Console.WriteLine(LongestCommonPrefix(strs));

Console.ReadKey();

string LongestCommonPrefix(string[] strs)
{ 
    if (strs == null || strs.Length == 0)
    {
        return "";
    }

    Array.Sort(strs);
    string first = strs[0];
    string last = strs[strs.Length - 1];
    int minLength = first.Length;
    int i = 0;

    while (i < minLength && first[i] == last[i])
    {
        i++;
    }

    return first.Substring(0, i);
}



