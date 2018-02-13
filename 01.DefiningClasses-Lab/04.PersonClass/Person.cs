using System;
using System.Collections.Generic;
using System.Linq;


public class Person
{
    string name;
    int age;
    List<BankAccount> accounts;

    public Person(string name, int age): this(name, age, new List<BankAccount>())
    {
        
    }

    public Person(string name, int age, List<BankAccount> accounts)
    {
        this.name = name;
        this.age = age;
        this.accounts = accounts;
    }

    public decimal GetBalance()
    {
        return this.accounts.Sum(b => b.Balance);
    }
}

