// See https://aka.ms/new-console-template for more information

int[] arr = { 1, 3, 5, 8, 9, 2, 6, 7, 6, 8, 9 };

Console.WriteLine(minJumps(arr,11));
Console.ReadKey();

int minJumps(int[] arr, int n)
{
    int minJumps = 0;

    for (int i = 0; i < arr.Length-1; i=i+arr[i])
    {
        minJumps++;
    }
    return minJumps;
}
