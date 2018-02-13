using System;


class StartUp
{
    static void Main()
    {
        BankAccount bankAccount = new BankAccount();

        bankAccount.Id = 1;
        bankAccount.Balance = 15;

        Console.WriteLine($"Account {bankAccount.Id}, balance {bankAccount.Balance}");
    }
}

