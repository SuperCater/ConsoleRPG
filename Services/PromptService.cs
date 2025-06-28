using ConsoleRPG.Classes;
using ConsoleRPG.Classes.Entities;
using ConsoleRPG.Records;

namespace ConsoleRPG.Services;

public static class PromptService
{
    public static Player PromptCreatePlayer()
    {
        while (true)
        {
            Console.Write("Enter your name: ");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty. Please try again."); 
                continue;
            }

            var player = new Player(new PlayerData { Name = name, Level = 1, Health = 100, });
            
            player.SaveData();
            Console.WriteLine("Player created with name: " + player.Name);
            return player;
        }
    }
    
    public static Player PromptLoadPlayer()
    {
        var players = Player.GetPlayerNames();
        if (players.Count == 0)
        {
            Console.WriteLine("No players found. Please create a new player.");
            return PromptCreatePlayer();
        }
        Console.WriteLine("Available players:");
        for (var i = 0; i < players.Count; i++)
        {
            if (i >= 0 && i < players.Count)
                Console.WriteLine($"{i + 1}. {Path.GetFileNameWithoutExtension(players[i])}");
        }
        Console.WriteLine("0. Create a new player");
        Console.Write("Select a player by number: ");
        if (!int.TryParse(Console.ReadLine(), out var choice) || choice < 0 || choice > players.Count)
        {
            Console.WriteLine("Invalid choice. Exiting...");
            return PromptCreatePlayer();
        }
        if (choice == 0)
        {
            return PromptCreatePlayer();
        }
        var selectedPlayer = players[choice - 1];
        return Player.LoadPlayer(selectedPlayer);
    }
    
    public static bool PromptYesOrNo(string message)
    {
        while (true)
        {
            Console.Write($"{message} (y/n): ");
            var input = Console.ReadLine()?.Trim().ToLower();
            switch (input)
            {
                case "y" or "yes":
                    return true;
                case "n" or "no":
                    return false;
                default:
                    Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                    break;
            }
        }
    }
}