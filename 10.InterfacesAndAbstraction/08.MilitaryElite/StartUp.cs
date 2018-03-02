using System;
using System.Collections.Generic;

class StartUp
{
    static void Main()
    {
        string input = Console.ReadLine();

        List<Soldier> army = new List<Soldier>();

        while (input != "End")
        {
            string[] soldierTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            switch (soldierTokens[0])
            {
                case "Private":
                    Private privatee = new Private(soldierTokens[1], soldierTokens[2], soldierTokens[3], double.Parse(soldierTokens[4]));
                    army.Add(privatee);
                    break;
                case "LeutenantGeneral":
                    LeutenantGeneral officer = new LeutenantGeneral(soldierTokens[1], soldierTokens[2], soldierTokens[3], double.Parse(soldierTokens[4]));

                    if (soldierTokens.Length > 5)
                    {
                        for (int i = 5; i < soldierTokens.Length; i++)
                        {
                            string privateId = soldierTokens[i];

                            foreach (Soldier soldier in army)
                            {
                                if (soldier.Id == privateId)
                                {
                                    officer.Privates.Add(soldier);
                                    break;
                                }
                            }
                        }
                    }
                    army.Add(officer);
                    break;
                case "Engineer":
                    if (!CorpsIsValid(soldierTokens[5]))
                    {
                        continue;
                    }
                    Engineer engineer = new Engineer(soldierTokens[1], soldierTokens[2], soldierTokens[3], double.Parse(soldierTokens[4]), soldierTokens[5]);

                    if (soldierTokens.Length > 6)
                    {
                        for (int i = 6; i < soldierTokens.Length; i+= 2)
                        {
                            string partName = soldierTokens[i];
                            int hoursWorked = int.Parse(soldierTokens[i + 1]);

                            Repair repair = new Repair(partName, hoursWorked);

                            engineer.Repairs.Add(repair);
                        }
                    }
                    army.Add(engineer);
                    break;
                case "Commando":
                    if (!CorpsIsValid(soldierTokens[5]))
                    {
                        continue;
                    }
                    Commando commando = new Commando(soldierTokens[1], soldierTokens[2], soldierTokens[3], double.Parse(soldierTokens[4]), soldierTokens[5]);

                    if (soldierTokens.Length > 6)
                    {
                        for (int i = 6; i < soldierTokens.Length; i+= 2)
                        {
                            string codeName = soldierTokens[i];
                            string state = soldierTokens[i + 1];

                            if (state != "inProgress" && state != "Finished")
                            {
                                continue;
                            }
                            Mission mission = new Mission(codeName, state);
                            commando.Missions.Add(mission);
                        }
                    }
                    army.Add(commando);
                    break;
                case "Spy":
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

    private static bool CorpsIsValid(string corps)
    {
        if (corps == "Airforces" || corps == "Marines")
        {
            return true;
        }
        return false;
    }
}