using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{
    public class Potato
    {
        static void Main()
        {
            long bagLimit = long.Parse(Console.ReadLine());
            string[] valuableTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();

            long gold = 0;
            long gems = 0;
            long money = 0;

            for (int i = 0; i < valuableTokens.Length; i += 2)
            {
                string valuable = valuableTokens[i];
                long amount = long.Parse(valuableTokens[i + 1]);

                string valuableType = string.Empty;

                if (valuable.Length == 3)
                {
                    valuableType = "Cash";
                }
                else if (valuable.ToLower().EndsWith("gem"))
                {
                    valuableType = "Gem";
                }
                else if (valuable.ToLower() == "gold")
                {
                    valuableType = "Gold";
                }

                bool reachedBagSize = bagLimit < bag.Values.Select(x => x.Values.Sum()).Sum() + amount;

                if (valuableType == string.Empty || reachedBagSize)
                {
                    continue;
                }

                switch (valuableType)
                {
                    case "Gem":
                        if (!bag.ContainsKey(valuableType))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (amount > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (IsBagLarger("Gold", bag, valuableType, amount))
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!bag.ContainsKey(valuableType))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (amount > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (IsBagLarger("Gem", bag, valuableType, amount))
                        {
                            continue;
                        }
                        break;
                }

                if (!bag.ContainsKey(valuableType))
                {
                    bag[valuableType] = new Dictionary<string, long>();
                }

                if (!bag[valuableType].ContainsKey(valuable))
                {
                    bag[valuableType][valuable] = 0;
                }

                bag[valuableType][valuable] += amount;

                if (valuableType == "Gold")
                {
                    gold = AddQuantity(gold, amount);
                }
                else if (valuableType == "Gem")
                {
                    gems = AddQuantity(gems, amount);
                }
                else if (valuableType == "Cash")
                {
                    money = AddQuantity(money, amount);
                }
            }

            foreach (var x in bag)
            {
                Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
                foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }

        private static bool IsBagLarger(string valuable, Dictionary<string, Dictionary<string, long>> bag, string valuableType, long amount)
        {
            return bag[valuableType].Values.Sum() + amount > bag[valuable].Values.Sum();
        }

        static long AddQuantity(long valuable, long quantity)
        {
            return valuable += quantity;
        }
    }
}