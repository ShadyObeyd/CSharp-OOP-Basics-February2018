using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private const string CRASH_MESSAGE = "Crashed";
    private int totalLapsCount;
    private int trackLength;
    private List<Driver> racingDrivers;
    private Stack<Driver> failedDrivers;
    private DriverFactory factory;
    private string weather;
    private int currentLap;
    public bool raceOver => this.totalLapsCount == this.currentLap;

    public RaceTower()
    {
        this.racingDrivers = new List<Driver>();
        this.failedDrivers = new Stack<Driver>();
        this.factory = new DriverFactory();
        this.weather = "Sunny";
        this.currentLap = 0;
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.totalLapsCount = lapsNumber;
        this.trackLength = trackLength;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            Driver driver = this.factory.CreateDriver(commandArgs);
            this.racingDrivers.Add(driver);
        }
        catch (Exception)
        {

        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string reasonToBox = commandArgs[0];
        string driversName = commandArgs[1];

        Driver driver = racingDrivers.FirstOrDefault(d => d.Name == driversName);

        if (reasonToBox == "ChangeTyres")
        {
            List<string> tyrearguments = commandArgs.Skip(2).ToList();

            driver.Car.ChangeTyre(tyrearguments);
        }
        else if (reasonToBox == "Refuel")
        {
            double fuelAmount = double.Parse(commandArgs[2]);

            driver.Car.Refuel(fuelAmount);
        }
        driver.IncreaseBoxTime();
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        StringBuilder builder = new StringBuilder();

        int lapsCount = int.Parse(commandArgs[0]);

        if (lapsCount > this.totalLapsCount - this.currentLap)
        {
            return $"There is no time! On lap {this.currentLap}.";
        }
        else
        {
            for (int lap = 0; lap < lapsCount; lap++)
            {
                for (int index = 0; index < this.racingDrivers.Count; index++)
                {
                    Driver driver = this.racingDrivers[index];
                    try
                    {
                        driver.CompleteLap(this.trackLength);
                    }
                    catch (ArgumentException ex)
                    {
                        driver.Fail(ex.Message);
                        this.failedDrivers.Push(driver);
                        this.racingDrivers.RemoveAt(index);
                        index--;
                    }
                }

                this.currentLap++;

                List<Driver> orderedDrivers = this.racingDrivers.OrderByDescending(d => d.TotalTime).ToList();

                for (int i = 0; i < orderedDrivers.Count - 1; i++)
                {
                    Driver overtakingDriver = orderedDrivers[i];
                    Driver targetDriver = orderedDrivers[i + 1];

                    bool ovetookDriver = this.TryOvertake(overtakingDriver, targetDriver);

                    if (ovetookDriver)
                    {
                        i++;
                        builder.AppendLine($"{overtakingDriver.Name} has overtaken {targetDriver.Name} on lap {this.currentLap}.");
                    }
                    else
                    {
                        if (!overtakingDriver.IsRacing)
                        {
                            this.failedDrivers.Push(overtakingDriver);
                            this.racingDrivers.Remove(overtakingDriver);
                        }
                    }
                }
            }
        }

        if (this.raceOver)
        {
            Driver winner = this.racingDrivers.OrderBy(d => d.TotalTime).First();

            builder.AppendLine($"{winner.Name} wins the race for {winner.Status} seconds.");
        }

        return builder.ToString().TrimEnd();
    }

    private bool TryOvertake(Driver overtakingDriver, Driver targetDriver)
    {

        double diff = overtakingDriver.TotalTime - targetDriver.TotalTime;

        bool aggressiveDriver = overtakingDriver is AggressiveDriver && overtakingDriver.Car.Tyre is UltrasoftTyre;
        bool enduranceDriver = overtakingDriver is EnduranceDriver && overtakingDriver.Car.Tyre is HardTyre;

        bool crash = (aggressiveDriver && this.weather == "Foggy") || (enduranceDriver && this.weather == "Rainy");

        if ((aggressiveDriver || enduranceDriver) && diff <= 3)
        {
            if (crash)
            {
                overtakingDriver.Fail(CRASH_MESSAGE);
                return false;
            }

            overtakingDriver.TotalTime -= 3;
            targetDriver.TotalTime += 3;
            return true;
        }
        else if (diff <= 2)
        {
            overtakingDriver.TotalTime -= 2;
            targetDriver.TotalTime += 2;
            return true;
        }

        return false;
    }

    public string GetLeaderboard()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine($"Lap {this.currentLap}/{this.totalLapsCount}");

        int possition = 1;

        IEnumerable<Driver> orderedDrivers =
             this.racingDrivers
             .OrderBy(d => d.TotalTime)
             .Concat(this.failedDrivers);

        foreach (Driver driver in orderedDrivers)
        {
            builder.AppendLine($"{possition} {driver.Name} {driver.Status}");
            possition++;
        }

        return builder.ToString().TrimEnd();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        this.weather = commandArgs[0];
    }
}