using System;

class StartUp
{
    static void Main()
    {

        string author = Console.ReadLine();
        string title = Console.ReadLine();
        decimal price = decimal.Parse(Console.ReadLine());

        try
        {
            Book book = new Book(title, author, price);
            Console.WriteLine(book + Environment.NewLine);

            GoldenEditionBook goldenEditionBook = new GoldenEditionBook(title, author, price);
            Console.WriteLine(goldenEditionBook);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

}