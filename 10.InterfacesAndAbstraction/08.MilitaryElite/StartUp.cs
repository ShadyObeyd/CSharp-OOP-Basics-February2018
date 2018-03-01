using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        string input = Console.ReadLine();

        List<Soldier> army = new List<Soldier>();

        while (input != "End")
        {
            string[] soldierTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            switch (soldierTokens[0].ToLower())
            {
                case "private":
                    Private privatee = new Private(soldierTokens[1], soldierTokens[2], soldierTokens[3], double.Parse(soldierTokens[4]));
                    army.Add(privatee);
                    break;
                case "leutenantgeneral":
                    LeutenantGeneral officer = new LeutenantGeneral(soldierTokens[1], soldierTokens[2], soldierTokens[3], double.Parse(soldierTokens[4]));
                    string[] privateIds = soldierTokens.Skip(5).ToArray();

                    AddPrivates(army, officer, privateIds);
                    army.Add(officer);
                    break;
                case "engineer":
                    if (!CorpsIsValid(soldierTokens[5]))
                    {
                        continue;
                    }
                    Engineer engineer = new Engineer(soldierTokens[1], soldierTokens[2], soldierTokens[3], double.Parse(soldierTokens[4]), soldierTokens[5]);

                    string[] repairs = soldierTokens.Skip(6).ToArray();

                    GetRepairs(engineer, repairs);
                    army.Add(engineer);
                    break;
                case "commando":
                    if (!CorpsIsValid(soldierTokens[5]))
                    {
                        continue;
                    }

                    Commando commando = new Commando(soldierTokens[1], soldierTokens[2], soldierTokens[3], double.Parse(soldierTokens[4]), soldierTokens[5]);

                    string[] missions = soldierTokens.Skip(6).ToArray();

                    GetMissions(commando, missions);
                    army.Add(commando);
                    break;
                case "spy":
                    Spy spy = new Spy(soldierTokens[1], soldierTokens[2], soldierTokens[3], int.Parse(soldierTokens[4]));
                    army.Add(spy);
                    break;
            }
            input = Console.ReadLine();
        }

        foreach (Soldier soldier in army)
        {
            Console.WriteLine(soldier);
        }
    }

    private static void GetMissions(Commando commando, string[] missions)
    {
        for (int i = 0; i < missions.Length; i+= 2)
        {
            string codeName = missions[i];
            string state = missions[i + 1];

            if (state != "inProgress" && state != "Finished")
            {
                continue;
            }

            Mission mission = new Mission(codeName, state);

            commando.Missions.Add(mission);
        }
    }

    private static void GetRepairs(Engineer engineer, string[] repairs)
    {
        if (repairs.Any())
        {
            for (int i = 0; i < repairs.Length; i+= 2)
            {
                string partName = repairs[i];
                int hoursWorked = int.Parse(repairs[i + 1]);

                Repair repair = new Repair(partName, hoursWorked);

                engineer.Repairs.Add(repair);
            }
        }
    }

    private static bool CorpsIsValid(string corps)
    {
        if (corps == "Airforces" || corps == "Marines")
        {
            return true;
        }
        return false;
    }

    private static void AddPrivates(List<Soldier> army, LeutenantGeneral officer, string[] privateIds)
    {
        foreach (string id in privateIds)
        {
            foreach (Soldier soldier in army)
            {
                if (soldier is Private)
                {
                    if (soldier.Id == id)
                    {
                        officer.Privates.Add((Private)soldier);
                    }
                }
            }
        }
    }
}