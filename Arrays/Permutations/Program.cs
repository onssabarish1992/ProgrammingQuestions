List<int> elements = new List<int> { 1, 2, 3, 4, 5 };

for (int i = 0; i < elements.Count - 2; i++)
{
    for (int j = i + 1; j < elements.Count - 1; j++)
    {
        for (int k = j + 1; k < elements.Count; k++)
        {
            Console.WriteLine(elements[i]+" "+ elements[j]+" " + elements[k]);
        }
    }
}

Console.ReadKey();