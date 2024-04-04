/*
Given an integer array nums of length n, you want to create an array ans of length 2n where ans[i] == nums[i] and ans[i + n] == nums[i] for 0 <= i < n (0-indexed).

Specifically, ans is the concatenation of two nums arrays.

Return the array ans.

Example 1:

Input: nums = [1,2,1]
Output: [1,2,1,1,2,1]
Explanation: The array ans is formed as follows:
- ans = [nums[0],nums[1],nums[2],nums[0],nums[1],nums[2]]
- ans = [1,2,1,1,2,1]
Example 2:

Input: nums = [1,3,2,1]
Output: [1,3,2,1,1,3,2,1]
Explanation: The array ans is formed as follows:
- ans = [nums[0],nums[1],nums[2],nums[3],nums[0],nums[1],nums[2],nums[3]]
- ans = [1,3,2,1,1,3,2,1]
*/



int[] arr = { 1, 2, 1 };

int[] resultArray = GetConcatenation(arr);

for (int i = 0; i < resultArray.Length; i++)
{
    Console.WriteLine(resultArray[i]);
}

Console.ReadKey();



int[] GetConcatenation(int[] nums)
{
    int l_initialLength = nums.Length;
    Array.Resize(ref nums, nums.Length * 2);
    for (int i = l_initialLength; i < nums.Length; i++)
    {
        nums[i] = nums[i - l_initialLength];
    }
    return nums;
}


