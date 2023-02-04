using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingFinal
{
    public static class Fight
    {
        public static void HeroTurn(Hero hero,Monster monster)
        {
            var health = monster.CurrentHealth == null ? monster.OriginalHealth : monster.CurrentHealth;
            var result = health - (hero.BaseStrength + hero.EquippedWeapon.Power-monster.Defence);
            Console.WriteLine($"Monster health: {health} - (hero baseStrength: {hero.BaseStrength} + hero weapon: {hero.EquippedWeapon.Power} - monster defence: {monster.Defence})");
            monster.CurrentHealth = result <= 0 ? 0 : result;
           

        }
        public static void MonsterTurn(Hero hero, Monster monster)
        {
            var health = hero.CurrentHealth == null ? hero.OriginalHealth : hero.CurrentHealth;
            var result= health - (monster.Strength - (hero.BaseDefence + hero.EquippedArmor.Power));
            Console.WriteLine($"hero health: {health} - (monster strength: {monster.Strength} - (hero BaseDefence: {hero.BaseDefence} + hero armor: {hero.EquippedArmor.Power}))");
            hero.CurrentHealth = result <= 0 ? 0 : result;
        }

        public static bool? CheckWin(Hero hero,Monster monster)
        {
            
            if (monster.CurrentHealth == 0)
            {
                return true;
            }
            if (hero.CurrentHealth == 0)
            {
                hero.CurrentHealth = hero.OriginalHealth;
                return false;
            }
            return null;
        }
    }
}
