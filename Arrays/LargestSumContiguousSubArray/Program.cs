

List<List<int>> lst = new List<List<int>>
{
    new List<int> { 112, 42, 83, 119 },
    new List<int> { 56,125, 56,49 },
    new List<int> { 15,78, 101,43 },
    new List<int> { 62,98, 114,108 }
};

Console.WriteLine(flippingMatrix(lst));

//Flipping matrix and getting the maximum sum from the upper quadrant
int flippingMatrix(List<List<int>> matrix)
{
    int N = matrix.Count;
    int maxSum = 0;
    for (int i = 0; i < N / 2; i++)
    {
        for (int j = 0; j < N / 2; j++)
        {
            maxSum += Math.Max(Math.Max(matrix[i][j], matrix[i][N - j - 1]), Math.Max(matrix[N - i - 1][j], matrix[N - 1 - i][N - 1 - j]));
        }
    }
    return maxSum;
}




Console.ReadKey();

