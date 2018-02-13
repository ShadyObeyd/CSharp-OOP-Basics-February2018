using System;
using System.Collections.Generic;

class TestClients
{
    static void Main()
    {
        Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();

        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] inputTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string command = inputTokens[0];
            int id = int.Parse(inputTokens[1]);

            switch (command)
            {
                case "Create":
                    if (accounts.ContainsKey(id))
                    {
                        Console.WriteLine("Account already exists");
                    }
                    else
                    {
                        BankAccount acc = new BankAccount();
                        acc.Id = id;
                        accounts.Add(id, acc);
                    }
                    break;
                case "Deposit":
                    if (ContainsAccount(id, accounts))
                    {
                        decimal amount = decimal.Parse(inputTokens[2]);
                        accounts[id].Deposit(amount);
                    }
                    break;
                case "Withdraw":
                    if (ContainsAccount(id, accounts))
                    {
                        decimal amount = decimal.Parse(inputTokens[2]);

                        if (amount > accounts[id].Balance)
                        {
                            Console.WriteLine("Insufficient balance");
                        }
                        else
                        {
                            accounts[id].Withdraw(amount);
                        }
                    }
                    break;
                case "Print":
                    if (ContainsAccount(id, accounts))
                    {
                        Console.WriteLine(accounts[id]);
                    }
                    break;
            }
            input = Console.ReadLine();
        }
    }
    
    static bool ContainsAccount(int id, Dictionary<int, BankAccount> accounts)
    {
        if (accounts.ContainsKey(id))
        {
            return true;
        }
        else
        {
            Console.WriteLine("Account does not exist");
            return false;
        }
    }
}

