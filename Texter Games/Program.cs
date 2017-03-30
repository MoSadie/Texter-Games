using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texter_Games
{
    class Contestant
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
            survivalSkill = ram.Next(0, 101);
            weaponSkill = ram.Next(0, 101);
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

        public void kill()
        {
            health = 0;
        }

        public bool isDead()
        {
            return health <= 0;
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
            return string.Format("Name: {0} | Health: {1} | Sanity: {2} | Is Dead: {3} | Surival Skill: {4} | Weapon Skill {5} | Wounded: {6} | Inventory: {7}", name, health, sanity, isDead(), survivalSkill, weaponSkill, wounded, TmpInv);
        }
    }

    class Program
    {
        static List<Contestant> contestants = new List<Contestant>();
        static int day = 0;

        static void Main(string[] args)
        {
            if (args.Length <= 0) {
                Console.WriteLine("Hey! You need to provide argunments of the contestants!");
                Console.ReadKey();
                return;
            }
            Console.Clear();
            Console.WriteLine("The contestants are...");
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
            while (livingCount() > 1)
            {
                day++;
                Console.WriteLine("Day " + day);
                Console.WriteLine();
                contestants = contestants.OrderBy(a => Guid.NewGuid()).ToList();
                foreach (Contestant contestant in contestants)
                {
                    if (contestant.isDead()) continue;
                    contestant.modSanity(contestant.ram.Next(-15,0));
                    int action = contestant.ram.Next(1, 5);
                    switch (action)
                    {
                        case 1: //Does "nothing"
                            doNothing(contestant);
                            break;
                        case 2: //Does "attack"
                            doAttack(contestant);
                            break;
                        case 3: //Do "Gain Item"
                            doGainItem(contestant);
                            break;
                        case 4: //Do "Die"
                            doDie(contestant);
                            break;
                        default:
                            doNothing(contestant);
                            break;
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Currently living:");
                foreach (Contestant contestant in contestants)
                {
                    if (contestant.isDead()) continue;
                    Console.WriteLine(" - " + contestant.name);
                }
                Console.WriteLine();
                if (livingCount() > 1)
                {
                    Console.WriteLine("Press Enter to continue to the next day.");
                    Console.ReadLine();
                }
                Console.WriteLine();
            }

            if (livingCount() == 1)
            {
                Console.WriteLine("A winner has been decided!");
                foreach(Contestant contestant in contestants)
                {
                    if(!contestant.isDead())
                            Console.WriteLine(string.Format("{0} is the winner!", contestant.name));
                }
            }
        }

        private static void doNothing(Contestant contestant)
        {
            Messages.printNothingMessage(contestant);
        }

        private static void doAttack(Contestant contestant)
        {
            Contestant target;
            if (livingCount() == 1)
            {
                Messages.printNothingMessage(contestant);
                return;
            }
            do
            {
                target = contestants[contestant.ram.Next(livingCount())];
            } while (target.Equals(contestant) || target.isDead());
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
                target.kill();
                contestant.modSanity(contestant.ram.Next(-10, 10));
                Messages.printAttackMessage(contestant, target, contestant.Inventory[contestant.ram.Next(contestant.Inventory.Count)], true);
            }
            else
            {
                target.modSurvival(target.ram.Next(0, 6));
                target.modWeapon(target.ram.Next(0, 6));
                target.modSanity(-5);
                contestant.modSurvival(contestant.ram.Next(0, 6));
                contestant.modWeapon(contestant.ram.Next(0, 6));
                contestant.modSanity(-1);
                Messages.printAttackMessage(contestant, target, contestant.Inventory[contestant.ram.Next(contestant.Inventory.Count)], false);
            }
        }

        private static void doGainItem(Contestant contestant)
        {
            Item item = ItemManager.getRandomItem(contestant);
            contestant.Inventory.Add(item);
            Messages.printGainItemMessage(contestant, item);
        }

        private static void doDie(Contestant contestant)
        {
            if (livingCount() == 1 || (day < 3 && contestant.ram.Next(1, 51) <= contestant.sanity / 2))
            {
                int action = contestant.ram.Next(1, 4);
                switch (action)
                {
                    case 1: //Does "nothing"
                        doNothing(contestant);
                        break;
                    case 2: //Does "attack"
                        doAttack(contestant);
                        break;
                    case 3: //Do "Gain Item"
                        doGainItem(contestant);
                        break;
                }
            }
            else
            {
                contestant.kill();
                Messages.printDeathMessage(contestant);
            }
        }

        private static int livingCount()
        {
            int count = 0;
            foreach (Contestant contestant in contestants)
            {
                if (!contestant.isDead()) count++;
            }
            return count;
        }
    }
}
