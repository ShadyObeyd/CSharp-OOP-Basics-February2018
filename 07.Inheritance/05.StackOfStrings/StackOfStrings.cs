using System.Collections.Generic;
using System.Linq;

public class StackOfStrings
{
    private List<string> list = new List<string>();

    public void Push(string data)
    {
        list.Add(data);
    }
    
    public bool IsEmpty()
    {
        return list.Any();
    }

    public string Pop()
    {
        string lastElement = string.Empty;
        if (!IsEmpty())
        {
            int lastIndex = list.Count - 1;
            lastElement = this.list[lastIndex];
            this.list.RemoveAt(lastIndex);
        }
        return lastElement;
    }

    public string Peek()
    {
        string lastElement = string.Empty;
        if (!IsEmpty())
        {
            int lastIndex = list.Count - 1;
            lastElement = this.list[lastIndex];
        }
        return lastElement;
    }

}