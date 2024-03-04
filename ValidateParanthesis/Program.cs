
Console.WriteLine(IsValid("([])"));
Console.ReadKey();

bool IsValid(string s)
{
    Stack<char> stack = new Stack<char>();

    foreach (var character in s)
    {
        if(character == '(' || character == '{' || character == '[')
        {
            stack.Push(character);
        }
        else if(character ==  ')' && (stack.Count == 0 || stack.Pop() != '('))
        {
            return false;
        }
        else if (character == '}' && (stack.Count == 0 || stack.Pop() != '{'))
        {
            return false;
        }
        else if (character == ']' && (stack.Count == 0 || stack.Pop() != '['))
        {
            return false;
        }
    }

    return stack.Count == 0;
}


Console.ReadKey();