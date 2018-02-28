using System;
using System.Text;

public class Book
{
    public const int MinTitleLenght = 3;
    public const decimal MinValidPrice = 1.0m;

    private string title;

    public string Title
    {
        get { return this.title; }
        protected set
        {
            if (value?.Length < MinTitleLenght)
            {
                throw new ArgumentException(GetErrorMessage("Title"));
            }
            this.title = value;
        }
    }

    private string author;

    public string Author
    {
        get { return this.author; }
        protected set
        {
            if (!AuthorIsValid(value))
            {
                throw new ArgumentException(GetErrorMessage("Author"));
            }
            this.author = value;
        }
    }

    private decimal price;

    public virtual decimal Price
    {
        get { return this.price; }
        protected set
        {
            if (value < MinValidPrice)
            {
                throw new ArgumentException(GetErrorMessage("Price"));
            }
            this.price = value;
        }
    }

    public Book(string title, string author, decimal price)
    {
        Title = title;
        Author = author;
        Price = price;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine($"Type: {this.GetType().Name}");
        builder.AppendLine($"Title: {Title}");
        builder.AppendLine($"Author: {Author}");
        builder.AppendLine($"Price: {Price:f2}");

        return builder.ToString().TrimEnd();
    }

    private bool AuthorIsValid(string value)
    {
        string[] nameTokens = value?.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (nameTokens.Length == 1)
        {
            return true;
        }
        else
        {
            string secondName = nameTokens[1];

            if (char.IsDigit(secondName[0]))
            {
                return false;
            }
            return true;
        }
    }

    private string GetErrorMessage(string field)
    {
        return $"{field} not valid!";
    }
}