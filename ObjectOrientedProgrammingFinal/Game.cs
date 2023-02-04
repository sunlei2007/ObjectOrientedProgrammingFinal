using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingFinal
{
    public class Game
    {
        private HashSet<Monster> monsters= new HashSet<Monster>();
        private HashSet<Weapon> weapons = new HashSet<Weapon>();
        private HashSet<Armor> armors   = new HashSet<Armor>();
        private int gameCounter;
        private int winCounter;
        private int loseCounter;
        public void CreateMonster()
        {
            monsters.Add(new Monster(100, "Wolf",5,5,110));
            monsters.Add(new Monster(101, "Tiger", 10, 10, 130));
            monsters.Add(new Monster(102, "Lion", 20, 20, 180));
        }
        public void CreateWeapon()
        {
            weapons.Add(new Weapon(200, "IronSword", 2));
            weapons.Add(new Weapon(201, "SilverSword", 4));
            weapons.Add(new Weapon(202, "GoldenSword", 15));
        }
        public void CreateArmors()
        {
            armors.Add(new Armor(300, "IronArmor", 2));
            armors.Add(new Armor(301, "SilverArmor", 4));
            armors.Add(new Armor(302, "GoldenArmor", 8));
        }
        public void Start()
        {
            while (true)
            {
             
                Console.WriteLine("Welcome to League of Legends");
                Console.WriteLine("Please enter your name");
                string userName = Console.ReadLine();
                Hero hero = new Hero(400, userName, 10, 10, 120);
                CreateMonster();
                CreateWeapon();
                CreateArmors();
                while (true)
                {
                    label1:
                    Console.WriteLine("PLease choose follow!");
                    Console.WriteLine("1. Statistics");
                    Console.WriteLine("2. Inventory");
                    Console.WriteLine("3. Fight");
                    Console.WriteLine("Please enter menu number!");
                    
                    switch(Console.ReadLine())
                    {
                        case "1":
                            Console.WriteLine($"Number games played: {gameCounter} Number of won: {winCounter} Number of lost: {loseCounter}");
                            break;
                        case "2":
                            while (true)
                            {
                                    label2:
                                    Console.WriteLine("PLease choose weapon!");
                                    for(int i=0;i<weapons.Count;i++)
                                    {
                                        Console.WriteLine($"{(i+1)}. {weapons.ToArray<Weapon>()[i].Name}");
                                    }
                                    Console.WriteLine($"{weapons.Count + 1}. Main menu");
                                    string chooseWeapon = Console.ReadLine();
                                    int chooseWeaponInt;
                                    if (int.TryParse(chooseWeapon,out chooseWeaponInt))
                                    {
                                        if(chooseWeaponInt<= weapons.Count+1 && chooseWeaponInt > 0)
                                        {
                                            if(chooseWeaponInt <= weapons.Count)
                                                hero.EquippedWeapon = weapons.ToArray<Weapon>()[chooseWeaponInt-1];
                                            if (chooseWeaponInt == weapons.Count + 1)
                                                goto label1;
                                        }  
                                        else
                                        {
                                            goto label2;
                                        } 
                                     }
                                    else
                                    {
                                        goto label2;
                                    }

                                    label3:
                                    Console.WriteLine("PLease choose armour!");
                                    for (int i = 0; i < armors.Count; i++)
                                    {
                                        Console.WriteLine($"{(i + 1)}. {armors.ToArray<Armor>()[i].Name}");
                                    }
                                    Console.WriteLine($"{armors.Count + 1}. Main menu");
                                    string chooseArmor = Console.ReadLine();
                                    int chooseArmorInt;
                                    if (int.TryParse(chooseArmor, out chooseArmorInt))
                                    {
                                        if (chooseArmorInt <= armors.Count + 1 && chooseArmorInt > 0)
                                        {
                                            if (chooseArmorInt <= armors.Count)
                                                hero.EquippedArmor = armors.ToArray<Armor>()[chooseArmorInt-1];
                                            if (chooseArmorInt == armors.Count + 1)
                                                goto label1;
                                        }
                                        else
                                        {
                                            goto label3;
                                        }
                                    }
                                    else
                                    {
                                        goto label3;
                                    }

                                Console.WriteLine($"You have choosed {hero.EquippedWeapon.Name} and {hero.EquippedArmor.Name}");
                                break;
                            }
                            break;
                        case "3":
                            while (true)
                            {
                                label4:
                                if (hero.EquippedWeapon == null)
                                {
                                    Console.WriteLine("Please choose weapon!");
                                    goto label1;
                                }
                                if (hero.EquippedArmor == null)
                                {
                                    Console.WriteLine("Please choose armor!");
                                    goto label1;
                                }
                                if (monsters.Count == 0)
                                {
                                    Console.WriteLine("You have defeated all monsters, please start the game again!");
                                    goto label1;
                                }
                                
                                Random rd = new Random();
                                int randomValue = rd.Next(0, monsters.Count);
                                Monster monster = monsters.ToArray<Monster>()[randomValue];

                               label5:
                                Console.WriteLine($"Your monster is {monster.Name}!");

                                Console.WriteLine("Please choose follow item:");
                                Console.WriteLine("1. HeroTurn");
                                Console.WriteLine("2. MonsterTurn");
                                Console.WriteLine("3. Main menu");
                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        gameCounter++;
                                        Fight.HeroTurn(hero,monster);
                                        bool? result=Fight.CheckWin(hero,monster);
                                        Console.WriteLine($"Hero health: {hero.CurrentHealth} Monster health: {monster.CurrentHealth}");
                                        if (result == null)
                                        {
                                           
                                            Console.WriteLine("Game will continue...");
                                            goto label5;
                                        }
                                        if (result==true)
                                        {
                                            winCounter++;
                                            Console.WriteLine("Hero win!");
                                    
                                            monsters.Remove(monster);
                                            goto label1;
                                        }
                                        if (result == false)
                                        {
                                            loseCounter++;
                                            Console.WriteLine("Hero lost!");
                                         
                                            goto label1;
                                        }
                                        break;
                                    case "2":
                                        gameCounter++;
                                        Fight.MonsterTurn(hero, monster);
                                        bool? result2 = Fight.CheckWin(hero, monster);
                                        Console.WriteLine($"Hero health: {hero.CurrentHealth} Monster health: {monster.CurrentHealth}");
                                        if (result2 == null)
                                        {
                                             
                                            Console.WriteLine("Game will continue...");
                                            goto label5;
                                        }
                                        if (result2 == true)
                                        {
                                            winCounter++;
                                            Console.WriteLine("Hero win!");
                                            monsters.Remove(monster);
                                            goto label1;
                                        }
                                        if (result2 == false)
                                        {
                                            loseCounter++;
                                            Console.WriteLine("Hero lost!");
                                            goto label1;
                                        }
                                        break;
                                    case "3":
                                        goto label1;
                                    default:
                                        break;
                                }
                            }
                            break;
                        default:
                            break;    
                    }
                     
                }
            }
        }

    }
}
