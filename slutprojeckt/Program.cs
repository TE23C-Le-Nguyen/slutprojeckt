using System;
using System.Security;
class Program
{
    static void Main()
    {
        Console.WriteLine(@"  ____  ___  ____  _  __   __  _____ ____  ___    _    _     
 / ___|/ _ \|  _ \| | \ \ / / |_   _|  _ \|_ _|  / \  | |    
| |  _| | | | | | | |  \ V /    | | | |_) || |  / _ \ | |    
| |_| | |_| | |_| | |___| |     | | |  _ < | | / ___ \| |___ 
 \____|\___/|____/|_____|_|     |_| |_| \_\___/_/   \_\_____|");  //welcome of course

        Console.WriteLine("PLEASE CHOOSE HERO YOU WANT"); //choices
        Console.WriteLine("1. Hero (HP: 300, ATK: 75)");
        Console.WriteLine("2. Mage (HP: 175, ATK: 115)");
        Console.WriteLine("3. Shielder (HP: 500, ATK: 40)");
        Console.WriteLine("4. Healer (HP: 275, ATK: 30)");
        string choice = "";

        while (true) //loop for wrong input
        {
            Console.WriteLine("Please type a number 1 to 4");
            choice = Console.ReadLine();
            if (choice != "1" && choice != "2" && choice != "3" && choice != "4")
            {
                Console.WriteLine("You need to type in a number 1 to 4");
            }
            else
            {
                break; //break the loop learned from youtube and w3school
            }
        }
        Console.Clear();

        Console.WriteLine($"So your role is {choice}"); //final choice before starting the game
        Console.WriteLine("What would your name be?");
        string name = Console.ReadLine();
        Console.Clear();


        Character player; //relate and being a variable for Character

        if (choice == "1")
        {
            player = new Hero();
        }
        else if (choice == "2")
        {
            player = new Mage();
        }
        else if (choice == "3")
        {
            player = new Shielder();
        }
        else
        {
            player = new Healer();
        }

        int skillDamage = player.Skill();
        int skillDamage2 = player.Skill2();

        string[] enemyName = { "Goblin", "Orc", "Demon" }; //i use list at first but change to [] due to w3school
        int[] enemyhp = { 80, 100, 160 };
        int[] enemyatk = { 15, 24, 35 };
        int skillPoint = 5;
        Console.WriteLine($"{name} has come to Godly Trial");
        Console.WriteLine($"a wild {enemyName[0]}");

        for (int i = 0; i < enemyhp.Length; i++) //did not know this until ask chat gpt 
        {
            while (enemyhp[i] > 0)
            {
                Console.WriteLine("What will you do");
                Console.WriteLine("1.Normal Attack");
                Console.WriteLine("2.Use Skill");
                Console.WriteLine("3.Start Emoting");

                string playerChoice = Console.ReadLine();
                if (playerChoice == "1")
                {
                    Console.WriteLine($"{name} attacks the {enemyName[i]}");
                    enemyhp[i] -= player.atk;
                    Console.WriteLine($"Enemy has {enemyhp[i]} left");
                }
                else if (playerChoice == "2")
                {
                    if (skillPoint > 0)
                    {
                        Console.WriteLine($"{name} has use skill");
                        enemyhp[i] -= skillDamage;
                        player.hp += skillDamage2;
                        skillPoint--;
                        Console.WriteLine($"Skill point remaining: {skillPoint}");
                        Console.WriteLine($"Enemy has {enemyhp[i]} left");
                    }
                    else
                    {
                        Console.WriteLine("No skill point left. You lose your turn!");
                        Console.WriteLine($"Enemy has {enemyhp[i]} left");

                    }
                }
                else if (playerChoice == "3")
                {
                    Console.WriteLine($"{name} choose to emote on enemy");
                    Console.WriteLine($"{enemyName[i]} feel emotional damage from disrespect");
                    Console.WriteLine($"Enemy has {enemyhp[i]} left");
                }
                else
                {
                    Console.WriteLine($"{name} lose their turn due to wrong choice");
                    Console.WriteLine($"Enemy has {enemyhp[i]} left");
                }

                if (enemyhp[i] < 0)
                {
                    enemyhp[i] = 0;
                }
                if (enemyhp[i] > 0)
                {
                    Console.WriteLine("Enemy attack back");
                    player.hp -= enemyatk[i];
                    Console.WriteLine($"{name} got {player.hp}");
                }
                if (player.hp <= 0)
                {
                    Console.WriteLine("Wasted");
                    return;
                }
            }
        }
        Console.Clear();
        if (player.hp > 0)
        {
            Console.WriteLine($"{name} has passed the Godly Trial, proving to be worthy in the eyes of the divine");
        }
        else
        {
            Console.WriteLine($"{name} has failed the Godly Trial");
        }
        Console.ReadLine();
    }
}
//-------------------------------------------------------------------------------------------------------------
public abstract class Character
{
    public string name { get; set; }
    public int hp { get; set; }
    public int atk { get; set; }

    public abstract int Skill(); //first use void, thinking to create an act. then use return to get a value for skillDamage
    public abstract int Skill2();
}
public class Hero : Character
{
    public Hero()
    {
        hp = 300;
        atk = 75;
    }

    public override int Skill()
    {
        return 250;
    }
    public override int Skill2()
    {
        return 250;
    }
}
public class Mage : Character
{
    public Mage()
    {
        hp = 175;
        atk = 115;
    }

    public override int Skill()
    {
        return 170;
    }
    public override int Skill2()
    {
        return 30;
    }
}
public class Shielder : Character
{
    public Shielder()
    {
        hp = 500;
        atk = 40;
    }

    public override int Skill()
    {
        return 250;
    }
    public override int Skill2()
    {
        return 250;
    }
}
public class Healer : Character
{
    public Healer()
    {
        hp = 275;
        atk = 30;
    }

    public override int Skill()
    {
        return 250;
    }
    public override int Skill2()
    {
        return 250;
    }
}









