using System;

class StartUp
{
    static void Main()
    {
        string[] foodTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        int happiness = 0;
        foreach (string food in foodTokens)
        {
            switch (food.ToLower())
            {
                case "cram":
                    happiness += 2;
                    break;
                case "lembas":
                    happiness += 3;
                    break;
                case "apple":
                case "melon":
                    happiness += 1;
                    break;
                case "honeycake":
                    happiness += 5;
                    break;
                case "mushrooms":
                    happiness -= 10;
                    break;
                default:
                    happiness -= 1;
                    break;
            }
        }
        Console.WriteLine(happiness);

        string mood = string.Empty;

        if (happiness > 15)
        {
            mood = "JavaScript";
        }
        else if (happiness >= 1 && happiness <= 15)
        {
            mood = "Happy";
        }
        else if (happiness >= - 5 && happiness <= 0)
        {
            mood = "Sad";
        }
        else if (happiness < -5)
        {
            mood = "Angry";
        }
        Console.WriteLine(mood);
    }
}