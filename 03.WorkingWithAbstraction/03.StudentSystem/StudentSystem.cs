using System;
using System.Collections.Generic;

public class StudentSystem
{
    private Dictionary<string, Student> repo;

    public StudentSystem()
    {
        this.Repo = new Dictionary<string, Student>();
    }

    private Dictionary<string, Student> Repo
    {
        get { return repo; }
        set { repo = value; }
    }

    public void ParseCommand(string input, Action<string> print)
    {
        string[] inputTokens = input.Split();

        if (inputTokens[0] == "Create")
        {
            CreateStudent(inputTokens);
        }
        else if (inputTokens[0] == "Show")
        {
            Show(print, inputTokens);
        }
    }

    private void Show(Action<string> print, string[] inputTokens)
    {
        var name = inputTokens[1];
        if (Repo.ContainsKey(name))
        {
            var student = Repo[name];

            print(student.ToString());
        }
    }

    private void CreateStudent(string[] inputTokens)
    {
        var name = inputTokens[1];
        var age = int.Parse(inputTokens[2]);
        var grade = double.Parse(inputTokens[3]);
        if (!repo.ContainsKey(name))
        {
            var student = new Student(name, age, grade);
            Repo[name] = student;
        }
    }
}