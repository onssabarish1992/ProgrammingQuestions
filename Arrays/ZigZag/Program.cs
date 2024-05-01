List<int> a =new List<int>(){1,4,5,3,2};

zigZag(a);

Console.ReadKey();

List<int> zigZag(List<int> a)
{
    a.Sort();
    int mid = a.Count / 2;
    int last = a.Count - 1;

    int max = a.Max();
    a[last] = a[mid];
    a[mid] = max;

    int leftIndex = mid + 1;
    int rightIndex = last - 1;

    while(leftIndex < rightIndex)
    {
        int tmp = a[leftIndex];
        a[leftIndex] = a[rightIndex];
        a[rightIndex] = tmp;

        leftIndex++;
        rightIndex--;
    }

    foreach (var item in a)
    {
        Console.WriteLine(item);
    }

    return a;
}