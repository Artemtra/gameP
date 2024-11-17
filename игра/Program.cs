
using System;

public class Character
{
    public string Name { get; set; }
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }
    public int AttackDamage { get; set; }
    public int HealPower { get; set; }
    public int Defens { get; set; }

    public Character(string name, int maxHealth, int attackDamage, int healPower, int defens)
    {
        Name = name;
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        AttackDamage = attackDamage;
        HealPower = healPower;
        Defens = defens;
    }

    public void Info()
    {
        Console.WriteLine($"имя персонажа {Name}, максимальное хп {MaxHealth}, в настоящее время {CurrentHealth}, урон персонажа {AttackDamage}, реген {HealPower}");
    }

    public void Attack(Character target)
    {
        Random random = new Random();
        int damage = random.Next(1, AttackDamage + 1);
        target.Damage(damage);
        Console.WriteLine($"{Name} атакует {target.Name} и наносит {damage} урона!");
    }
    public void Defense()
    {
        Defens++;
        int defence = HealPower;
    }
    public void Heal()
    {
        Random random = new Random();
        int healAmount = random.Next(1, HealPower + 1);
        CurrentHealth += healAmount;
        if (CurrentHealth > MaxHealth) CurrentHealth = MaxHealth;
        Console.WriteLine($"{Name} зарегенил {healAmount} хп!");
    }
    public void Damage(int damage)
    {
        CurrentHealth -= damage;
        Console.WriteLine($"{Name} получено {damage} урона. сейчас: {CurrentHealth}/{MaxHealth} хп");
    }
}


public class Game
{
    public Character FirstPlayer { get; set; }
    public Character SecondPlayer { get; set; }

    public void CreatePlayers()
    {
        Console.WriteLine("введите имя первого игрока: ");
        string player1Name = Console.ReadLine();
        Console.WriteLine("введите имя второго игрока: ");
        string player2Name = Console.ReadLine();

        Random random = new Random();
        int maxHealth = random.Next(10, 12);
        int attackDamage = random.Next(3, 8);
        int healPower = random.Next(1, 7);
        int defens = random.Next(1, 2);

        FirstPlayer = new Character(player1Name, maxHealth, attackDamage, healPower, defens);
        SecondPlayer = new Character(player2Name, maxHealth, attackDamage, healPower, defens);
    }


    public void StartGame()
    {
        CreatePlayers();
        FirstPlayer.Info();
        SecondPlayer.Info();

        Console.WriteLine("\n начало раунда!");

        Character currentPlayer = FirstPlayer;
        Character opponent = SecondPlayer;

        while (FirstPlayer.CurrentHealth > 0 && SecondPlayer.CurrentHealth > 0)
        {
            Console.WriteLine($"\n очередь {currentPlayer.Name} бить ебасос ");
            Console.WriteLine("1. атаковать (от 3 до 8)");
            Console.WriteLine("2. реген (от 1 до 7 хп)");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
                currentPlayer.Attack(opponent);
            else if (choice == 2)
                currentPlayer.Heal();
            else Console.WriteLine("ты долбаеб? такой нет команды, тебе дано 1 или 2 что сложного.");

            if (currentPlayer == FirstPlayer)
            {
                currentPlayer = SecondPlayer;
                opponent = FirstPlayer;
            }
            else
            {
                currentPlayer = FirstPlayer;
                opponent = SecondPlayer;
            }
        }

        Console.WriteLine($"\n гитлер победил (с маленькой буквы) блять, пойду ачисляться");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Game game = new Game();
        game.StartGame();
    }
}
