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
            string[] wimMessage = { "{0}'s axe hit {1} square in the face, cracking their skull, {1} fell to the ground, dead.", "After that axe hit {1}'s face, no mother could ever love them, since they were missing half a face." };
            return wimMessage[ram.Next(0, wimMessage.Length)];
        }

        public string getRandomAttackLoseMessage(Random ram)
        {
            string[] loseMessage = { "{0}'s axe just missed {1}'s face.", "{0} tripped and fell on their face while trying to axe {1} in the head." };
            return loseMessage[ram.Next(0, loseMessage.Length)];
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
            string[] gainMessage = { "{0} found a hammer hidden in a nearby tree!", "{0} looked under a rock and found a brand new hammer!", "A hammer fell from the sky and landed right next to {0}!" };
            return gainMessage[ram.Next(0, gainMessage.Length)];
        }

        public string getRandomAttackMessage(Random ram)
        {
            string[] attackMessage = { "From out of nowhere, {0} swung their hammer at {1}'s head!", "Jumping from behind a bush, {0} threw threw their hammer at {1}!" };
            return attackMessage[ram.Next(0, attackMessage.Length)];
        }

        public string getRandomAttackWinMessage(Random ram)
        {
            string[] wimMessage = { "{0}'s hammer hit {1} square in the face, cracking their skull, {1} fell to the ground, instantly dead.", "{1}'s face was so flat after {0}'s repeated hammering that you could use it as a plate!" };
            return wimMessage[ram.Next(0, wimMessage.Length)];
        }

        public string getRandomAttackLoseMessage(Random ram)
        {
            string[] loseMessage = { "{0}'s hammer just missed {1}'s face.", "{0} tripped and fell on their face while trying to hit {1} in the head with a hammer." };
            return loseMessage[ram.Next(0, loseMessage.Length)];
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
            string[] gainMessage = { "{0} broke a stick off of a nearby tree!", "{0} attacked a tree to gain one stick!" };
            return gainMessage[ram.Next(0, gainMessage.Length)];
        }

        public string getRandomAttackMessage(Random ram)
        {
            string[] attackMessage = { "From out of nowhere, {0} attempted to stab {1} with a stick!", "A stick launched by {0} went flying towards {1}!" };
            return attackMessage[ram.Next(0, attackMessage.Length)];
        }

        public string getRandomAttackWinMessage(Random ram)
        {
            string[] wimMessage = { "A look of shock and pain directed towards {0} as {1} sank to the ground, gave their last breath, and died.", "Suddenly there was now a stick pierceing {1}'s brain. They died." };
            return wimMessage[ram.Next(0, wimMessage.Length)];
        }

        public string getRandomAttackLoseMessage(Random ram)
        {
            string[] loseMessage = { "The stick missed {1} and hit the tree next to them.", "{0} tripped and fell on their face while trying to stab {1} with a stick." };
            return loseMessage[ram.Next(0, loseMessage.Length)];
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
            string[] gainMessage = { "A parachute from a sponsor landed next to {0}, it contained a flint and steel!", "{0} found a box on the ground. It contained a flint and steel set!" };
            return gainMessage[ram.Next(0, gainMessage.Length)];
        }

        public string getRandomAttackMessage(Random ram)
        {
            string[] attackMessage = { "{0} attempted to set {1} on fire with their flint and steel!", "{1} steped on a trap laid by {0} designed to light them on fire." };
            return attackMessage[ram.Next(0, attackMessage.Length)];
        }

        public string getRandomAttackWinMessage(Random ram)
        {
            string[] wimMessage = { "Where {1} once stood there was now a charred corpse.", "{1} looked like the got shot out of a cannon. Better ready one ourselves." };
            return wimMessage[ram.Next(0, wimMessage.Length)];
        }

        public string getRandomAttackLoseMessage(Random ram)
        {
            string[] loseMessage = { "Repeated sparks didn't catch {1} on fire. Guess they had better clothes than {0} expected.", "{0}'s attempt to set {1} on fire was foiled by the fact there was water nearby." };
            return loseMessage[ram.Next(0, loseMessage.Length)];
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
            return 1296;
        }

        public int getWeaponMod()
        {
            return 1261;
        }

        public string getRandomItemGainMessage(Random ram)
        {
            string[] gainMessage = { "{0} broke a wooden stick off of a nearby tree!", "{0} attacked a tree to gain one wooden stick!" };
            return gainMessage[ram.Next(0, gainMessage.Length)];
        }

        public string getRandomAttackMessage(Random ram)
        {
            string[] attackMessage = { "From out of nowhere, {0} attempted to stab {1} with a wooden stick!", "A wooden stick launched by {0} went flying towards {1}!" };
            return attackMessage[ram.Next(0, attackMessage.Length)];
        }

        public string getRandomAttackWinMessage(Random ram)
        {
            string[] wimMessage = { "A look of shock and pain directed towards {0} as {1} sank to the ground, gave their last breath, and died.", "Suddenly there was now a wooden stick pierceing {1}'s brain. They died." };
            return wimMessage[ram.Next(0, wimMessage.Length)];
        }

        public string getRandomAttackLoseMessage(Random ram)
        {
            string[] loseMessage = { "The wooden stick missed {1} and hit the tree next to them.", "{0} tripped and fell on their face while trying to stab {1} with a wooden stick." };
            return loseMessage[ram.Next(0, loseMessage.Length)];
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
            string[] gainMessage = { "{0} received a gift from a sponsor. It was a bow and some arrows!", "{0} found a bow and some arrows in a random box on the ground." };
            return gainMessage[ram.Next(0, gainMessage.Length)];
        }

        public string getRandomAttackMessage(Random ram)
        {
            string[] attackMessage = { "While hiding in a bush, {0} let an arrow fly at {1}", "{0} and {1} stood, looking at each other across a open space. {0} shot an arrow first." };
            return attackMessage[ram.Next(0, attackMessage.Length)];
        }

        public string getRandomAttackWinMessage(Random ram)
        {
            string[] wimMessage = { "A look of shock and pain directed towards {0} as {1} sank to the ground, gave their last breath, and died.", "Suddenly there was now an arrow pierceing {1}'s brain. They died." };
            return wimMessage[ram.Next(0, wimMessage.Length)];
        }

        public string getRandomAttackLoseMessage(Random ram)
        {
            string[] loseMessage = { "The arrow missed {1} and hit the tree next to them.", "{0} misfired and the arrow dropped to the ground right in front of them." };
            return loseMessage[ram.Next(0, loseMessage.Length)];
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
            string[] gainMessage = { "{0} received a gift from a sponsor. It was a power drill!", "{0} found a power drill in a random box on the ground. How they plan to power it, I have no idea. Oh wait, {0} found a battery as well" };
            return gainMessage[ram.Next(0, gainMessage.Length)];
        }

        public string getRandomAttackMessage(Random ram)
        {
            string[] attackMessage = { "{0} charged at {1} with their power drill, attempting to drill {1} to death.", "{0} and {1} stood, looking at each other across a open space. {0} charged at {1} with their power drill." };
            return attackMessage[ram.Next(0, attackMessage.Length)];
        }

        public string getRandomAttackWinMessage(Random ram)
        {
            string[] wimMessage = { "A look of shock and pain directed towards {0} as {1} sank to the ground, gave their last breath, and died with a new hole in their body.", "{0} could feel the power drill pierceing {1}'s brain. {1} died." };
            return wimMessage[ram.Next(0, wimMessage.Length)];
        }

        public string getRandomAttackLoseMessage(Random ram)
        {
            string[] loseMessage = { "The arrow missed {1} and hit the tree next to them.", "{0} misfired and the arrow dropped to the ground right in front of them." };
            return loseMessage[ram.Next(0, loseMessage.Length)];
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
            string[] gainMessage = { "{0} received a gift from a sponsor. It was a laser saw!", "{0} found a laser saw in a random box on the ground. How {0} plans to power it, I have no idea. Oh wait, {0} found a battery as well" };
            return gainMessage[ram.Next(0, gainMessage.Length)];
        }

        public string getRandomAttackMessage(Random ram)
        {
            string[] attackMessage = { "{0} charged at {1} with their laser saw, attempting to stab {1}.", "{0} and {1} stood, looking at each other across a open space. {0} charged at {1} with their laser saw." };
            return attackMessage[ram.Next(0, attackMessage.Length)];
        }

        public string getRandomAttackWinMessage(Random ram)
        {
            string[] wimMessage = { "A look of shock and pain directed towards {0} as {1} sank to the ground, gave their last breath, and died with a new hole in their body.", "{0} could feel the laser saw cut through {1}'s brain. {1} died." };
            return wimMessage[ram.Next(0, wimMessage.Length)];
        }

        public string getRandomAttackLoseMessage(Random ram)
        {
            string[] loseMessage = { "The saw malfunctioned and wouldn't turn on right at the dramatic moment. {1} runs away.", "{0} somehow managed to miss and hit the tree next to {1}, jamming the saw long enough for {1} to run away." };
            return loseMessage[ram.Next(0, loseMessage.Length)];
        }
    }
}
