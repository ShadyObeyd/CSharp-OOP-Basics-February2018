using System;

class StartUp
{
    static void Main()
    {
        double lenght = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        Box box = new Box(lenght, width, height);

        Console.WriteLine($"Surface Area - {box.GetSufaceArea():f2}");
        Console.WriteLine($"Lateral Surface Area - {box.GetLateralSurfaceArea():f2}");
        Console.WriteLine($"Volume - {box.GetVolume():f2}");
    }
}