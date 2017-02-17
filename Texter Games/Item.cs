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
        string getRandomItemGainMessage(Random ram);
        string getRandomAttackMessage(Random ram);
        string getRandomAttackWinMessage(Random ram);
        string getRandomAttackLoseMessage(Random ram);
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

        public string getRandomItemGainMessage(Random ram)
        {
            string[] gainMessage = { "{0} somehow chopped off then reattached their own fists!", "{0} found some fists just sitting on the ground... Why would {0} use them!" };
            return gainMessage[ram.Next(0, gainMessage.Length)];
        }

        public string getRandomAttackMessage(Random ram)
        {
            string[] attackMessage = { "From out of nowhere, {0} threw a punch at {1}!", "Jumping from behind a bush, {0} threw a punch at {1}!" };
            return attackMessage[ram.Next(0, attackMessage.Length)];
        }

        public string getRandomAttackWinMessage(Random ram)
        {
            string[] wimMessage = { "{0}'s punch hit {1} square in the face, knocking them to the ground, dead.", "After that punch from {0}, {1}'s face became a deformed mess. Fire a cannon." };
            return wimMessage[ram.Next(0, wimMessage.Length)];
        }

        public string getRandomAttackLoseMessage(Random ram)
        {
            string[] loseMessage = { "{0}'s punch just missed {1}'s face.", "{0} tripped and fell on their face while trying to punch {1}." };
            return loseMessage[ram.Next(0, loseMessage.Length)];
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
        
        public string getRandomItemGainMessage(Random ram)
        {
            string[] gainMessage = { "{0} found a axe embedded in a nearby tree!", "{0} looked under a rock and found a brand new axe!" };
            return gainMessage[ram.Next(0, gainMessage.Length)];
        }

        public string getRandomAttackMessage(Random ram)
        {
            string[] attackMessage = { "From out of nowhere, {0} swung their axe at {1}'s head!", "Jumping from behind a bush, {0} threw threw their axe at {1}!" };
            return attackMessage[ram.Next(0, attackMessage.Length)];
        }

        public string getRandomAttackWinMessage(Random ram)
        {
            string[] wimMessage = { "{0}'s axe hit {1} square in the face, cracking their skull, {1} fell to the ground, dead.", "After that axe hit {1}'s face, no mother would ever love them, since they were missing half a face." };
            return wimMessage[ram.Next(0, wimMessage.Length)];
        }

        public string getRandomAttackLoseMessage(Random ram)
        {
            return null;
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
        
        public string getRandomItemGainMessage(Random ram)
        {
            return null;
        }

        public string getRandomAttackMessage(Random ram)
        {
            return null;
        }

        public string getRandomAttackWinMessage(Random ram)
        {
            return null;
        }

        public string getRandomAttackLoseMessage(Random ram)
        {
            return null;
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

        public string getRandomItemGainMessage(Random ram)
        {
            return null;
        }

        public string getRandomAttackMessage(Random ram)
        {
            return null;
        }

        public string getRandomAttackWinMessage(Random ram)
        {
            return null;
        }

        public string getRandomAttackLoseMessage(Random ram)
        {
            return null;
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
        
        public string getRandomItemGainMessage(Random ram)
        {
            return null;
        }

        public string getRandomAttackMessage(Random ram)
        {
            return null;
        }

        public string getRandomAttackWinMessage(Random ram)
        {
            return null;
        }

        public string getRandomAttackLoseMessage(Random ram)
        {
            return null;
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
        
        public string getRandomItemGainMessage(Random ram)
        {
            return null;
        }

        public string getRandomAttackMessage(Random ram)
        {
            return null;
        }

        public string getRandomAttackWinMessage(Random ram)
        {
            return null;
        }

        public string getRandomAttackLoseMessage(Random ram)
        {
            return null;
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
        
        public string getRandomItemGainMessage(Random ram)
        {
            return null;
        }

        public string getRandomAttackMessage(Random ram)
        {
            return null;
        }

        public string getRandomAttackWinMessage(Random ram)
        {
            return null;
        }

        public string getRandomAttackLoseMessage(Random ram)
        {
            return null;
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

        public string getRandomItemGainMessage(Random ram)
        {
            return null;
        }

        public string getRandomAttackMessage(Random ram)
        {
            return null;
        }

        public string getRandomAttackWinMessage(Random ram)
        {
            return null;
        }

        public string getRandomAttackLoseMessage(Random ram)
        {
            return null;
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
        
        public string getRandomItemGainMessage(Random ram)
        {
            return null;
        }

        public string getRandomAttackMessage(Random ram)
        {
            return null;
        }

        public string getRandomAttackWinMessage(Random ram)
        {
            return null;
        }

        public string getRandomAttackLoseMessage(Random ram)
        {
            return null;
        }
    }
}
