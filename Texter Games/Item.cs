using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Texter_Games;

namespace Texter_Games
{

    static class ItemManager
    {
        public static List<Item> items = new List<Item>() { new Fists(), new Axe(), new Hammer(), new Stick(), new FlintAndSteel(), new WoodenStick(), new BowAndArrow(), new PowerDrill(), new LaserSaw()};

        public static Item getRandomItem(Contestant contestant)
        {
            Item tmpItem;
            do
            {
                tmpItem = items[new Random(contestant.ram.Next()).Next(1, items.Count())];
                if (tmpItem.Equals(new WoodenStick()))
                {
                    if (new Random(contestant.ram.Next()).Next(1, 1000001) == 1) return tmpItem;
                    else continue;
                }
                else
                    return tmpItem;
            } while (tmpItem.Equals(new WoodenStick()));
            return new Axe();
        }
    }

    interface Item
    {
        int getWeaponMod();
        int getSurvivalMod();
        string getName();
    }

    class Fists : Item
    {
        public string getName()
        {
            return "Fists";
        }

        public int getSurvivalMod()
        {
            return 0;
        }

        public int getWeaponMod()
        {
            return 0;
        }
    }

    class Axe : Item
    {
        public string getName()
        {
            return "Axe";
        }

        public int getSurvivalMod()
        {
            return 10;
        }

        public int getWeaponMod()
        {
            return 15;
        }
    }

    class Hammer : Item
    {
        public string getName()
        {
            return "Hammer";
        }

        public int getSurvivalMod()
        {
            return 15;
        }

        public int getWeaponMod()
        {
            return 8;
        }
    }

    class Stick : Item
    {
        public string getName()
        {
            return "Stick";
        }

        public int getSurvivalMod()
        {
            return 25;
        }

        public int getWeaponMod()
        {
            return 7;
        }
    }

    class FlintAndSteel : Item
    {
        public string getName()
        {
            return "Flint and Steel";
        }

        public int getSurvivalMod()
        {
            return 50;
        }

        public int getWeaponMod()
        {
            return 9;
        }
    }

    class WoodenStick : Item
    {
        public string getName()
        {
            return "Wooden Stick";
        }

        public int getSurvivalMod()
        {
            return 1000;
        }

        public int getWeaponMod()
        {
            return 1000;
        }
    }

    class BowAndArrow : Item
    {
        public string getName()
        {
            return "Bow and Arrow";
        }

        public int getSurvivalMod()
        {
            return 20;
        }

        public int getWeaponMod()
        {
            return 30;
        }
    }

    class PowerDrill : Item
    {
        public string getName()
        {
            return "Power Drill";
        }

        public int getSurvivalMod()
        {
            return 7;
        }

        public int getWeaponMod()
        {
            return 17;
        }
    }

    class LaserSaw : Item
    {
        public string getName()
        {
            return "Laser Saw";
        }

        public int getSurvivalMod()
        {
            return 9;
        }

        public int getWeaponMod()
        {
            return 21;
        }
    }
}
