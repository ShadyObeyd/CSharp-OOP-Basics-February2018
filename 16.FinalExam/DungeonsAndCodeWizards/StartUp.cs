using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Characters.Enums;
using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Linq;

namespace DungeonsAndCodeWizards
{
	public class StartUp
	{
		// DO NOT rename this file's namespace or class name.
		// However, you ARE allowed to use your own namespaces (or no namespaces at all if you prefer) in other classes.
		public static void Main()
		{
            DungeonMaster master = new DungeonMaster();

            string command = Console.ReadLine();

            while (true)
            {
                if (string.IsNullOrEmpty(command))
                {
                    Console.WriteLine($"Final stats:");
                    Console.WriteLine(master.GetStats());
                    break;
                }

                string[] commandTokens = command.Split(' ');

                string[] methodArgs = commandTokens.Skip(1).ToArray();

                try
                {
                    switch (commandTokens[0])
                    {
                        case "JoinParty":
                            Console.WriteLine(master.JoinParty(methodArgs));
                            break;
                        case "AddItemToPool":
                            Console.WriteLine(master.AddItemToPool(methodArgs));
                            break;
                        case "PickUpItem":
                            Console.WriteLine(master.PickUpItem(methodArgs));
                            break;
                        case "UseItem":
                            Console.WriteLine(master.UseItem(methodArgs));
                            break;
                        case "UseItemOn":
                            Console.WriteLine(master.UseItemOn(methodArgs));
                            break;
                        case "GiveCharacterItem":
                            Console.WriteLine(master.GiveCharacterItem(methodArgs));
                            break;
                        case "GetStats":
                            Console.WriteLine(master.GetStats());
                            break;
                        case "Attack":
                            Console.WriteLine(master.Attack(methodArgs));
                            break;
                        case "Heal":
                            Console.WriteLine(master.Heal(methodArgs));
                            break;
                        case "EndTurn":
                            Console.WriteLine(master.EndTurn(methodArgs));
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Parameter Error: " + ex.Message);
                }
                catch(InvalidOperationException ex)
                {
                    Console.WriteLine("Invalid Operation: " + ex.Message);
                }

                if (master.IsGameOver())
                {
                    Console.WriteLine("Final stats:");
                    Console.WriteLine(master.GetStats());
                    break;
                }

                command = Console.ReadLine();
            }
		}
	}
}