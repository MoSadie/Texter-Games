﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texter_Games
{
    struct Contestant
    {
        public Random ram;
        public string name;
        public int health;
        public int sanity;
        public int survivalSkill;
        public int weaponSkill;
        public bool wounded;
        public List<Item> Inventory;

        public Contestant(string name, int seedMod)
        {
            ram = new Random(DateTime.Now.Second+ DateTime.Now.Minute + DateTime.Now.Hour + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + seedMod);
            this.name = name;
            health = 100;
            sanity = 100;
            survivalSkill = ram.Next(1, 101);
            weaponSkill = ram.Next(1, 101);
            wounded = false;
            Inventory = new List<Item>() { ItemManager.items[0] };
        }

        public void modSanity(int amount)
        {
            sanity += amount;
        }

        public void modWeapon(int amount)
        {
            weaponSkill += amount;
        }

        public void modSurvival(int amount)
        {
            survivalSkill += amount;
        }

        public override string ToString()
        {
            string TmpInv = "";
            if (Inventory.Count > 0) {
                foreach (Item item in Inventory)
                {
                    TmpInv = item.getName() + " " + TmpInv;
                }
            } else
            {
                TmpInv = "Empty";
            }
            return string.Format("Name: {0} | Health: {1} | Sanity: {2} | Surival Skill: {3} | Weapon Skill {4} | Wounded: {5} | Inventory: {6}", name, health, sanity, survivalSkill, weaponSkill, wounded, TmpInv);
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            if (args.Length <= 0) {
                Console.WriteLine("Hey! You need to provide argunments of the contestants!");
                return;
            }
            Console.Clear();
            Console.WriteLine("The contestants are...");
            List<Contestant> contestants = new List<Contestant>();
            foreach (string arg in args)
            {
                Contestant newGuy = new Contestant(arg, contestants.Count);
                contestants.Add(newGuy);
                Console.WriteLine("- " + newGuy.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("Press Enter when ready.");
            Console.ReadLine();
            Console.Clear();
            List<Contestant> living = contestants;
            List<Contestant> dead = new List<Contestant>();
            int day = 0;
            while (living.Count() > 1)
            {
                day++;
                Console.WriteLine("Day " + day);
                Console.WriteLine();
                living = living.OrderBy(a => Guid.NewGuid()).ToList();
                for (int i = 0; i < living.Count; i++)
                {
                    Contestant contestant = living[i];
                    contestant.modSanity(contestant.ram.Next(-15,0));
                    int action = contestant.ram.Next(1, 5);
                    switch (action)
                    {
                        case 1: //Does "nothing"
                            Messages.printNothingMessage(contestant);
                            break;
                        case 2: //Does "attack"
                            Contestant target;
                            if (living.Count == 1)
                            {
                                Messages.printNothingMessage(contestant);
                                break;
                            }
                            do
                            {
                                target = living[contestant.ram.Next(0, living.Count)];
                            } while (target.Equals(contestant));
                            int attack = contestant.weaponSkill;
                            if (contestant.wounded) attack = attack - contestant.ram.Next(0, contestant.weaponSkill);
                            if (contestant.Inventory.Count > 0)
                            {
                                foreach (Item attackItem in contestant.Inventory)
                                {
                                    attack += attackItem.getWeaponMod();
                                }
                            }

                            int defense = (int)((target.weaponSkill * 0.5) + (target.survivalSkill * 0.25));
                            if (target.Inventory.Count > 0)
                            {
                                foreach (Item defenseItem in target.Inventory)
                                {
                                    defense += defenseItem.getWeaponMod();
                                }
                            }

                            if (attack > defense)
                            {
                                dead.Add(target);
                                living.Remove(target);
                                contestant.modSanity(contestant.ram.Next(-10, 10));
                                Messages.printAttackMessage(contestant, target, contestant.Inventory[contestant.ram.Next(contestant.Inventory.Count)], true);
                            } else
                            {
                                target.modSurvival(target.ram.Next(0, 6));
                                target.modWeapon(target.ram.Next(0, 6));
                                target.modSanity(-5);
                                contestant.modSurvival(contestant.ram.Next(0, 6));
                                contestant.modWeapon(contestant.ram.Next(0, 6));
                                contestant.modSanity(-1);
                                Messages.printAttackMessage(contestant, target, contestant.Inventory[contestant.ram.Next(contestant.Inventory.Count)], false);
                            }
                            break;
                        case 3: //Do "Gain Item"
                            Item item = ItemManager.getRandomItem(contestant);
                            contestant.Inventory.Add(item);
                            Messages.printGainItemMessage(contestant, item);
                            break;
                        case 4: //Do "Die"
                            if (living.Count == 1 || (day < 3 && contestant.ram.Next(1, 51) <= contestant.sanity / 2))
                            {
                                int actionTake2 = contestant.ram.Next(1, 4);
                                switch (actionTake2)
                                {
                                    case 1: //Does "nothing"
                                        Messages.printNothingMessage(contestant);
                                        break;
                                    case 2: //Does "attack"
                                        Contestant targetTake2;
                                        if (living.Count == 1)
                                        {
                                            Messages.printNothingMessage(contestant);
                                            break;
                                        }
                                        do
                                        {
                                            targetTake2 = living[contestant.ram.Next(0, living.Count)];
                                        } while (targetTake2.Equals(contestant));
                                        int attackTake2 = contestant.weaponSkill;
                                        if (contestant.wounded) attackTake2 = attackTake2 - contestant.ram.Next(0, contestant.weaponSkill);
                                        if (contestant.Inventory.Count > 0)
                                        {
                                            foreach (Item attackItem in contestant.Inventory)
                                            {
                                                attackTake2 += attackItem.getWeaponMod();
                                            }
                                        }

                                        int defenseTake2 = (int)((targetTake2.weaponSkill * 0.5) + (targetTake2.survivalSkill * 0.25));
                                        if (targetTake2.Inventory.Count > 0)
                                        {
                                            foreach (Item defenseItem in targetTake2.Inventory)
                                            {
                                                defenseTake2 += defenseItem.getWeaponMod();
                                            }
                                        }

                                        if (attackTake2 > defenseTake2)
                                        {
                                            dead.Add(targetTake2);
                                            living.Remove(targetTake2);
                                            contestant.modSanity(contestant.ram.Next(-10, 10));
                                            Messages.printAttackMessage(contestant, targetTake2, contestant.Inventory[contestant.ram.Next(contestant.Inventory.Count)], true);
                                        }
                                        else
                                        {
                                            targetTake2.modSurvival(targetTake2.ram.Next(0, 6));
                                            targetTake2.modWeapon(targetTake2.ram.Next(0, 6));
                                            targetTake2.modSanity(-5);
                                            contestant.modSurvival(contestant.ram.Next(0, 6));
                                            contestant.modWeapon(contestant.ram.Next(0, 6));
                                            contestant.modSanity(-1);
                                            Messages.printAttackMessage(contestant, targetTake2, contestant.Inventory[contestant.ram.Next(contestant.Inventory.Count)], false);
                                        }
                                        break;
                                    case 3: //Do "Gain Item"
                                        Item itemTake2 = ItemManager.getRandomItem(contestant);
                                        contestant.Inventory.Add(itemTake2);
                                        Messages.printGainItemMessage(contestant, itemTake2);
                                        break;
                                }
                                break;
                            }
                            else
                            {
                                dead.Add(contestant);
                                Console.Write("BANANA");
                                living.Remove(contestant);
                                Messages.printDeathMessage(contestant);
                                break;
                            }
                        default:
                            Messages.printNothingMessage(contestant);
                            break;
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Currently living:");
                foreach (Contestant contestant in living)
                {
                    Console.WriteLine(" - " + contestant.ToString());
                }
                Console.WriteLine();
                if (living.Count() > 1)
                {
                    Console.WriteLine("Press Enter to continue to the next day.");
                    Console.ReadLine();
                }
                Console.WriteLine();
            }

            if (living.Count == 1)
            {
                Console.WriteLine("A winner has been decided!");
                Console.WriteLine(string.Format("{0} is the winner!", living[0].name));
            }
        }
    }
}
