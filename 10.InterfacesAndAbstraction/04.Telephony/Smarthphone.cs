using System;
using System.Text.RegularExpressions;

public class Smarthphone : ICallable, IBrowesable
{
    public string[] Numbers { get; private set; }
    public string[] Sites { get; private set; }

    public Smarthphone(string[] numbers, string[] sites)
    {
        Numbers = numbers;
        Sites = sites;
    }

    public void Browse()
    {
        Regex pattern = new Regex(@"^\D*$");

        foreach (string site in Sites)
        {
            if (pattern.IsMatch(site))
            {
                Console.WriteLine($"Browsing: {site}!");
            }
            else
            {
                Console.WriteLine("Invalid URL!");
            }
        }
    }

    public void Call()
    {
        foreach (string number in Numbers)
        {
            Regex pattern = new Regex(@"^\d*$");

            if (pattern.IsMatch(number))
            {
                Console.WriteLine($"Calling... {number}");
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
        }
    }
}