



Console.WriteLine(caesarCipher("abcdefghijklmnopqrstuvwxyz",2));




string caesarCipher(string s, int k)
{
    for (int i = 0; i < s.Length; i++)
    {
        Console.WriteLine(Convert.ToChar((int)s[i]+" "+(int)s[i] + k));
    }

    return "";
}

Console.ReadKey();