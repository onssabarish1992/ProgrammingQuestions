

//Convert Roman Number To Integer
string romanNumber = "XIV";
Console.WriteLine(ConvertToInt(romanNumber));
Console.ReadKey();

//Function to do the conversion
int ConvertToInt(string s)
{
    int finalResult = 0;
    for (int i = 0; i < s.Length; i++)
    {
        if (i + 1 < s.Length && GetSymbolValue(s[i]) < GetSymbolValue(s[i + 1]))
        {
            finalResult -= GetSymbolValue(s[i]);
        }
        else
        {
            finalResult += GetSymbolValue(s[i]);
        }

    }
    return finalResult;
}

//Switch case to get the symbol value
int GetSymbolValue(char sybmol)
{
    int number = 0;
    switch (sybmol)
    {
        case 'I':
            number = 1;
            break;

        case 'V':
            number = 5;
            break;

        case 'X':
            number = 10;
            break;

        case 'L':
            number = 50;
            break;

        case 'C':
            number = 100;
            break;

        case 'D':
            number = 500;
            break;

        case 'M':
            number = 1000;
            break;

        default:
            number = 0;
            break;
    }

    return number;
}
