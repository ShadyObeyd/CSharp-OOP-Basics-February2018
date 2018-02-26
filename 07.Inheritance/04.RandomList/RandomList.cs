using System;
using System.Collections.Generic;

public class RandomList : List<string>
{
    public string RandomString()
    {
        Random random = new Random();
        string result = string.Empty;

        if (this.Count > 0)
        {
            int index = random.Next(0, this.Count - 1);
            result = this[index];
            this.RemoveAt(index);
        }
        return result;
    }
}