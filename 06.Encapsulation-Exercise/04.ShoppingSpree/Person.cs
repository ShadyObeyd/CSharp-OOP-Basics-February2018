using System;
using System.Collections.Generic;

class Person
{
    private string name;

    public string Name
    {
        get { return name; }
        private set
        {
            if (value == string.Empty || value == null || value == " ")
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }

    private decimal money;

    public decimal Money
    {
        get { return money; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            money = value;
        }
    }

    private List<Product> products;

    public List<Product> Products
    {
        get { return products; }
        private set { products = value; }
    }

    public Person(string name, decimal money)
    {
        Name = name;
        Money = money;
        Products = new List<Product>();
    }

    public override string ToString()
    {
        return Name;
    }
}