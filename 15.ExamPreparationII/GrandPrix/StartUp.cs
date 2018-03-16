using System;

public class StartUp
{
    static void Main()
    {
        int laps = int.Parse(Console.ReadLine());
        int trackLength = int.Parse(Console.ReadLine());

        RaceTower tower = new RaceTower();

        tower.SetTrackInfo(laps, trackLength);

        Engine engine = new Engine(tower);

        engine.Run();
    }
}