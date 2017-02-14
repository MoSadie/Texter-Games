using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texter_Games
{
    static class Messages
    {
        static string[] nothingMessages = { "{0} slept all day", "{0} decided to take a nap. All day.", "{0} thought about home.", "{0} thought about what is still to come." };
        static string[] attackMessage = { "{0} lunged from behind a bush at {1}, attacking them with a(n) {2}.", "While {1} was least excepting it, {0} attacked with a(n) {2}" };
        static string[] attackWinMessage = { "As {0} watched, {1} drew their last breath after {0} attacked them with a(n) {2}.", "{1} fell to the ground, a(n) {2}, delivered by {0}, between their eyes." };
        static string[] attackLoseMessage = { "{1} defended perfecly advoiding {0}'s deadly attack with a(n) {2}", "{0} tripped while trying to attack {1} with a(n) {2}. {1} just stood and laughed, then ran away." };
        static string[] deathMessage = { "{0} was done with the games and jumped of the nearest cliff and died.", "{0} ate some \"blueberries\" and died.", "Oops, guess that plant that {0} ate was actually poisonous. Better ready a cannon." };
        static string[] gainItemMessage = { "{0} went searching and found a(n) {1} nearby!", "{0} searched a nearby cave and found a(n) {1}!" };

        public static void printNothingMessage(Contestant contestant)
        {
            Random ram = new Random(DateTime.Now.Second + DateTime.Now.Minute + DateTime.Now.Hour + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + contestant.ram.Next());
            Console.WriteLine();
            Console.WriteLine(string.Format(nothingMessages[ram.Next(0,nothingMessages.Length)],contestant.name));
        }

        public static void printGainItemMessage(Contestant contestant, Item item)
        {
            Random ram = new Random(DateTime.Now.Second + DateTime.Now.Minute + DateTime.Now.Hour + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + contestant.ram.Next());
            Console.WriteLine();
            Console.WriteLine(string.Format(gainItemMessage[ram.Next(0, gainItemMessage.Length)], contestant.name, item.getName()));
        }


        public static void printDeathMessage(Contestant contestant)
        {
            Random ram = new Random(DateTime.Now.Second + DateTime.Now.Minute + DateTime.Now.Hour + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + contestant.ram.Next());
            Console.WriteLine();
            Console.WriteLine(string.Format(deathMessage[ram.Next(0, deathMessage.Length)], contestant.name));
        }

        public static void printAttackMessage(Contestant attacker, Contestant defender, Item weapon, bool success)
        {
            Random ram = new Random(DateTime.Now.Second + DateTime.Now.Minute + DateTime.Now.Hour + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + attacker.ram.Next() + defender.ram.Next() + weapon.getWeaponMod());
            Console.WriteLine();
            object[] args = { attacker.name, defender.name, weapon.getName() };
            Console.WriteLine(string.Format(attackMessage[ram.Next(0, attackMessage.Length)], args));
            if (success)
            {
                Console.WriteLine(string.Format(attackWinMessage[ram.Next(0, attackWinMessage.Length)], args));
            } else
            {
                Console.WriteLine(string.Format(attackLoseMessage[ram.Next(0, attackLoseMessage.Length)], args));
            }
        }
    }
}
