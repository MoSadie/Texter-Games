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
        public static List<Item> items = new List<Item>() { new Fists(), new Axe(), new Hammer() };

        public static Item getRandomItem()
        {
            return items[new Random().Next(1, items.Count())];
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
            return 5;
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
}
