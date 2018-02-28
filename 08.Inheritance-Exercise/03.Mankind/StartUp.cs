using System;

class StartUp
{
    static void Main()
    {
        string[] studentTokens = ReadInput();
        string[] workerTokens = ReadInput();

        string studendFirstName = studentTokens[0];
        string studendSecondName = studentTokens[1];
        string facultyNumber = studentTokens[2];

        string workerFirstName = workerTokens[0];
        string workerSecondName = workerTokens[1];
        decimal weekSalary = decimal.Parse(workerTokens[2]);
        decimal hoursPerDay = decimal.Parse(workerTokens[3]);

        try
        {
            Student student = new Student(studendFirstName, studendSecondName, facultyNumber);
            Worker worker = new Worker(workerFirstName, workerSecondName, weekSalary, hoursPerDay);

            PrintHuman(student);
            Console.WriteLine();
            PrintHuman(worker);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    private static void PrintHuman(Human human)
    {
        Console.WriteLine(human);
    }

    private static string[] ReadInput()
    {
        return Console.ReadLine().Split(' ');
    }
}